using UnityEngine;

public class MovementSystem : MySystem
{
    //������� ������������ ����������� ���������

    [SerializeField] IGetSpeed speedOfMyEntity; //������� ��� �������� �������� ����������� ��������
    [SerializeField] ISetAnimation setAnimation; // ������� ��� �������� ������ ���������

    [SerializeField] float step;
    [SerializeField] float rotStep;
    [SerializeField] float rotSpeed;
    [SerializeField] float speed;

    [SerializeField] float notToMoveCloseArea; // ������ �� ��������� �� ����� ���� ������ �������� ��������
    [SerializeField] bool isMoving = false;

    [SerializeField] Vector3 targetPos;

    [SerializeField] Transform myTransform;


    private void Awake()
    {
        speedOfMyEntity = transform.GetComponent<IGetSpeed>();
        if (speedOfMyEntity == null) Debug.LogError("No Entity on this gameObject"); // �������� ���������� �� �������� �� ������� � �������
        else
        {
            speed = speedOfMyEntity.GetSpeed();
            rotSpeed = speedOfMyEntity.GetRotSpeed();
        }

        setAnimation = transform.GetComponent<ISetAnimation>();
        if (setAnimation == null) Debug.LogError("No AnimationSystem on this GameObject"); // �������� ���������� �� �������� �� ������� � �������


        myTransform = gameObject.transform;

    }
    void Update()
    {
        if (isMoving) Moving();
    }

    public void MoveTo(Vector3 movingTo) //������ ������� ������������
    {
        targetPos = movingTo;

        if (Vector3.Distance(myTransform.position, targetPos) >= notToMoveCloseArea) isMoving = true;

        if (setAnimation == null) Debug.LogError("No AnimationSystem on this GameObject"); // �������� ���������� �� �������� �� ������� � �������
        else
        {
            setAnimation.SetAnimation("isMoving", isMoving);
        }

    }
    void StopMoving() //��������� ������� ������������
    {
        isMoving = false;

        if (setAnimation == null) Debug.LogError("No AnimationSystem on this GameObject");
        else
        {
            setAnimation.SetAnimation("isMoving", isMoving);
        }
    }

    void Moving() //������������� �����������
    {
        step = speed * Time.deltaTime;
        rotStep = rotSpeed * Time.deltaTime;
        myTransform.position = Vector3.MoveTowards(myTransform.position, targetPos, step);
        Quaternion toRotation = Quaternion.LookRotation(targetPos - myTransform.position, Vector3.up);
        myTransform.rotation = Quaternion.Slerp(myTransform.rotation, toRotation, rotStep);
        if (myTransform.position == targetPos) StopMoving();
    }

}

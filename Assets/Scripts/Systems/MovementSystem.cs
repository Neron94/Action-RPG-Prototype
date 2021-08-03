using UnityEngine;
//������� ������������ ����������� ���������
public class MovementSystem : MySystem, IDialogueToUI
{
    [SerializeField] private IGetSpeed speedOfMyEntity; //������� ��� �������� �������� ����������� ��������
    [SerializeField] private ISetAnimation setAnimation; // ������� ��� �������� ������ ���������

    [SerializeField] private float step;
    [SerializeField] private float rotStep;
    [SerializeField] private float rotSpeed;
    [SerializeField] private float speed;

    [SerializeField] private float notToMoveCloseArea; // ������ �� ��������� �� ����� ���� ������ �������� ��������
    [SerializeField] private bool isMoving = false;

    [SerializeField] private Vector3 targetPos;

    [SerializeField] private Transform myTransform;


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
    private void Update()
    {
        if (isMoving) Moving();
    }
    private void StopMoving() //��������� ������� ������������
    {
        isMoving = false;

        if (setAnimation == null) Debug.LogError("No AnimationSystem on this GameObject");
        else
        {
            setAnimation.SetAnimation("isMoving", isMoving);
        }
    }
    private void Moving() //������������� �����������
    {
        step = speed * Time.deltaTime;
        rotStep = rotSpeed * Time.deltaTime;
        myTransform.position = Vector3.MoveTowards(myTransform.position, targetPos, step);
        Quaternion toRotation = Quaternion.LookRotation(targetPos - myTransform.position, Vector3.up);
        myTransform.rotation = Quaternion.Slerp(myTransform.rotation, toRotation, rotStep);
        if (myTransform.position == targetPos) StopMoving();
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
   

}

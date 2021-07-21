using UnityEngine;

public class MovementSystem : MySystem
{
    //Система обеспечивает перемещение сущностей

    [SerializeField] IGetSpeed speedOfMyEntity; //Адаптер для передачи скорости собственной сущности
    [SerializeField] ISetAnimation setAnimation; // Адаптер для передачи команд аниматору

    [SerializeField] float step;
    [SerializeField] float rotStep;
    [SerializeField] float rotSpeed;
    [SerializeField] float speed;

    [SerializeField] float notToMoveCloseArea; // Отступ от персонажа до точки куда начнет двигатся персонаж
    [SerializeField] bool isMoving = false;

    [SerializeField] Vector3 targetPos;

    [SerializeField] Transform myTransform;


    private void Awake()
    {
        speedOfMyEntity = transform.GetComponent<IGetSpeed>();
        if (speedOfMyEntity == null) Debug.LogError("No Entity on this gameObject"); // Проверка подключена ли сущность со статами к объекту
        else
        {
            speed = speedOfMyEntity.GetSpeed();
            rotSpeed = speedOfMyEntity.GetRotSpeed();
        }

        setAnimation = transform.GetComponent<ISetAnimation>();
        if (setAnimation == null) Debug.LogError("No AnimationSystem on this GameObject"); // Проверка подключена ли сущность со статами к объекту


        myTransform = gameObject.transform;

    }
    void Update()
    {
        if (isMoving) Moving();
    }

    public void MoveTo(Vector3 movingTo) //Запуск системы передвижения
    {
        targetPos = movingTo;

        if (Vector3.Distance(myTransform.position, targetPos) >= notToMoveCloseArea) isMoving = true;

        if (setAnimation == null) Debug.LogError("No AnimationSystem on this GameObject"); // Проверка подключена ли сущность со статами к объекту
        else
        {
            setAnimation.SetAnimation("isMoving", isMoving);
        }

    }
    void StopMoving() //Остановка системы передвижения
    {
        isMoving = false;

        if (setAnimation == null) Debug.LogError("No AnimationSystem on this GameObject");
        else
        {
            setAnimation.SetAnimation("isMoving", isMoving);
        }
    }

    void Moving() //Реализовывает перемещение
    {
        step = speed * Time.deltaTime;
        rotStep = rotSpeed * Time.deltaTime;
        myTransform.position = Vector3.MoveTowards(myTransform.position, targetPos, step);
        Quaternion toRotation = Quaternion.LookRotation(targetPos - myTransform.position, Vector3.up);
        myTransform.rotation = Quaternion.Slerp(myTransform.rotation, toRotation, rotStep);
        if (myTransform.position == targetPos) StopMoving();
    }

}

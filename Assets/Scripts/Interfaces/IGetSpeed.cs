using System.Collections;
using System.Collections.Generic;

//Адаптер для передачи скорости сущности без привязки к определенной сущности
public interface IGetSpeed
{
    public float GetSpeed();
    public float GetRotSpeed();
}

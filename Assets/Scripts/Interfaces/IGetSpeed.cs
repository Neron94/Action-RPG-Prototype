using System.Collections;
using System.Collections.Generic;


public interface IGetSpeed
{
    //Адаптер для передачи скорости сущности без привязки к определенной сущности

    public float GetSpeed();
    public float GetRotSpeed();
}

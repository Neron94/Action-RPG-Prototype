using UnityEngine;

public class Player : _Entity, IGetSpeed
{
    [SerializeField] SO_EntityStats myStats;



    public float GetSpeed()
    {
        if (myStats != null) // �������� ���������� �� �����
        {
            return myStats.movSpeed;
        }
        else
        {
            Debug.LogError("This Entity have not STATS SO");
            return 0f;
        }

    }
    public float GetRotSpeed()
    {
        if (myStats != null) // �������� ���������� �� �����
        {
            return myStats.rotSpeed;
        }
        else
        {
            return 0f;
        }
    }

}

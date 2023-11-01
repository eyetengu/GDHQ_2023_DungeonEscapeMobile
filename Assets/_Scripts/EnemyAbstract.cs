using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAbstract : MonoBehaviour
{
    [SerializeField] protected int health;
    [SerializeField] protected int speed;
    [SerializeField] protected int gems;

    protected Transform pointA, pointB;


    public virtual void Attack()
    {

    }

    public abstract void Update();
}

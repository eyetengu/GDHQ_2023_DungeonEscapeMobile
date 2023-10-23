using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy, IDamageable
{
    public int Health { get; set; }

    //Use For Initialization
    public override void Init()
    {
        base.Init();
        Health = base.health;
    }

    public void Damage()
    {
        Debug.Log("Damage: " + this.name);
        
        health--;
        anim.SetTrigger("Hit");

        if (health < 1)
            anim.SetTrigger("Die");
    }
}

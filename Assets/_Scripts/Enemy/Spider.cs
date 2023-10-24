using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamageable
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
        Health--;
        anim.SetTrigger("Hit");

        if (Health < 1)
        {
            anim.SetTrigger("Die");
            Destroy(this.gameObject, 2.5f);
        }
    }
}

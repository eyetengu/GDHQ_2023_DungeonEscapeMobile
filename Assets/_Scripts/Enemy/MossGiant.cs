using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy, IDamageable
{
    public int Health { get; set; }
    private bool _hasPlayedDeathAnim;


    //Use For Initialization
    public override void Init()
    {
        base.Init();
        Health = base.health;
    }

    public override void Movement()
    {
        base.Movement();
    }

    public void Damage()
    {
        Health--;
        anim.SetTrigger("Hit");
        anim.SetBool("InCombat", true);
        isHit = true;

        if (Health < 1)
        {
            //_hasPlayedDeathAnim = true;
            anim.SetTrigger("Die");

            Destroy(this.gameObject, 2.5f);
        }
    }
}

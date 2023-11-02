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
        if (isDead) return;

        Health--;
        anim.SetTrigger("Hit");
        anim.SetBool("InCombat", true);
        isHit = true;

        if (Health < 1)
        {
            isDead = true;
            anim.SetTrigger("Die");

            GameObject diamond = Instantiate(diamondPrefab, transform.position, Quaternion.identity) as GameObject;
            diamond.GetComponent<Diamond>().gemDrop = gems;
        }
    }
}

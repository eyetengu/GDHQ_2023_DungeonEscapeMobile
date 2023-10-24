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

    public override void Movement()
    {
        base.Movement();

        //Distance Checker
        //float distance = Vector3.Distance(player.transform.localPosition, transform.position);

        //Debug.Log("Distance: " + distance);

        //Player Direction Checker
        Vector3 direction = player.transform.localPosition - transform.position;

            //Debug.Log("Side: " + direction.x);

        if(direction.x > 0 && anim.GetBool("InCombat") == true)
        {
            sprite.flipX = false;
        }
        else if(direction.x < 0 && anim.GetBool("InCombat") == true)
        {
            sprite.flipX= true;
        }
    }

    public void Damage()
    {        
        Health--;
        anim.SetTrigger("Hit");
        isHit = true;
        anim.SetBool("InCombat", true);

        if (Health < 1)
        {
            anim.SetTrigger("Die");
            Destroy(this.gameObject, 2.5f);
        }
    }    
}

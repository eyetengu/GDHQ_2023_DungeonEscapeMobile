using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamageable
{
    public int Health { get; set; }
    private bool _hasPlayedDeathAnim;
    [SerializeField] private GameObject _spiderAcidPrefab;



    //Use For Initialization
    public override void Init()
    {
        base.Init();
        Health = base.health;
    }

    public void Damage()
    {
        Health--;
        Debug.Log("Spider Damage");
       if(Health < 1)
        {
            isDead= true;
            anim.SetTrigger("Die");
        }
    }

    public override void Update()
    {

    }

    public override void Movement()
    {
        //sit still
    }

    public void Attack()
    {
        Instantiate(_spiderAcidPrefab, transform.position, Quaternion.identity);
    }
}

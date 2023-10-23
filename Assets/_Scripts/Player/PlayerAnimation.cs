using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _anim;
    private Animator _swordArcAnimator;


    void Start()
    {
        _anim = GetComponentInChildren<Animator>();
        _swordArcAnimator= transform.GetChild(1).GetComponent<Animator>();
    }

    public void Move(float move)
    {
        _anim.SetFloat("Move", Mathf.Abs(move));
    }

    public void Jump(bool jumping)
    {
        if (jumping)
            _anim.SetBool("Jump", true);
        else
            _anim.SetBool("Jump", false);        
    }

    public void Attack()
    {
        _anim.SetTrigger("Attack");
        _swordArcAnimator.SetTrigger("SwordAttack");
    }
}

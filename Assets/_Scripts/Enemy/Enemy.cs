using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected int health;
    [SerializeField] protected float speed;
    [SerializeField] protected int gems;
    [SerializeField] protected Transform leftPoint, rightPoint;

    protected Vector3 currentTarget;
    protected Animator anim;
    protected SpriteRenderer sprite;


    public virtual void Init()
    {
        anim = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        currentTarget = rightPoint.position;
    }

    private void Start()
    {
        Init();
    }

    public virtual void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            return;
        Movement();
    }

    public virtual void Movement()
    {
        if (currentTarget == leftPoint.position)
            sprite.flipX = true;
        else
            sprite.flipX = false;

        var distanceToTarget = Vector3.Distance(transform.position, currentTarget);

        if (distanceToTarget < 0.1f)
        {
            anim.SetTrigger("Idle");
            if(currentTarget == rightPoint.position)
                currentTarget = leftPoint.position;
            else if(currentTarget == leftPoint.position)
                currentTarget = rightPoint.position;    
        }
        
        transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
    }
}

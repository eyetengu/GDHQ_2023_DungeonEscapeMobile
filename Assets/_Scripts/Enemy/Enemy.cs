using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected int health;

    [SerializeField] protected float speed;

    [SerializeField] protected int gems;

    [SerializeField] protected Transform leftPoint, rightPoint;

    protected Vector3 currentTarget;
    protected Animator anim;
    protected SpriteRenderer sprite;

    protected bool isHit = false;
    protected Player player;


    public virtual void Init()
    {
        anim = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        
        currentTarget = rightPoint.position;
    }

    private void Start()
    {
        Init();
    }

    public virtual void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") && anim.GetBool("InCombat") == false)
            return;
          
        Movement();
    }

    public virtual void Movement()
    {
        //waypoint check routine
        if (currentTarget == leftPoint.position)
            sprite.flipX = true;               
        else
            sprite.flipX = false;

        //Waypoint Switch Routine
        if(transform.position == leftPoint.position)
        {
            currentTarget = rightPoint.position;
            anim.SetTrigger("Idle");
        }
        else if(transform.position == rightPoint.position)
        {
            currentTarget = leftPoint.position;
            anim.SetTrigger("Idle");
        }

        //Move The Player
        if(isHit == false)
            transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);





        //Distance Checker
        float distance = Vector3.Distance(transform.localPosition, player.transform.localPosition);

        if(distance > 2.0f)
        {
            isHit = false;
            anim.SetBool("InCombat", false);
        }
        else if(distance < 2.0f)
        {
            anim.SetBool("InCombat", true);
            anim.SetBool("InCombat", false);
        }
    }
}

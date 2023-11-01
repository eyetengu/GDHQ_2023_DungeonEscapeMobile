using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected int health;
    [SerializeField] protected float speed;
    [SerializeField] protected int gems;
    [SerializeField] protected Transform pointA, pointB;
    [SerializeField] private float attackRange;

    protected Vector3 currentTarget;
    protected Animator anim;
    protected SpriteRenderer sprite;

    protected bool isHit = false;

    protected Player player;
    protected bool isDead;


    public virtual void Init()
    {
        anim = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
       
        currentTarget = pointB.position;
    }

    private void Start()
    {
        Init();
    }

    public virtual void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") && anim.GetBool("InCombat") == false)
            return;
          
        if(isDead == false)
            Movement();
    }

    public virtual void Movement()
    {
        //WAYPOINT CHECK ROUTINE
        if (currentTarget == pointA.position)
            sprite.flipX = true;               
        else
            sprite.flipX = false;

        //SWITCH WAYPOINT ROUTINE
        if(transform.position == pointA.position)
        {
            currentTarget = pointB.position;
            anim.SetTrigger("Idle");
        }
        else if(transform.position == pointB.position)
        {
            currentTarget = pointA.position;
            anim.SetTrigger("Idle");
        }

        //MOVE THE PLAYER
        if(isHit == false)
            transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);

        //DISTANCE CHECKER
        float distance = Vector3.Distance(transform.localPosition, player.transform.localPosition);

        if(distance > attackRange)
        {
            isHit = false;
            anim.SetBool("InCombat", false);
        }
        else if(distance < attackRange)
        {
            isHit = true;
            anim.SetBool("InCombat", true);
        }

        //DIRECTION DETECTOR
        Vector3 direction = player.transform.localPosition - transform.position;       

        if (direction.x > 0 && anim.GetBool("InCombat") == true)
        {
            sprite.flipX = false;
        }
        else if (direction.x < 0 && anim.GetBool("InCombat") == true)
        {
            sprite.flipX = true;
        }

    }

 }
 
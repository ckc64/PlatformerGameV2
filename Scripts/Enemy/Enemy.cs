using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{

    public GameObject diamondSprite;

    [SerializeField] protected int health;
    [SerializeField] protected int speed;
    [SerializeField] protected int gems;
    [SerializeField] protected Transform pointA, pointB;
    protected Vector3 pointTarget;
    protected Animator anim;
    protected SpriteRenderer sprite;

    protected bool isHit = false;
    protected bool isDead = false;

    protected Player player;

    public virtual void Init()
    {
        anim = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    public virtual void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("idle") && anim.GetBool("CombatMode") == false)
        {
            return;
        }
        if(isDead == false)
            movement();
    }

    private void Start()
    {
        Init();
    }

    public virtual void movement()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("idle") )
        {
            return;
        }

        if (transform.position == pointA.position)
        {
            anim.SetTrigger("Idle");
            sprite.flipX = false;
            pointTarget = pointB.position;

        }
        else if (transform.position == pointB.position)
        {
            anim.SetTrigger("Idle");
            sprite.flipX = true;
            pointTarget = pointA.position;

        }

        
        if(isHit == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, pointTarget, speed * Time.deltaTime);
        }

        //distance between player and enemy
        float distance = Vector3.Distance(transform.localPosition, player.transform.localPosition);

        //check the of player and enemy if greater than 2units
        if(distance > 2.0f)
        {
            isHit = false;
            anim.SetBool("CombatMode", false);
        }

        //check the direction of eenemy to face to the player
        Vector3 direction = player.transform.localPosition - transform.localPosition;

        if (direction.x > 0 && anim.GetBool("CombatMode") == true)
        {
            //face enemy switch right
            sprite.flipX = false;
        }
        else if (direction.x < 0 && anim.GetBool("CombatMode") == true)
        {
            sprite.flipX = true;
        }

    }
   
}

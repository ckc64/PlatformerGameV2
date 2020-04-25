using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    private Animator anim;
    private Animator swordAnim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        swordAnim = transform.GetChild(1).GetComponent<Animator>();
    }

    public void Move(float move)
    {
        anim.SetFloat("Move",Mathf.Abs(move));
    }

    public void Jump(bool jump)
    {
        anim.SetBool("Jumping", jump);
    }

    public void Attack()
    {
        anim.SetTrigger("Attack");
        swordAnim.SetTrigger("SwordAnim");
    }

    public void Hit()
    {
        anim.SetTrigger("Hit");
    }

    public void Death()
    {
        anim.SetTrigger("Death");
    }
}

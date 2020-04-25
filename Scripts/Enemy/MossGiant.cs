using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy, IDamageable {

    public int Health { get; set; }


    //initialize your other attributes here
    public override void Init()
    {
        base.Init();
        Health = base.health;

    }
    public override void movement()
    {
        base.movement();
        
    }

    //call if the enemy is being attack
    public void Damage()
    {
        //set Health to 5 ofr 5 hits
        if (isDead == true)
            return;

        Health--;
        anim.SetTrigger("Hit");
        isHit = true;
        anim.SetBool("CombatMode", true);
        if (Health < 1)
        {
            isDead = true;
            anim.SetTrigger("Death");
            StartCoroutine(delayRemove());
            StartCoroutine(delayDiamondShow());
        }
    }

    IEnumerator delayRemove()
    {
        yield return new WaitForSeconds(0.3f);
        Destroy(this.gameObject);
        Instantiate(diamondSprite, transform.position, Quaternion.identity);
    }

    IEnumerator delayDiamondShow()
    {
        yield return new WaitForSeconds(1.0f);
       
        GameObject diamonds = Instantiate(diamondSprite, transform.position, Quaternion.identity) as GameObject;
        diamonds.GetComponent<Diamond>().gems = base.gems;
    }

}

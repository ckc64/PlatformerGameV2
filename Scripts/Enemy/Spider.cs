using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamageable
{
   public int Health { get; set; }

    public GameObject acidSprite;
    //initialize your other attributes here
    public override void Init()
    {
        base.Init();
        Health = base.health;

    }

    public override void Update()
    {
       
    }
    public void Damage()
    {
        if (isDead == true)
            return;

        Health--;
      
        if (Health < 1)
        {
            isDead = true;
            anim.SetTrigger("Death");
            //Destroy(this.gameObject);
            StartCoroutine(delayRemove());
            StartCoroutine(delayDiamondShow());
        }
    }

    public override void movement()
    {
        //base.movement() -> to put spider on hold and stay still
    }

    public void Attack()
    {
        Instantiate(acidSprite, transform.position, Quaternion.identity);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{

    private bool canHit = true;
   
    private void OnTriggerEnter2D(Collider2D sword)
    {

        IDamageable hitBySword = sword.GetComponent<IDamageable>();

        if(hitBySword != null)
        {
            if(canHit == true)
            {
                hitBySword.Damage();
                //DELAY THE HIT for one hit at a time
                canHit = false;
                StartCoroutine(delayHit());
            }
        }

   

    }

    IEnumerator delayHit()
    {
        yield return new WaitForSeconds(0.5f); //0.5secs
        canHit = true;

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Rigidbody2D rigid;
    [SerializeField] private float jumpForce = 5.0f;
    [SerializeField] private bool onGround = false;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        onGround = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space) && onGround == true ) {
            //jump
            rigid.velocity = new Vector2(rigid.velocity.x,jumpForce);
        }
        
        rigid.velocity = new Vector2(horizontalInput, rigid.velocity.y);
    }
}

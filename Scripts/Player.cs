using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Rigidbody2D rigid;
    [SerializeField] private float jumpForce = 5.0f;
    [SerializeField] private bool onGround = false;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float playerSpeed = 5.0f;
    private bool resetJump = false;
    private SpriteRenderer spriteRenderPlayer;
    private SpriteRenderer spriteRenderSwordArc;
    private Transform swordArcTransform;
    private PlayerAnimation playerAnim;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        //onGround = true;
        playerAnim = GetComponent<PlayerAnimation>();
        spriteRenderPlayer = GetComponentInChildren<SpriteRenderer>();
        spriteRenderSwordArc = transform.GetChild(1).GetComponent<SpriteRenderer>();
        swordArcTransform = transform.GetChild(1).GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

        float defaultPositionX = 0.3f;

        Vector3 newSwordArcPosition;
        //for attack

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            playerAnim.Attack();
        }


        //for movement left/right and jump
        float horizontalInput = Input.GetAxisRaw("Horizontal");


        //face right
        if(horizontalInput > 0)
        {
            spriteRenderPlayer.flipX = false;
            spriteRenderSwordArc.flipX = false;
            spriteRenderSwordArc.flipY = false;
            newSwordArcPosition = spriteRenderSwordArc.transform.localPosition;
            newSwordArcPosition.x = -defaultPositionX;
            spriteRenderSwordArc.transform.localPosition = newSwordArcPosition;


            spriteRenderSwordArc.transform.rotation = Quaternion.Euler(66.0f, 48.0f, -80.0f);
        }
        //face left
        else if(horizontalInput < 0)
        {
            spriteRenderPlayer.flipX = true;
            spriteRenderSwordArc.flipX = true;
            spriteRenderSwordArc.flipY = true;

            newSwordArcPosition = spriteRenderSwordArc.transform.localPosition;
            newSwordArcPosition.x = defaultPositionX;
            spriteRenderSwordArc.transform.localPosition = newSwordArcPosition;

            spriteRenderSwordArc.transform.rotation = Quaternion.Euler(-66.0f, -48.0f, -80.0f);
        }
        if (Input.GetKeyDown(KeyCode.Space) && onGround == true ) {
            //jump
            rigid.velocity = new Vector2(rigid.velocity.x,jumpForce);
            onGround = false;
            resetJump = true;
            StartCoroutine(ResetJumpRoutine());
            playerAnim.Jump(true);
            
        }

        //2D RAYCAST
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position,Vector2.down, 0.7f, groundLayer.value);
        Debug.DrawRay(transform.position, Vector2.down *0.7f, Color.red);

        if(hitInfo.collider != null)
        {
            if(resetJump == false) {
                playerAnim.Jump(false);
                onGround = true;
            }
            
        }
        
        rigid.velocity = new Vector2(horizontalInput*playerSpeed, rigid.velocity.y);
        playerAnim.Move(horizontalInput);
        
    }

 

    IEnumerator ResetJumpRoutine()
    {
        yield return new WaitForSeconds(0.2f);
        resetJump = false;
    }
}

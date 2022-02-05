using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 10f;
    [SerializeField]
    private float jumpForce = 11f;
    private float movementX;
    private Rigidbody2D myBody;
    private SpriteRenderer sr;
    private Animator anim;
    private string WALK_ANIMATION = "Walk";
    private string GROUND_TAG = "Ground";
    private string ENEMY_TAG = "Enemy";
    private bool isGrounded=true;
    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        sr = GetComponent < SpriteRenderer > ();
        anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyBoard();
        AnimatePlayer();
        PlayerJump();
    }
    private void FixedUpdate()
    {
        //PlayerJump();
    }
    void PlayerMoveKeyBoard() //move player left and right
    {
       
        movementX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movementX, 0f, 0f) * moveForce * Time.deltaTime;
      
        //if(Input.GetKey(KeyCode.RightArrow))
        //    transform.position += new Vector3(1, 0f, 0f) * moveForce * Time.deltaTime;
        //else if(Input.GetKey(KeyCode.LeftArrow))
        //    transform.position += new Vector3(-1, 0f, 0f) * moveForce * Time.deltaTime;

    }
    void AnimatePlayer() //add animation for player walking
    {
        if (movementX > 0)
        {
            anim.SetBool(WALK_ANIMATION, true); //bool variable set in animator
            sr.flipX = false;
        }
        else if (movementX < 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = true;
        }
        else
            anim.SetBool(WALK_ANIMATION, false);
    }
    void PlayerJump() //make the player jump
    {
        //if(Input.GetButton("Jump")&&isGrounded)
        if(Input.GetKeyDown(KeyCode.Space)&&isGrounded)
        {
            isGrounded = false;
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            //myBody.velocity = new Vector3(0, jumpForce);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) //check if collide with  ground
    {
        if (collision.gameObject.CompareTag(GROUND_TAG))
            isGrounded = true;
        if (collision.gameObject.CompareTag(ENEMY_TAG))
            Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(ENEMY_TAG))
            Destroy(gameObject);
    }
}

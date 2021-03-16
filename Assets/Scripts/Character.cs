using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public bool isDead;
    public float jumpForce = 4f;
    public LayerMask groundLayer;

     //Empty gameobject created to determine the bounds/center of the object
    public Transform GroundCheck1;
    //public Transform GroundCheck2; //uncomment this for OverlapArea

    public float distToGround;
    private Rigidbody2D rb2d;
    private bool doubleJumped = false;

    //private bool IsGrounded { get { return Physics2D.Raycast(transform.position, Vector2.down, 1.0f/*distance*/, groundLayer).collider != null; } } //return Physics2D.Raycast(transform.position, -Vector2.up). }; }
    bool grounded = false;

    public BoxCollider2D groundCollider;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        distToGround = GetComponent<Collider2D>().bounds.extents.y;
        groundCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Haut so noch ned wirklich hin ...
        //grounded = Physics2D.Raycast(transform.position, Vector2.down, 1.0f/*distance*/, groundLayer).collider != null;
        //grounded = true; // woraround

        if (grounded) { doubleJumped = false; }
        // Wenn noch am Leben
        if (!isDead)
        {
            if (Input.GetMouseButtonDown(0))
            {
                // TODO: Checken ob am Boden!
                if (grounded || !doubleJumped)
                {
                    if (!grounded)
                        doubleJumped = true;
                    rb2d.velocity = Vector2.zero;
                    rb2d.AddForce(new Vector2(0, jumpForce));
                    grounded = false;
                }
                // TODO: Animation für Springen!
                //anim.SetTrigger("Jump");
            }

            //// TEMP: Wenn links raus -> game over
            if (transform.position.x < -4.7f)
            {
                rb2d.velocity = Vector2.zero;
                isDead = true;
                GameControl.instance.PlayerDied();
            }
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.name.StartsWith("bottom")) // Bottom Hindernisse
    //    {
    //        rb2d.velocity = Vector2.zero;
    //        isDead = true;
    //        GameControl.instance.PlayerDied();
    //    }
    //}

    private void FixedUpdate()
    {
        if(!grounded){
            Debug.Log("NOT GROUNDED!");
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.name == "Background1" || col.gameObject.name == "Background2" || col.gameObject.name == "Background3")
        {
            grounded=true;
            Debug.Log(col.gameObject.name);
            Debug.Log("GROUNDED!");
        }
    }


    //void OnCollisionEnter2D(Collision2D collision)
    //{

    //}

    //// Für flappy Bird spiel zB
    //void OnCollisionEnter2D()
    //{
    //    rb2d.velocity = Vector2.zero;
    //    isDead = true;
    //    // anim.SetTrigger("Die");
    //    GameControl.instance.PlayerDied();
    //}
}

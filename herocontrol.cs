using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class herocontrol : MonoBehaviour
{
    public Rigidbody2D Rb;
    private float fInput = 0.0f;
    public float MaxSpeed = 5f;
    public float Moveforce;
    public float jumpForce = 400f;
    public bool jump = false;
    public AudioClip[] jumpClips;

    public bool bFaceRight=true;

    private bool bGrounded = false;
    private Transform groundCheck;


    // Start is called before the first frame update
    void Start()//初始化工作
    {
        Rb = GetComponent<Rigidbody2D>();
        groundCheck = transform.Find("groundCheck");
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        Rb.AddForce(Vector2.right * MaxSpeed * h);
        bGrounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        if (bGrounded)
        {
            if (Input.GetButtonDown("Jump") && bGrounded)
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce));
            }
        }
    }
    void FixedUpdate()
    {
        float fInput = Input.GetAxis("Horizontal");
        Rigidbody2D rigidBody = GetComponent<Rigidbody2D>();
        

            //控制移动
            if (fInput * rigidBody.velocity.x < MaxSpeed)
        {
            rigidBody.AddForce(Vector2.right * fInput * Moveforce);
        }
        //限制最大速度
        if (Mathf.Abs(rigidBody.velocity.x) > MaxSpeed)
        {
            rigidBody.velocity = new Vector2(Mathf.Sign(rigidBody.velocity.x) * MaxSpeed, rigidBody.velocity.y);
        }

        if (fInput > 0 && !bFaceRight)//左右移动转身
        {
            flip();
        }
        else if (fInput < 0 && bFaceRight)
        {
            flip();
        }
        
        
     }
        

    void flip()//转身
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        bFaceRight = !bFaceRight;
    }

}

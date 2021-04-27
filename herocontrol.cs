using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class herocontrol : MonoBehaviour
{
    public Rigidbody2D Rb;
    //public float speed = 50f;
    public float h;
    private float fInput = 0.0f;
    public float MaxSpeed = 5f;
    private float Moveforce;
    private bool bFaceRight=true;
    private bool bGrounded = false;


    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxis("Horizontal");
        Rb.AddForce(Vector2.right * MaxSpeed * h);
    }
    private void FixedUpdate()
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
        if (fInput > 0 && !bFaceRight)
        {
            flip();
        }
        else if (fInput < 0 && bFaceRight)
        {
            flip();
        }
    }
    
   
    void flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        bFaceRight = !bFaceRight;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 5.0f;
    public Sprite damagedEnemy;
    public Sprite deadEnemy;
    public int HP = 2;
    public float maxSpidForce = 200;
    public float minSpidForce = -200;
    public GameObject UI;

    private Rigidbody2D enemyBody;
    private Transform frontCheck;
    private bool isDead = false;
    private SpriteRenderer curBody;
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void Awake()
    {
        enemyBody = GetComponent<Rigidbody2D>();
        frontCheck = transform.Find("frontCheck");
        curBody = transform.Find("body").GetComponent<SpriteRenderer>();
    }
    private void FixedUpdate()
    {
        enemyBody.velocity = new Vector2(transform.localScale.x * moveSpeed, enemyBody.velocity.y);//位置，方向
        Collider2D[] collders = Physics2D.OverlapPointAll(frontCheck.position,1);

        foreach (Collider2D c in collders)
        {
            if (c.tag == "wall")
            {
                flip();
                break;
            }
        }
        if (HP == 1 && damagedEnemy != null)
        {
            curBody.sprite = damagedEnemy;
        }
        if (HP <= 0 && !isDead)
        {
            death();
            isDead = true;
        }

    }
    public void flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }


    public void Hurt()
    {
        // Reduce the number of hit points by one.
        HP--;
        
    }
    void death()
    {
        isDead = true;
        SpriteRenderer[] sprites = GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer s in sprites)
            s.enabled = false;

        curBody.enabled = true;
        curBody.sprite = deadEnemy;
        Collider2D[] cols = GetComponents<Collider2D>();
        foreach (Collider2D c in cols)
            c.isTrigger = true;

        enemyBody.freezeRotation = false;
        enemyBody.AddTorque(Random.Range(minSpidForce, maxSpidForce));//敌人死亡后随机旋转

        Vector3 UI_100 = new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z);
        Instantiate(UI, transform.position, Quaternion.identity);//数值100出现
    }
}

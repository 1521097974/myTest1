using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    float health = 100f;
    SpriteRenderer healthbar;
    Vector3 healthScale;
    public float hurtblood = 20f;
    public float damageRepeat = 0.5f;
    public AudioClip[] ouchClips;
    public float hurtForce = 100f;

    private float lastHurt;
    private Animator anim;
    void Start()
    {
        healthbar = GameObject.Find("Health").GetComponent<SpriteRenderer>();
        healthScale= healthbar.transform.localScale;
        lastHurt = Time.time;

        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Enemy")
        {
            if(Time.time>lastHurt +damageRepeat)//如果收到伤害的时间间隔大于
            {
                if (health > 0)
                {
                    takeDamage(collision.transform);
                    lastHurt = Time.time;//更新受伤害的时间
                }
                else
                {
                    anim.SetTrigger("die");
                    Collider2D[] cols = GetComponents<Collider2D>();
                    foreach (Collider2D c in cols)
                    {
                        c.isTrigger = true;
                    }
                    /*for(int i=0;i<cols.Length;i++)等价于上面
                    c=cols[i];
                    c.isTigger=true;*/
                    GetComponent<herocontrol>().enabled = false;
                    GetComponentInChildren<Gun>().enabled = false;

                    ;
                }

            }
            
        }
    }
    void takeDamage (Transform enemy)
    {
        health -= hurtblood;
        UpdateHealthBar();
        
        Vector3 hurtVector = transform.position
                - enemy.position + Vector3.up * 5f;
        GetComponent<Rigidbody2D>().AddForce
                (hurtVector * hurtForce);

        int i = Random.Range(0, ouchClips.Length);
        AudioSource.PlayClipAtPoint(ouchClips[i],transform.position);

    }
    void UpdateHealthBar()
    {
        healthbar.material.color = Color.Lerp
        (Color.green, Color.red, 1 - health * 0.01f);
        healthbar.transform.localScale = new
             Vector3(healthScale.x * health * 0.01f, 1, 1);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocket : MonoBehaviour
{
    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,2);
    }
    private void OnTriggerEnter2D(Collider2D collision)//碰撞
    {

        float rotationZ = Random.Range(0, 360);//产生了一个随机数
        if(collision.tag != "Player")//选择性的爆炸处理，判断
        {
            Instantiate(explosion, transform.position, Quaternion.Euler(new Vector3(0, 0, rotationZ)));
            Destroy(gameObject);//这个脚本挂在炮弹上，gameobject就是指炮弹
        }
        if (collision.tag == "Enemy")
        {
            // ... find the Enemy script and call the Hurt function.
            collision.gameObject.GetComponent<Enemy>().Hurt();

            // Call the explosion instantiation.
            //OnExplode();

            // Destroy the rocket.
           // Destroy(gameObject);
        }

    }
    void OnExplode()
    {
        // Create a quaternion with a random rotation in the z-axis.
        Quaternion randomRotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));

        // Instantiate the explosion where the rocket is with the random rotation.
        Instantiate(explosion, transform.position, randomRotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

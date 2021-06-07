using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Rigidbody2D rockets;
    public float fSpeed = 10;
    herocontrol playerCtrl;
    private AudioSource ac;
    // Start is called before the first frame update
    void Start()
    {
        playerCtrl = transform.root.GetComponent<herocontrol>();
        ac = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))//getbuttondown也可以，返回字符串
        {
            ac.Play();
            Vector3 direction = new Vector3(0, 0, 0);
            if(playerCtrl.bFaceRight)
            {
                
                Rigidbody2D RocketInstance = Instantiate(rockets, transform.position, Quaternion.Euler(direction));
                RocketInstance.velocity = new Vector2(fSpeed, 0);
            }
            else
            {
                direction.z = 180;
                Rigidbody2D RocketInstance = Instantiate(rockets, transform.position, Quaternion.Euler(direction));

                RocketInstance.velocity = new Vector2(-fSpeed, 0);
            }
        }
    }
}

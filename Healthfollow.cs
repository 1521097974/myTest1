using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthfollow : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform playerTransform;
    public Vector3 offset = new Vector3(0, 0, 1);
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = playerTransform.position + offset;
    }
}

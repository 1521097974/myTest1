using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform[] backgrounds;
    public float fparallax = 0.4f;
    public float layerFraction = 5f;
    public float fSmooth = 5f;

    Transform cam;
    Vector3 previousCamPos;
    private void Awake()
    {
        cam = Camera.main.transform;
    }
    
    private void Start()
    {
        previousCamPos = cam.position;
    }

    // Update is called once per frame
    void Update()
    {
        float fParrlaxX = (previousCamPos.x - cam.position.x) * fparallax;//上一帧减去当前帧的位置，模拟透视的效果
        for (int i=0;i<backgrounds.Length;i++)//对每一层进行运算
        {
            float fNewX = backgrounds[i].position.x + fParrlaxX * (1 + i * layerFraction);

            Vector3 newPos = new Vector3(fNewX, backgrounds[i].position.y, backgrounds[i].position.z);

            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, newPos, fSmooth * Time.deltaTime);
        }
        previousCamPos = cam.position;
    }
}

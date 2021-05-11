using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerFollow : MonoBehaviour
{
    public Transform playerTran;//主角的Transform
    public float MAXDistanceX = 2;
    public float MAXDistanceY = 2;
    public float xSpeed;
    public float ySpeed;
    private bool NeedMoveX()
    {
        bool bMove = false;
        if (Mathf.Abs(transform.position.x - playerTran.position.x) > MAXDistanceX)
            bMove = true;
        else
            bMove = false;

            return bMove;
    }
    private bool NeedMoveY()
    {
        bool bMove = false;
        if (Mathf.Abs(transform.position.y - playerTran.position.y) > MAXDistanceY)
            bMove = true;
        else
            bMove = false;

        return bMove;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()//首字母大写，系统调用
    {
        playerTran = GameObject.Find("Hero").transform;//在场景中找到需要的对象，第二种方法FindGameObjectsWithTag（）

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void TrackPlaer()
    {
        float newX = transform.position.x;
        float newY = transform.position.y;

        if (NeedMoveX())
            newX = Mathf.Lerp(transform.position.x, playerTran.position.x, xSpeed * Time.deltaTime);
        if (NeedMoveY())
            newY = Mathf.Lerp(transform.position.y, playerTran.position.y, ySpeed * Time.deltaTime);

        //newX = Mathf.Clamp(newX, minXandY.x, maxXandY.x);

        transform.position = new Vector3(newX, transform.position.x, transform.position.y);
        
    }
    private void FixUpDate()
    {
        TrackPlaer();
    }

}

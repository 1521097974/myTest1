using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Remove : MonoBehaviour
{
    public GameObject splash;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (GameObject.FindGameObjectWithTag("HealthBar").activeSelf)
            {
                GameObject.FindGameObjectWithTag("HealthBar").SetActive(false);
            }
            Instantiate(splash, collision.transform.position, transform.rotation);
            Destroy(collision.gameObject);
            StartCoroutine("ReloadGame");
        }
        else
        {
            Instantiate(splash, collision.transform.position, transform.rotation);
            Destroy(collision.gameObject);
        }
        IEnumerator ReloadGame()
        {
            // ... pause briefly
            yield return new WaitForSeconds(2);
            // ... and then reload the level.
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
        }
        // 重载游戏
        /* if (collision.gameObject.tag == "Player")
         {
             GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CamerFollow>().enabled = false;

             if (GameObject.FindGameObjectWithTag("HealthBar").activeSelf)
             {
                 GameObject.FindGameObjectWithTag("HealthBar").SetActive(false);
             }

             Instantiate(splash, collision.transform.position, transform.rotation);
             Destroy(collision.gameObject);
             StartCoroutine("ReloadGame");  // 重载游戏
         }
         else
         {
             Instantiate(splash, collision.transform.position, transform.rotation);
             Destroy(collision.gameObject);
         }

         IEnumerator ReloadGame()
         {
             // ... pause briefly
             yield return new WaitForSeconds(2);
             // ... and then reload the level.
             SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
         }*/

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BallController : MonoBehaviour
{
    public float speed;
    bool started;
    // Start is called before the first frame update
    void Start()
    {
        speed = 4f;
        started = false;
        GetComponent<Rigidbody>().isKinematic = true; 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !started)
        {
            started = true;
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<Rigidbody>().velocity = new Vector3 (speed,0,0);
            GameManger.instance.startGame();


        }
        if (Input.GetMouseButtonDown(0)&& !GameManger.instance.gameOver&&started && !GameManger.instance.pause)
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                GetComponent<Rigidbody>().AddForce(transform.up *6, ForceMode.Impulse);
                GetComponent<Rigidbody>().velocity = new Vector3(speed, 0, 0);

            }

        }
        if (transform.position.y >= 15)
        {
            GetComponent<Rigidbody>().AddForce(-transform.up * 5, ForceMode.Impulse);
            GameManger.instance.gameOver = true;
        }
    }
    
}

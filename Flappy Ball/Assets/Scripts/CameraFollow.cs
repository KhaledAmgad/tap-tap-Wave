using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject Ball;
    Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = Ball.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, Ball.transform.position - offset, Time.deltaTime * 1);
    }
}

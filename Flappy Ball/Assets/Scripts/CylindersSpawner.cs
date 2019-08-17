using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylindersSpawner : MonoBehaviour
{
    public GameObject Cylinders,Plane;
    float planePostion;
    // Start is called before the first frame update
    void Start()
    {
        planePostion = 0;
        spawnNewCylinders();
        spawnNewCylinders();
        spawnNewCylinders();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void startSpawn()
    {
        InvokeRepeating("spawnNewCylinders", 0.2f, 1.5f);
    }
    public void stopSpawn()
    {
        CancelInvoke("spawnNewCylinders");
    }
    void spawnNewCylinders()
    {
        int randY = Random.Range(8, 19);
        transform.position = new Vector3(transform.position.x + 10, randY, transform.position.z);
        Instantiate(Cylinders, transform.position, Quaternion.identity);
        if (transform.position.x-planePostion>=250)
        {
            planePostion += 250;
            Instantiate(Plane, new Vector3(planePostion+255, Plane.transform.position.y, Plane.transform.position.z), Quaternion.identity);
        }
    }
}

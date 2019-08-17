using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerChecker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Ball")
        {
            if (transform.parent)
            {
                Destroy(transform.parent.gameObject);
            }
            else
            {
                GameManger.instance.score += 1;
            }
            

            Destroy(gameObject,3f);

        }

    }
}

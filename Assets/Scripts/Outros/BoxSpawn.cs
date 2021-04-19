using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawn: MonoBehaviour
{
    private Transform box;

    


    void Start()
    {
        

        box = GameObject.FindGameObjectWithTag("box").transform;

        //  player.position = transform.position;

        if (box != null)
        {
            Checkpointe();
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("box"))
        {

            Checkpointe();
        }
    }

    public void Checkpointe()
    {
        Vector3 boxPos = transform.position;
        boxPos.z = 0f;

        box.position = boxPos;
    }

}

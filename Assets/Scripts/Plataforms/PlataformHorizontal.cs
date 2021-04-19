using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformHorizontal : MonoBehaviour
{
    private bool moveRight = true;

    public float speed = 3f;
    public Transform pointA;
    public Transform pointB;


     void Update()
    {
        if (transform.position.x < pointA.position.x)
        {
            moveRight = true;
        }

        if (transform.position.x > pointB.position.x)
        {
            moveRight = false;
        }

        if (moveRight)
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        }
        else 
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }
    }


}

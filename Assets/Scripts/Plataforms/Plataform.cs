using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataform : MonoBehaviour
{

    private bool moveDown = true;

    public float speed = 3f;
    public Transform pointA;
    public Transform pointB;


     void Update()
    {           
      if (transform.position.y > pointA.position.y)
        
        {
                moveDown = true;
        }

      if(transform.position.y < pointB.position.y)
     
        {
            moveDown = false;
        }

        if (moveDown)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - speed * Time.deltaTime);
        }
        else
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + speed * Time.deltaTime);
        }
    }
}

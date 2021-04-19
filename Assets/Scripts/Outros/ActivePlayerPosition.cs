using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivePlayerPosition : MonoBehaviour
{

     public  GameObject ActivePosition;

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player.instance.healthSystem.health--; // tirando vida do player ao cair no buraco
            ActivePosition.SetActive(true);

        }
    }
}

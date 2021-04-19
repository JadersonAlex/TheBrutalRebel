using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float Speed;
    //public float Damage;

    void Start()
    {
        Destroy(gameObject, 4f);
    }


    void Update()
    {
        transform.Translate(Vector2.right * Speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Quando o player encostar no arqueiro ele irá desaparecer

        if (collision.gameObject.tag == "Player")
        {

            collision.gameObject.transform.Translate(-Vector2.right * 0.10f); // Jogando o jogador  para trás ao colidir
            Player.instance.healthSystem.health--; // remove vida ao colidir com o player
            //Destroy(this);
        }
    }
    
}



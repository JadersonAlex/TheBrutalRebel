using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataformfalls : MonoBehaviour
{
    public Rigidbody2D rb;
    

     void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Player")) // objeto com nome Player
        {
            rb.bodyType = RigidbodyType2D.Dynamic; // faz a plataforma ser influenciada pela travidade 
            rb.mass = 50f;
            rb.gravityScale = 0.5f;
            Destroy(gameObject, 4); // destruir depois de 4 segundos
        }
    }
}

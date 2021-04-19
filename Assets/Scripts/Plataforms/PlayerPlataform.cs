using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlataform : MonoBehaviour
{

    // -------- Este script faz com que o jogador ande junto com a plataforma ----------


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("PlataformHorizontal")) // objeto com nome Plataform
        {
            this.transform.parent = collision.transform; // o obj do jogador vira filho da plataforma
        }     
    }


     void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("PlataformHorizontal")) 
        {
            this.transform.parent = null; // o obj do jogador deixa de ser filho
        }    
    }
}

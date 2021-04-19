using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pyromaniac : MonoBehaviour
{
    // Este script faz com que o inimigo fique patrulhando, olhando de  um lado para o outro
    public float Speed;
    public bool Direction;
    public float DurationsDirection;

    private Animator anim;
    private float TimeDirection;
    void Start()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        // rotacionar o inimigo
        if (Direction)
        {
            transform.eulerAngles = new Vector2(0, 0); // Olhando pra direita
        }
        else
        {
            transform.eulerAngles = new Vector2(0, 180); // Olhando pra esquerda
        }

        // movimentando o inimigo
        transform.Translate(Vector2.right * Speed * Time.deltaTime);

        TimeDirection += Time.deltaTime;

        //inverte o booleano "Direction" de acordo com o tempo
        if (TimeDirection >= DurationsDirection)
        {
            TimeDirection = 0;
            Direction = !Direction;
        }
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        
            anim.SetTrigger("Atk");
            
            collision.gameObject.transform.Translate(-Vector2.right * 0.5f); // Jogando o jogador  para trás ao colidir
                                                                             // colocar o método de remover vida aqui    
          Player.instance.healthSystem.health--;



/*
        if (collision.gameObject.tag == "pointAtk")
        {
            GetComponent<CircleCollider2D>().enabled = false; //desativar o colisor do Pyromaniac
            Speed = 0; // pra ele não andar quando for atacada
            anim.SetTrigger("die");
            Destroy(gameObject, 1f); // espera 1 segundo antes de destruir 
        }
*/

    }

  }    
         

    

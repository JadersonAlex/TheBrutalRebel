using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArcher : MonoBehaviour
{
    public float AtkInterval; // intervalo de ataque
    public float AtkDistance; // Distancia de ataque, a distancia que ele vai ver o player

    private float IntervalAtk;
    private bool isAtk;

    public GameObject Arrow; // objeto que vou arremessar

    private Animator anim;
    private GameObject player;

    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    Vector3 firePos;

    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        float Distance = player.transform.position.x - transform.position.x;

        // olhando pra direita
        if (Distance > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
            firePos = new Vector3(0.5f, 0, 0); // ponto de origem(direita) da flecha

        }
        else // olhando pra esquerda
        {
            transform.eulerAngles = new Vector2(0, 180);
            firePos = new Vector3(-0.5f, 0, 0); // ponto de origem(esquerda) da flecha
        }

        // executa o ataque do dragão se a distância for correspondente
        if (!isAtk && Mathf.Abs(Distance) <= AtkDistance)
        {
            anim.SetTrigger("atk");
            Instantiate(Arrow, transform.position + firePos, transform.rotation);
            isAtk = true;
        }

        //Seta os valores iniciais para reiniciar a contagem
        if (isAtk)
        {
            IntervalAtk += Time.deltaTime; // somando 

            if (IntervalAtk >= AtkInterval)
            {
                isAtk = false;
                IntervalAtk = 0;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GetComponent<BoxCollider2D>().enabled = false; //desativar o colisor do Archer
            anim.SetTrigger("die"); // chamando a animação de morte
            Destroy(gameObject, 1); // espera 1 segundo antes de destruir ela
            
        }
    }
}
   
    // -----------  
   




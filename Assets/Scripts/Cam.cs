using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    private GameObject player;
    public float Speed;

    public static object main { get; internal set; }

    void Start()
    {
     //   player = GameObject.FindGameObjectWithTag("Player"); // ele vai procurar um objeto com a tag Player   
    }


    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player"); // ele vai procurar um objeto com a tag Player   // pra ele verificar toda vez que o jogo rodar

        if (player != null) // se o player for diferente de nulo, ou seja, se ele existir
        {
            if (player.transform.position.x > -5f) // limite da câmera
            {
                Vector3 newPos = new Vector3(player.transform.position.x + 5f, transform.position.y, transform.position.z);
                transform.position = Vector3.Lerp(transform.position, newPos, Speed * Time.deltaTime);
            }
        }
    }
}

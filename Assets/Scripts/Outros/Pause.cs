using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{

    //variável que guarda o script do player 
    private Player player;

    public void Start()
    {
        // procura aí um obj com a tag Player 
       player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    public void IsPause()
    {
        Time.timeScale = 0;
       player.GetComponent<Player>().enabled = false; // desativando o script do Player para ele não atacar
        
    }

    public void OffPause()
    {
        Time.timeScale = 1;
        player.GetComponent<Player>().enabled = true; // ativando novamente
    }
}

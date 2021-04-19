using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

   public class Restart : MonoBehaviour
{

   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene("Aviso");
            // GameController.instance.ShowGameOver(); // chamando o game over ao cair
           //  Player.instance.healthSystem.health--; // tirando vida do player ao cair no buraco
           

        }
    }

}

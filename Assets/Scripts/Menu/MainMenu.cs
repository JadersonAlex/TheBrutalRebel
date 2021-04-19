using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    

   
    public void creditos()
    {
        SceneManager.LoadScene("credts");
    }
    public void StartGame()
    {

        

        
        SceneManager.LoadScene(3); // carrega o tutorial 1


        // zerar as moedas ao iniciar um novo jogo 


        // se não funcionar pegar esses métodos do script GameController
        PlayerPrefs.DeleteKey("score"); // se eu quiser zerar o score
        // ou PlayerPrefs.DeleteAll(); para deletador todos os dados 
    }

    public void returnMenu()
    {
        SceneManager.LoadScene("LoadingMenu");
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Exit()
    {
        Application.Quit();
    }
}

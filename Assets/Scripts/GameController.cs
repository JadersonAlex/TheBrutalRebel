using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
    public static GameController instance;

   // public string level;
    public int score;
    public TMP_Text scoreText;
    public TMP_Text scoreText2;

    public GameObject gameOverPanel;
    



    private void Awake()
    {

        instance = this;

       // Time.timeScale = 1; // tirando do pause ao morrer


        // ---------- fazendo os dados salvos serem carregados ao passar de fase  --------------------
        if (PlayerPrefs.GetInt("score") > 0)
        {
            score = PlayerPrefs.GetInt("score");
            scoreText.text = "x" + score.ToString();


        }

        //PlayerPrefs.DeleteKey("score"); se eu quiser zerar o score
        // ou PlayerPrefs.DeleteAll(); para deletador todos os dados 

    }


    public void GetCoin()
    {
        score++; // valor que o player vai receber ao coletar
        score++;
        score++;
        scoreText.text = "x" +  score.ToString();

        PlayerPrefs.SetInt("score", score); // salvando dados
    }

/*
    public void NextLevel()
    {
        SceneManager.LoadScene(level); // próxima fase
    }
*/
   
    public void ShowGameOver() // GameOver
    {
        gameOverPanel.SetActive(true);
     //   Time.timeScale = 0; // jogo pausado

        // destruir ou pausar o jogador depois de um tempo para que a animação de morte seja executada no tempo certo
    }

    public void RestartGame() 
    {
        // restart da fase atual
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
   public bool PauseGame;
   public GameObject pauseGameMenu;
    public GameObject pauseGameOver;
   [SerializeField] Text scoreText;
   [SerializeField] int castleLife;
   [SerializeField] int currentScore;
    
    void Update()
    {
         int LifeScore = PlayerPrefs.GetInt("castleLife",castleLife);
         int Score = PlayerPrefs.GetInt("Score",currentScore);
         
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PauseGame)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
         if(LifeScore == 0)
        {
            print("Lifescore  "+LifeScore);
            GameOverMenu();
            scoreText.text = "SCORE  " + Score;
        }
        
    }

    public void Resume()
    {
        pauseGameMenu.SetActive(false);
        Time.timeScale = 1f;
        PauseGame = false; 
    }

    public void Pause()
    {
        pauseGameMenu.SetActive(true);
        Time.timeScale = 0f;
        PauseGame = true;
    }

    public void LoadMenu()
    {
        pauseGameOver.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void GameOverMenu ()
    {
        pauseGameOver.SetActive(true);
        Time.timeScale = 0f;
        

    }

}

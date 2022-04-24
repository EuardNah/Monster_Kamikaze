using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
   public void PlayGame()
   {
       
       Time.timeScale = 1f;
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
   }

   public void ExitGame()
   {
       Debug.Log("igra zakrilas");
       Application.Quit();
   }
}

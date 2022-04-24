using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using UnityEngine;

public class Winner : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] int scenIndex;
    [SerializeField] int currentScore;
    [SerializeField] int sceneEnemis ;

    
    
    public GameObject Winnermenu;
    

    void Start()
    {
        int Score = PlayerPrefs.GetInt("Score",currentScore);
        scoreText.text = "SCORE  " + Score;
        print ("scoreText.text" + scoreText.text);
        //Time.timeScale = 1f;
        //sceneEnemis=1;
       
        
        
    }

    // Update is called once per frame
    public void WinnerMenu(int scen)
    {
        
        
        print("scen  if "+ scen);
        scenIndex = scen;
        print("scenIndex  if "+ scenIndex);
        
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void NextLevel()
    {
        
        Time.timeScale = 1f;
        print("NextLevel scenIndex  " + scenIndex);
        SceneManager.LoadScene( 3);
    }
}

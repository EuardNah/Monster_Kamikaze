using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
     [SerializeField] Text scoreText;
     int currentScore;
    // Start is called before the first frame update
    void Start()
    {
        int Score = PlayerPrefs.GetInt("Score",currentScore);
        scoreText.text = Score.ToString();
    }

    
}

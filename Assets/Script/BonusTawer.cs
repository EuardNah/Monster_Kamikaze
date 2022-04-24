using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusTawer : MonoBehaviour
{
   [SerializeField] Text countTawer;
     [SerializeField] Text scoreCount;
    [SerializeField] Image imageBonus;
    bool giveBonus = false;
    [SerializeField] int bonusCount = 1;
    [SerializeField] int currentScore;
    [SerializeField] int Score;
    int ScorePlus ;
  
    void Start()
    {
        Score = PlayerPrefs.GetInt("Score",currentScore);
        ScorePlus = Score + 30;
    }
    public void BonusTawers(int bonusList)
    { 
        
        
        
        PlayerPrefs.SetInt("bonuScore",bonusList);
        if (bonusList ==  20 && bonusCount > 0)
        {
            int bonuScore =  bonusList - 20;
            PlayerPrefs.SetInt("bonuScore",bonuScore);
            countTawer.text = bonusCount.ToString();
            bonusCount--;
            
            giveBonus = true;
            imageBonus.color = Color.yellow;

        }else
        {
            
            if (bonusList == ScorePlus && bonusCount >0 )
            {
                int bonuScore =  bonusList - 30;
                PlayerPrefs.SetInt("bonuScore",bonuScore);
                
                countTawer.text = bonusCount.ToString();

                bonusCount--;
                giveBonus = true;
                imageBonus.color = Color.yellow;
            }
        }
        
    }

    public int tawerLimitPlus(int plus)
    {
        if (!giveBonus)
        {
            
            return plus;
            
        }

        else
        {
        
            plus ++;
            countTawer.text = bonusCount.ToString();
            giveBonus=false;
            imageBonus.color = Color.white;
        
            return plus;
        }
        
    }
}

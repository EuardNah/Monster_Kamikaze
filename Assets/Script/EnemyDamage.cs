using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[SelectionBase]

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] public int hitPoints = 10;
    [SerializeField] ParticleSystem hitParticles;
    
    [SerializeField] ParticleSystem deathParticles;
    [SerializeField] AudioClip hitEnemySoundFX;

    [SerializeField] AudioClip deathEnemySoundFX;

    [SerializeField] Image helfbarfilling;

    [SerializeField] Slider mySlider;

    [SerializeField] Gradient _gradient;
     Text scoreText;
     int currentScore;
        int newScore;
     AudioSource audioSource;
    void Start()
    {
        //int Score = PlayerPrefs.GetInt("Score",currentScore);
        mySlider.maxValue = hitPoints;
        helfbarfilling.color =  _gradient.Evaluate(hitPoints/10f);
        scoreText = GameObject.Find("Score").GetComponent<Text>();
        PlayerPrefs.SetInt("Score",currentScore);
        //scoreText.text = Score.ToString();
       
        audioSource= GetComponent<AudioSource>();
    }
 

   void OnParticleCollision(GameObject other)
   {
       
       ProccessHit();
      
       if(hitPoints <= 0)
        {
            DestroyEnemy(deathParticles,true);
        }
        
    }
    public void DestroyEnemy(ParticleSystem fx, bool addScore)
    {
        BonusTawer bonusTawer = FindObjectOfType<BonusTawer>();
        if(addScore){
            currentScore = int.Parse(scoreText.text);
            currentScore = currentScore +10;
            PlayerPrefs.SetInt("Score",currentScore);
            bonusTawer.BonusTawers(currentScore);
            int scoreGetCount = PlayerPrefs.GetInt("bonuScore",newScore);
            if (currentScore > scoreGetCount)
            {
               
                currentScore = scoreGetCount;
                scoreText.text = scoreGetCount.ToString();
            }

            
            scoreText.text = currentScore.ToString(); 
           
        }
       //первый спОсаб с Aweck Instantiate(deathParticles, transform.position,Quaternion.identity);
       var destroyFX = Instantiate(fx, transform.position,Quaternion.identity);
        destroyFX.Play();
        float destroyFX_duration = destroyFX.main.duration;
        //глобалные класс AudioSource.PlayClipAtPoint
        AudioSource.PlayClipAtPoint(deathEnemySoundFX,Camera.main.transform.position);
        Destroy(destroyFX.gameObject,destroyFX_duration);
        Destroy(gameObject);
    }

    void ProccessHit()
    {
        audioSource.PlayOneShot(hitEnemySoundFX);
        hitParticles.Play();
        hitPoints = hitPoints - 1;
       
        helfbarfilling.color=_gradient.Evaluate(hitPoints/10f);
        
    }
}

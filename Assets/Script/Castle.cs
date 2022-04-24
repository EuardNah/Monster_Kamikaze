using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Castle : MonoBehaviour
{
    [SerializeField] int playerLife = 10;
    [SerializeField] int damageCount = 1;

    [SerializeField] Text textLife;

    [SerializeField] AudioClip castleDamageSoundFX;
    [SerializeField] Image helfbarfilling;

    [SerializeField] Slider mySlider;
    [SerializeField] int castleLife = 1;
    [SerializeField] Gradient _gradient;

    



    AudioSource audioSource;
    void Start()
    {
        mySlider.maxValue = playerLife;
        helfbarfilling.color =  _gradient.Evaluate(playerLife/10f);
        textLife.text = castleLife.ToString();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        PlayerPrefs.SetInt("castleLife",castleLife);
    }

    
    public void Damage()
    {

        audioSource.PlayOneShot(castleDamageSoundFX);
        playerLife = playerLife - damageCount;
        //textLife.text = playerLife.ToString(); 
        helfbarfilling.color =  _gradient.Evaluate(playerLife/10f);
        mySlider.value=playerLife;
        if(playerLife <=0)
        {
            castleLife -=1;
            textLife.text = castleLife.ToString();
            
            //playerLife = 10;
            //mySlider.value=playerLife;
            helfbarfilling.color =_gradient.Evaluate(mySlider.value/10f);
        }

        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class OptionMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", Mathf.Log10(volume)*20);
    }
    
    public void SetQuelity(int quelityIndex)
    {
        QualitySettings.SetQualityLevel(quelityIndex + 1);
    }

    public void Sound()
    {
        AudioListener.pause = !AudioListener.pause;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Corrected from UnityEngine.Ui

public class SoundManager : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume")) // Corrected capitalization of 'HasKey'
        {
            PlayerPrefs.SetFloat("musicVolume", 1); // Corrected parentheses and added semicolon
            Load();
        }
        else
        {
            Load();
        }
    }

    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value; // Corrected 'AudioListen' to 'AudioListener' and added semicolon
        Save();
    }

    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume"); // Added semicolon
    }
    
    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }
}
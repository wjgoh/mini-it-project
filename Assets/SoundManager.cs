using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Ui;

public class SoundManager : MonoBehaviour

{
    [SerializeField] Slider volumeSlider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ChangeVolume()
    {
       AudioListen.volume = volumeSlider.value
    }

    private void Load()
    {

    }
    
    private void Save()
    {
        
    }
}

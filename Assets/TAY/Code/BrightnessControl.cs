using UnityEngine;
using UnityEngine.UI;

public class BrightnessManager : MonoBehaviour
{
    [SerializeField] Slider brightnessSlider;

    void Start()
    {
        LoadBrightness();
    }

    public void ChangeBrightness()
    {
        Debug.Log("Brightness changed: " + brightnessSlider.value);
        RenderSettings.ambientLight = new Color(brightnessSlider.value, brightnessSlider.value, brightnessSlider.value);
        SaveBrightness();
    }

    private void LoadBrightness()
    {
        if (PlayerPrefs.HasKey("brightness"))
        {
            brightnessSlider.value = PlayerPrefs.GetFloat("brightness");
            RenderSettings.ambientLight = new Color(brightnessSlider.value, brightnessSlider.value, brightnessSlider.value);
            Debug.Log("Brightness loaded: " + brightnessSlider.value);
        }
        else
        {
            brightnessSlider.value = 1f; // Default brightness value
            SaveBrightness();
            Debug.Log("Default brightness applied: " + brightnessSlider.value);
        }
    }

    private void SaveBrightness()
    {
        PlayerPrefs.SetFloat("brightness", brightnessSlider.value);
        Debug.Log("Brightness saved: " + brightnessSlider.value);
    }
}






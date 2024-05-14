using UnityEngine;
using UnityEngine.UI;

public class BrightnessManager : MonoBehaviour
{
    [SerializeField] Slider brightnessSlider; // Reference to the slider for adjusting brightness

    void Start()
    {
        LoadBrightness();
    }

    public void ChangeBrightness()
    {
        if (brightnessSlider == null)
        {
            Debug.LogError("BrightnessSlider is not assigned in the Unity Editor.");
            return;
        }

        // Adjust the ambient light based on the slider value
        RenderSettings.ambientLight = new Color(brightnessSlider.value, brightnessSlider.value, brightnessSlider.value);

        // Save the new brightness value to PlayerPrefs
        SaveBrightness();
    }

    private void LoadBrightness()
    {
        if (PlayerPrefs.HasKey("brightness"))
        {
            brightnessSlider.value = PlayerPrefs.GetFloat("brightness");
            RenderSettings.ambientLight = new Color(brightnessSlider.value, brightnessSlider.value, brightnessSlider.value);
        }
        else
        {
            brightnessSlider.value = 1f; // Default brightness value
            SaveBrightness();
        }
    }

    private void SaveBrightness()
    {
        PlayerPrefs.SetFloat("brightness", brightnessSlider.value);
    }
}












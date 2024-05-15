using UnityEngine;
using UnityEngine.UI;

public class BrightnessController : MonoBehaviour
{
    public Light mainLight;
    public Slider brightnessSlider;

    private float maxIntensity = 2.0f; // Maximum intensity of the light

    void Start()
    {
        // Set the initial brightness value
        brightnessSlider.value = mainLight.intensity / maxIntensity;
    }

    public void OnSliderValueChanged(float value)
    {
        AdjustBrightness(value);
    }

    public void OnButtonClick()
    {
        // Example: Adjust the brightness to half of the maximum intensity when the button is clicked
        AdjustBrightness(0.5f);
    }

    void AdjustBrightness(float brightnessValue)
    {
        // Clamp the brightness value between 0 and 1
        brightnessValue = Mathf.Clamp01(brightnessValue);

        // Adjust the intensity of the main light based on the slider value
        mainLight.intensity = brightnessValue * maxIntensity;
    }
}











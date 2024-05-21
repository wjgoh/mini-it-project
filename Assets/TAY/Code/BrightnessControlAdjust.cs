using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Required for UI elements

public class BrightnessControlAdjust : MonoBehaviour
{
    public Slider brightnessSlider; // Reference to the Slider

    private SpriteRenderer[] spriteRenderers;

    void Start()
    {
        spriteRenderers = FindObjectsOfType<SpriteRenderer>();
        Debug.Log($"Found {spriteRenderers.Length} SpriteRenderers."); // Debug log

        if (brightnessSlider != null)
        {
            brightnessSlider.value = 1.0f; // Set default value
            brightnessSlider.onValueChanged.AddListener(AdjustBrightness);
            Debug.Log("Brightness Slider listener added."); // Debug log
        }
        else
        {
            Debug.LogError("Brightness Slider is not assigned in the inspector");
        }
    }

    public void AdjustBrightness(float BrightnessValue)
    {
        Debug.Log($"Adjusting brightness to {BrightnessValue}"); // Debug log

        foreach (SpriteRenderer spriteRenderer in spriteRenderers)
        {
            spriteRenderer.color = new Color(BrightnessValue, BrightnessValue, BrightnessValue, spriteRenderer.color.a);
            Debug.Log($"Updated color of {spriteRenderer.gameObject.name} to {spriteRenderer.color}"); // Debug log
        }
    }
}






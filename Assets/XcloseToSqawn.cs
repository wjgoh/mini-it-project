using UnityEngine;

public class SettingsMenuToggle : MonoBehaviour
{
    // Reference to the settings menu Canvas
    public GameObject settingsMenu;

    // Method to toggle the settings menu's active state
    public void ToggleSettingsMenu()
    {
        if (settingsMenu != null)
        {
            settingsMenu.SetActive(!settingsMenu.activeSelf);
        }
        else
        {
            Debug.LogWarning("SettingsMenu is not set.");
        }
    }
}




using UnityEngine;

public class SettingsMenuManager : MonoBehaviour
{
    // Reference to the settings menu Canvas
    public GameObject settingsMenu;

    // Method to open the settings menu
    public void OpenSettingsMenu()
    {
        if (settingsMenu != null)
        {
            settingsMenu.SetActive(true);
        }
        else
        {
            Debug.LogWarning("SettingsMenu is not set.");
        }
    }

    // Method to close the settings menu
    public void CloseSettingsMenu()
    {
        if (settingsMenu != null)
        {
            settingsMenu.SetActive(false);
        }
        else
        {
            Debug.LogWarning("SettingsMenu is not set.");
        }
    }
}



using UnityEngine;

public class PlayerPositionManager : MonoBehaviour
{
    private Vector3 savedPosition;
    private const string PositionKey = "PlayerPosition";

    void Start()
    {
        // Load the saved position
        LoadPlayerPosition();
    }

    void OnApplicationQuit()
    {
        // Save the position when the application quits
        SavePlayerPosition();
    }

    void OnDisable()
    {
        // Save the position when the player object is disabled (e.g., when changing scenes)
        SavePlayerPosition();
    }

    public void SavePlayerPosition()
    {
        // Save the player's position to PlayerPrefs
        PlayerPrefs.SetFloat(PositionKey + "X", transform.position.x);
        PlayerPrefs.SetFloat(PositionKey + "Y", transform.position.y);
        PlayerPrefs.SetFloat(PositionKey + "Z", transform.position.z);
        PlayerPrefs.Save();
    }

    public void LoadPlayerPosition()
    {
        // Check if the position key exists in PlayerPrefs
        if (PlayerPrefs.HasKey(PositionKey + "X") &&
            PlayerPrefs.HasKey(PositionKey + "Y") &&
            PlayerPrefs.HasKey(PositionKey + "Z"))
        {
            // Load the player's position from PlayerPrefs
            float x = PlayerPrefs.GetFloat(PositionKey + "X");
            float y = PlayerPrefs.GetFloat(PositionKey + "Y");
            float z = PlayerPrefs.GetFloat(PositionKey + "Z");
            savedPosition = new Vector3(x, y, z);
            transform.position = savedPosition;
        }
        else
        {
            // If no saved position, use the default start position
            savedPosition = transform.position;
        }
    }
}
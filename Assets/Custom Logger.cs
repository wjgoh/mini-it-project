using UnityEngine;

public class CustomLogger : MonoBehaviour
{
    public string message;

    public void Log(string message)
    {
        this.message = message;
        Debug.Log(message);
    }
}
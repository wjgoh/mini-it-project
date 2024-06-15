using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int sceneBuildIndex; // Index of the scene to switch to

    // This method will be called when the object is clicked
    public void changeScene()
    {
        Debug.Log("Attempting to load scene at index: " + sceneBuildIndex);
        SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
    }
}
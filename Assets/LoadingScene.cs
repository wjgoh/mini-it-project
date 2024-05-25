using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadingSceneB : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(LoadSceneC());
    }

    private IEnumerator LoadSceneC()
    {
        // Wait for 3 seconds
        yield return new WaitForSeconds(3f);

        // Load Scene C
        SceneManager.LoadScene(1);
    }
}

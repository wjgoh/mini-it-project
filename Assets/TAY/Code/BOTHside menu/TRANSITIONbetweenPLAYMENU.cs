using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TRANSITIONbetweenPLAYMENU : MonoBehaviour
{
    [SerializeField] RectTransform fader;


    public void OpenoutSideMenuScene()
    {
        if (fader == null)
        {
            Debug.LogError("Fader is not assigned.");
            return;
        }

        fader.gameObject.SetActive(true);

        LeanTween.scale(fader, Vector3.zero, 0f);
        LeanTween.scale(fader, new Vector3(1, 1, 1), 0.5f).setOnComplete(() => {
            SceneManager.LoadScene(0);
        });
    }

    public void OpenInsideGameScene()
    {
        if (fader == null)
        {
            Debug.LogError("Fader is not assigned.");
            return;
        }

        fader.gameObject.SetActive(true);

        LeanTween.scale(fader, Vector3.zero, 0f);
        LeanTween.scale(fader, new Vector3(1, 1, 1), 0.5f).setOnComplete(() => {
            SceneManager.LoadScene(5);
        });
    }
}


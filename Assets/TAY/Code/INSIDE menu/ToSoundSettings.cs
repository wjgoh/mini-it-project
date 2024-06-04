using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToSoundSettings : MonoBehaviour
{
  public void LaodScene()
  {
    SceneManager.LoadScene(3);
  }
}
public class ButtonHandler : MonoBehaviour
{
    public void OnButtonClick()
    {
        Debug.Log("Button clicked!");
    }
}

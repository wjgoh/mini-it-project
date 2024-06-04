using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MOREbutton : MonoBehaviour
{
  public void LaodScene()
  {
    SceneManager.LoadScene(3);
  }
}
public class MOREButtonHandler : MonoBehaviour
{
    public void ButtonClick()
    {
        Debug.Log("Button clicked!");
    }
}



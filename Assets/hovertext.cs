using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hovertext : MonoBehaviour
{
    public GameObject hoverText;
    
    
    public void Start()
    {
        hoverText.SetActive(false);
    }

    public void OnMouseOver()
    {
        hoverText.SetActive(true);
    }
    
    public void OnMouseExit()
    {
        hoverText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

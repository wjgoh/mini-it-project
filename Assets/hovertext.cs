using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverText : MonoBehaviour
{
    public GameObject hoverText;
    public Sprite defaultSprite;
    public Sprite hoverSprite;

    private SpriteRenderer spriteRenderer;

    public void Start()
    {
        hoverText.SetActive(false);
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            Debug.LogError("No SpriteRenderer found on the GameObject.");
        }
        else
        {
            spriteRenderer.sprite = defaultSprite;
        }
    }

    public void OnMouseOver()
    {
        hoverText.SetActive(true);
        if (spriteRenderer != null)
        {
            spriteRenderer.sprite = hoverSprite;
        }
    }

    public void OnMouseExit()
    {
        hoverText.SetActive(false);
        if (spriteRenderer != null)
        {
            spriteRenderer.sprite = defaultSprite;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
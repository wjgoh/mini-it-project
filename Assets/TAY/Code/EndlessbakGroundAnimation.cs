using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessBackgroundAnimation : MonoBehaviour
{
    private Material mat;
    private float distance;

    [Range(0f, 0.5f)]
    public float speed = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        // Try to get the Renderer component and its material
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            mat = renderer.material;
            if (mat == null)
            {
                Debug.LogError("Material is not assigned to the Renderer.");
            }
        }
        else
        {
            Debug.LogError("Renderer component is missing. Please add a Renderer component to the GameObject.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (mat != null)
        {
            // Increment the distance based on time and speed
            distance += Time.deltaTime * speed;
            // Update the texture offset
            mat.SetTextureOffset("_MainTex", Vector2.right * distance);
        }
    }
}



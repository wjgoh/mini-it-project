using UnityEngine;
using UnityEngine.UI;

public class ScrollBackground : MonoBehaviour
{
    public float scrollSpeedX = 0.5f; // Speed of scrolling in the X-axis
    public float scrollSpeedY = 0.5f; // Speed of scrolling in the Y-axis
    public RawImage backgroundImage;  // Reference to the RawImage component

    private Vector2 offset;

    void Start()
    {
        if (backgroundImage == null || backgroundImage.texture == null)
        {
            Debug.LogError("RawImage component or texture is not assigned!");
            return;
        }

        Debug.Log("Image Width: " + backgroundImage.texture.width);
        Debug.Log("Image Height: " + backgroundImage.texture.height);

        // Set the RawImage size to match the size of the texture
        backgroundImage.SetNativeSize();

        // Adjust the uvRect based on the size of the texture
        Rect uvRect = backgroundImage.uvRect;
        uvRect.width = 1f;
        uvRect.height = 1f / backgroundImage.mainTexture.height * backgroundImage.rectTransform.rect.height;
        backgroundImage.uvRect = uvRect;
    }

    void Update()
    {
        if (backgroundImage == null)
            return;

        float x = Mathf.Repeat(Time.time * scrollSpeedX, 1);
        float y = Mathf.Repeat(Time.time * scrollSpeedY, 1);
        offset = new Vector2(x, y);
        backgroundImage.uvRect = new Rect(offset.x, offset.y, 1, 1);
    }
}








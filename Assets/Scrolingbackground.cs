using UnityEngine;
using UnityEngine.UI;

public class ScrollingBackground : MonoBehaviour
{
    [SerializeField] private RawImage _img;
    [SerializeField] private float _x, _y;

    void Update()
    {
        // Calculate the new UV offset based on time and scroll speed
        float offsetX = _x * Time.deltaTime;
        float offsetY = _y * Time.deltaTime;

        // Apply the new UV offset to the RawImage
        _img.uvRect = new Rect(_img.uvRect.position + new Vector2(offsetX, offsetY), _img.uvRect.size); 
    }
}


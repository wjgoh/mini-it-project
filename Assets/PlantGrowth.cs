using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantGrowth : MonoBehaviour
{
    public float growthDuration = 5f;
    public Vector3 finalScale = new Vector3(2f, 2f, 2f);
    private Vector3 initialScale;

    private void Start()
    {
        initialScale = transform.localScale;
    }

    public void StartGrowing()
    {
        StartCoroutine(Grow());
    }

    private IEnumerator Grow()
    {
        float elapsedTime = 0f;
        while (elapsedTime < growthDuration)
        {
            transform.localScale = Vector3.Lerp(initialScale, finalScale, elapsedTime / growthDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.localScale = finalScale;
    }
}

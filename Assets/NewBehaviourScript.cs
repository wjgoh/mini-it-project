using System.Collections;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject tomatoPlant1;
    public GameObject tomatoPlant2;
    public GameObject matureTomatoPlant; // The sprite for the mature plant

    public float growthRate = 0.01f; // The rate at which the plant grows
    public float maxScale = 2f; // The maximum size of the plant

    void Update()
    {
        // Grow the plants over time
        GrowPlant1(tomatoPlant1);
        if (tomatoPlant1 == null)
        {
            GrowPlant(tomatoPlant2);
        }
    }

    void GrowPlant(GameObject plant)
    {
        if (plant.transform.localScale.x < maxScale)
        {
            // If the plant hasn't reached its maximum size, grow it
            plant.transform.localScale += new Vector3(growthRate, growthRate, growthRate) * Time.deltaTime;
        }
        else
        {
            // If the plant has reached its maximum size, replace it with the mature plant
            Vector3 position = plant.transform.position;
            Destroy(plant);
            Instantiate(tomatoPlant2, position, Quaternion.identity);
        }
    }

    // grow the second plant after first plant has reached max size
    void GrowPlant1(GameObject plant)
    {
        if (plant.transform.localScale.x < maxScale)
        {
            // If the plant hasn't reached its maximum size, grow it
            plant.transform.localScale += new Vector3(growthRate, growthRate, growthRate) * Time.deltaTime;
        }
        else
        {
            // If the plant has reached its maximum size, replace it with the mature plant
            Vector3 position = plant.transform.position;
            Destroy(plant);
            Instantiate(matureTomatoPlant, position, Quaternion.identity);
        }
    }
}
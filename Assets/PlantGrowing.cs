using System.Collections;
using UnityEngine;

public class PlantGrowing : MonoBehaviour
{
    public GameObject tomatoPlant1;
    public GameObject tomatoPlant2;
    public GameObject tomatoPlant3; // New plant
    public GameObject matureTomatoPlant;

    public float growthRate = 0.01f;
    public float maxScale = 2f;

    private GameObject currentPlant;

    private enum GrowthStage { Stage1, Stage2, Stage3, Mature } // New stage
    private GrowthStage currentStage;

    void Start()
    {
        currentPlant = tomatoPlant1;
        currentStage = GrowthStage.Stage1;
        StartCoroutine(GrowPlant());
    }

    public IEnumerator GrowPlant()
    {
        while (true)
        {
            if (currentPlant.transform.localScale.x < maxScale)
            {
                currentPlant.transform.localScale += new Vector3(growthRate, growthRate, growthRate) * Time.deltaTime;
            }
            else
            {
                GameObject nextPlant = null;
                switch (currentStage)
                {
                    case GrowthStage.Stage1:
                        nextPlant = tomatoPlant2;
                        currentStage = GrowthStage.Stage2;
                        break;
                    case GrowthStage.Stage2:
                        nextPlant = tomatoPlant3; // New plant
                        currentStage = GrowthStage.Stage3; // New stage
                        break;
                    case GrowthStage.Stage3: // New stage
                        nextPlant = matureTomatoPlant;
                        currentStage = GrowthStage.Mature;
                        break;
                    case GrowthStage.Mature:
                        yield break;
                }

                Vector3 position = currentPlant.transform.position;
                Destroy(currentPlant);
                currentPlant = Instantiate(nextPlant, position, Quaternion.identity);
            }

            yield return null;
        }
    }
}
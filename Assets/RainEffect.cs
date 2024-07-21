using System.Collections;
using UnityEngine;

public class RainController : MonoBehaviour
{
    public ParticleSystem rainParticleSystem; 

    void Start()
    {
        rainParticleSystem.Stop();
        StartCoroutine(RainCycle());
    }

    IEnumerator RainCycle()
    {
        while (true)
        {
            
            float timeBeforeRain = Random.Range(20f, 200f);
            yield return new WaitForSeconds(timeBeforeRain);

            
            rainParticleSystem.Play();

            
            float rainDuration = Random.Range(30f, 60f);
            yield return new WaitForSeconds(rainDuration);

            rainParticleSystem.Stop();
        }
    }
}



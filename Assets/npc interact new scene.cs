using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class npcinteractnewscene : MonoBehaviour
{
    public Dialogue dialogueScript;
    public int sceneNumber;
    public Vector2 playerPosition; // Add this line
    private bool playerDetected;
    public CustomLogger customLogger;
    private taskanimationscript taskAnimationScript; // Reference to the taskanimationscript
    public bool visitedTutorialWorld { get; set; }


    // Start is called before the first frame update
    void Start()
    {
        // Find the taskanimationscript in the scene (adjust as necessary)
        taskAnimationScript = FindObjectOfType<taskanimationscript>();

        // Alternatively, you can set it via the Inspector if you prefer
        // taskAnimationScript = taskAnimationGameObject.GetComponent<taskanimationscript>();
    }

    // Detect trigger with player
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If we trigger the player, enable playerDetected and show indicator
        if (collision.tag == "Player")
        {
            playerDetected = true;
            dialogueScript.ToggleIndicator(playerDetected);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // If we lose trigger with the player, disable playerDetected and hide indicator
        if (collision.tag == "Player")
        {
            playerDetected = false;
            dialogueScript.ToggleIndicator(playerDetected);
            dialogueScript.EndDialogue();
        }
    }

    // While detected, if we interact, start the dialogue
    private void Update()
    {
        if (playerDetected && Input.GetKeyDown(KeyCode.Q))
        {
            // Save the player's position
            PlayerPrefs.SetFloat("PlayerPosX", playerPosition.x);
            PlayerPrefs.SetFloat("PlayerPosY", playerPosition.y);
            Debug.Log("visits tutorial world");
            visitedTutorialWorld = true;


            // Call task2done() if the script reference is set
            if (taskAnimationScript != null)
            {
                taskAnimationScript.task2done();
            }
            else
            {
                Debug.Log("taskanimationscript not found!");
            }

            StartCoroutine(LoadSceneAfterDelay(sceneNumber, 0.2f));
        }
    }

    private IEnumerator LoadSceneAfterDelay(int sceneNumber, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneNumber);
    }
}

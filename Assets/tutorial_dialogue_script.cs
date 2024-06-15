using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class tutorial_dialogue_script : MonoBehaviour
{
    [System.Serializable]
    public class EmoteDialogue
    {
        public GameObject emote;
        public string dialogue;
    }

    public List<EmoteDialogue> emoteDialogues; // List of EmoteDialogue objects

    private TMP_Text textMesh;
    private int index = 0; // Index to keep track of the current EmoteDialogue

    void Start()
    {
        textMesh = GetComponentInChildren<TMP_Text>();
        PlayDialogue();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayDialogue();
        }
    }

    void PlayDialogue()
    {
        // Check if there are any EmoteDialogue objects left
        if (index < emoteDialogues.Count)
        {
            // Get the current EmoteDialogue
            EmoteDialogue current = emoteDialogues[index];

            // Deactivate all emotes
            foreach (EmoteDialogue ed in emoteDialogues)
            {
                ed.emote.SetActive(false);
            }

            // Activate the current emote
            current.emote.SetActive(true);

            // Display the current dialogue
            textMesh.text = current.dialogue;

            // Increment the index
            index++;
        }
    }
}
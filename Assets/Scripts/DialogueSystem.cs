using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueSystem : MonoBehaviour
{
    public TMP_Text dialogueText;
    public GameObject dialogueBox;
    public string[] dialogueStrings;
    public string playerTag = "Player";
    public float distanceThreshold = 3f; // Adjust as needed
    private int currentDialogueIndex = 0;
    private GameObject player;

    public GameObject newButton;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag(playerTag);
        newButton.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (IsPlayerClose() && !dialogueBox.activeSelf)
            {
                StartDialogue();
            }
            else
            {
                ShowNextDialogue();
            }
        }
    }

    bool IsPlayerClose()
    {
        if (player != null)
        {
            float distance = Vector3.Distance(player.transform.position, transform.position);
            return distance <= distanceThreshold;
        }
        return false;
    }

    void StartDialogue()
    {
        dialogueBox.SetActive(true);
        ShowNextDialogue();
    }

    void ShowNextDialogue()
    {
        if (currentDialogueIndex < dialogueStrings.Length)
        {
            dialogueText.text = dialogueStrings[currentDialogueIndex];
            currentDialogueIndex++;
        }
        else
        {
            EndDialogue();
            newButton.SetActive(true);
        }
    }

    void EndDialogue()
    {
        dialogueBox.SetActive(false);
        currentDialogueIndex = 0;
    }
}

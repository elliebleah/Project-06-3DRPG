using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameLogic : MonoBehaviour
{
    public GameObject rockButton;
    public GameObject paperButton;
    public GameObject scissorsButton;
    public GameObject hammerGameObject;
    public GameObject bowlGameObject;
    public string selection;

    public bool stage1, stage2;
    public string aiSelection;
    //public ThirdPersonController tpc;
    private void Start()
    {
        ResetGame();
        stage1=true;
        stage2= false;
        aiSelection = GetAISelection();
        //tpc.enabled = false;
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.R) && stage1)
        {
            selection = "Rock";
            stage1 = false;
            stage2 = true;
        }
        if (Input.GetKeyDown(KeyCode.P)  && stage1)
        {
            selection = "Paper";
            stage1 = false;
            stage2 = true;
        }
        if (Input.GetKeyDown(KeyCode.Z) && stage1)
        {
            selection = "Scissors";
            stage1 = false;
            stage2 = true;
        }

        if (stage2)
        {
            SelectPlayerOption();
             Debug.Log("AI selected: " + aiSelection);
        // Determine the winner
            string playerSelection = selection;
            if (playerSelection == aiSelection)
            {
                // It's a tie or player didn't select in time
                Debug.Log("It's a tie or you didn't select in time!");
            }
            else if ((playerSelection == "Rock" && aiSelection == "Scissors") ||
                    (playerSelection == "Paper" && aiSelection == "Rock") ||
                    (playerSelection == "Scissors" && aiSelection == "Paper"))
            {
                // Player wins
                Debug.Log("Player wins!");
                hammerGameObject.SetActive(false);
                bowlGameObject.SetActive(false);
            }
            else
            {
                // AI wins
                Debug.Log("AI wins!");
                hammerGameObject.SetActive(false);
                bowlGameObject.SetActive(false);
            }
            
        }
       
    }
    void SelectPlayerOption()
    {
        // Disable buttons
        rockButton.SetActive(false);
        paperButton.SetActive(false);
        scissorsButton.SetActive(false);
        // Stop the countdown
        StopAllCoroutines();
        // Set player's selection
        Debug.Log("Player selected: " + selection);
        // Start showing AI's selection

    }

    string GetAISelection()
    {
        // Implement AI selection logic here
        string[] options = { "Rock", "Paper", "Scissors" };
        int randomIndex = Random.Range(0, options.Length);
        return options[randomIndex];
    }


    void ResetGame()
    {
        // Reset UI
        // Enable buttons
        rockButton.SetActive(true);
        paperButton.SetActive(true);
        scissorsButton.SetActive(true);
        // Disable game objects
        hammerGameObject.SetActive(false);
        bowlGameObject.SetActive(false);
    }
}

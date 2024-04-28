using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
    public string targetScene; // The target scene to load

    void Start()
    {
        // Find the Button component on the GameObject this script is attached to
        Button button = GetComponent<Button>();

        // Add a listener to the button's onClick event
        button.onClick.AddListener(ChangeScene);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            ChangeScene();
        }
    }

    // Function to change the scene to the specified target scene
    void ChangeScene()
    {
        SceneManager.LoadScene(targetScene);
    }
}
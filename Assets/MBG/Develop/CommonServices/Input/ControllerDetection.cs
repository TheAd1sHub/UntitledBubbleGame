using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerDetection : MonoBehaviour
{
    public GameObject pressSpaceToStartMessage; // Updated message to reflect Space instead of A

    private Gamepad gamepad;

    void Update()
    {
        gamepad = Gamepad.current;

        if (gamepad != null)
        {
            // Show the message when a gamepad is connected
            pressSpaceToStartMessage?.SetActive(true);

            // Detect "A" button press (Space equivalent on Xbox controllers)
            if (gamepad.buttonSouth.wasPressedThisFrame) // "South" is the "A" button on Xbox controllers
            {
                StartGame();
            }
        }
        else
        {
            // Hide the message if no gamepad is connected
            pressSpaceToStartMessage?.SetActive(false);
        }
    }

    void StartGame()
    {
        Debug.Log("Game Started!");
        UnityEngine.SceneManagement.SceneManager.LoadScene("CustomizationMenu");
    }
}

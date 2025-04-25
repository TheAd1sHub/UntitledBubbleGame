using UnityEngine;

public class WinOnTouch : MonoBehaviour
{
    public string playerTag = "Player"; // Tag for the bubble player

    void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger is the player
        if (other.CompareTag(playerTag))
        {
            //Debug.Log("You Win!");
            WinGame();
        }
    }

    void WinGame()
    {
        // Add your win logic here
        // Example: Load the next scene or display a victory screen
        Debug.Log("Congratulations, you've won!");

        // Example: Restart the scene
        // UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);

        UnityEngine.SceneManagement.SceneManager.LoadScene("VictoryScreen");
    }
}

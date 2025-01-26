using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Camera Settings")]
    public Transform player; // Reference to the player (bubble)
    public Vector3 offset = new Vector3(0f, 2f, -5f); // Offset position from the player
    public float smoothSpeed = 5f; // Speed of camera movement
    public float rotationSpeed = 5f; // Speed of camera rotation
    public float maxPitch = 30f; // Maximum up/down angle

    private float pitch = 0f; // Current vertical rotation angle

    void LateUpdate()
    {
        if (player == null)
        {
            Debug.LogError("Player reference is missing in CameraController!");
            return;
        }

        float verticalInput = Input.GetAxis("Vertical");

        pitch -= verticalInput * rotationSpeed * Time.deltaTime;

        pitch = Mathf.Clamp(pitch, -maxPitch, maxPitch);

        Vector3 desiredPosition = player.position + offset;

        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        transform.LookAt(player.position + Vector3.up * offset.y);
    }
}

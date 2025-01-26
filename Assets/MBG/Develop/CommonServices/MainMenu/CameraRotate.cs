using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public float rotationSpeed = 10f; // Speed of the rotation

    void Update()
    {
        // Rotate the camera around its Y-axis
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
}
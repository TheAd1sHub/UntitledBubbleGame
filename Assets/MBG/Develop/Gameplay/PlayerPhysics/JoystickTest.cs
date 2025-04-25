using UnityEngine;

public class JoystickTest : MonoBehaviour
{
    [SerializeField] private bl_Joystick joystick;

    void Update()
    {
        Debug.Log("Joystick Horizontal: " + joystick.Horizontal);
        Debug.Log("Joystick Vertical: " + joystick.Vertical);
    }
}
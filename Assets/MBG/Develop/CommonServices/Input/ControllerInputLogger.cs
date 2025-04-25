using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class ControllerInputLogger : MonoBehaviour
{
    private Gamepad gamepad;

    void Update()
    {
        gamepad = Gamepad.current;
        if (gamepad == null) return;

        // Check all standard gamepad buttons
        CheckButtonPress(gamepad.buttonSouth, "A (joystick button 0)");
        CheckButtonPress(gamepad.buttonEast, "B (joystick button 1)");
        CheckButtonPress(gamepad.buttonWest, "X (joystick button 2)");
        CheckButtonPress(gamepad.buttonNorth, "Y (joystick button 3)");
        CheckButtonPress(gamepad.startButton, "Start (joystick button 7)");
        CheckButtonPress(gamepad.selectButton, "Back (joystick button 6)");
        CheckButtonPress(gamepad.leftShoulder, "Left Bumper (joystick button 4)");
        CheckButtonPress(gamepad.rightShoulder, "Right Bumper (joystick button 5)");
        CheckButtonPress(gamepad.leftStickButton, "Left Stick Click (joystick button 8)");
        CheckButtonPress(gamepad.rightStickButton, "Right Stick Click (joystick button 9)");
        CheckButtonPress(gamepad.dpad.up, "D-Pad Up");
        CheckButtonPress(gamepad.dpad.down, "D-Pad Down");
        CheckButtonPress(gamepad.dpad.left, "D-Pad Left");
        CheckButtonPress(gamepad.dpad.right, "D-Pad Right");

        // Check triggers
        if (gamepad.leftTrigger.wasPressedThisFrame)
            Debug.Log("Left Trigger (L2) pressed");
        if (gamepad.rightTrigger.wasPressedThisFrame)
            Debug.Log("Right Trigger (R2) pressed");
    }

    void CheckButtonPress(ButtonControl button, string buttonName)
    {
        if (button.wasPressedThisFrame)
        {
            Debug.Log(buttonName + " was pressed");
        }
    }
}

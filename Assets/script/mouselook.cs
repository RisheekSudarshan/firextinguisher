using UnityEngine;

public class mouselook : MonoBehaviour
{
    public float Sensitivity = 100f;
    public float buttonTurnSpeed = 90f; // degrees per second
    public Transform FirstPersonCharacter;

    float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // --------------------
        // MOUSE LOOK
        // --------------------
        float mouseX = Input.GetAxis("Mouse X") * Sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * Sensitivity * Time.deltaTime;

        // Pitch (look up/down)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Yaw from mouse (turn left/right)
        if (FirstPersonCharacter != null)
        {
            FirstPersonCharacter.Rotate(Vector3.up * mouseX);
        }

        // --------------------
        // BUTTON TURN (PS CONTROLLER)
        // --------------------
        float buttonTurn = 0f;

        // Square → turn left
        if (Input.GetKey(KeyCode.JoystickButton0))
        {
            Debug.Log("Left Turn");
            buttonTurn -= 1f;
        }

        // Circle → turn right
        if (Input.GetKey(KeyCode.JoystickButton2))
        {
            buttonTurn += 1f;
        }

        if (buttonTurn != 0f && FirstPersonCharacter != null)
        {
            FirstPersonCharacter.Rotate(Vector3.up * buttonTurn * buttonTurnSpeed * Time.deltaTime);
        }
    }
}

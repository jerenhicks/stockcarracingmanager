using UnityEngine;
using UnityEngine.InputSystem; // <- new input system

public class FlyCamera : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float sprintMultiplier = 3f;
    public float lookSpeed = 2f;

    private float yaw;
    private float pitch;

    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        yaw = angles.y;
        pitch = angles.x;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        var keyboard = Keyboard.current;
        var mouse = Mouse.current;

        if (keyboard == null || mouse == null)
            return; // no input devices

        // --- Mouse look ---
        Vector2 mouseDelta = mouse.delta.ReadValue();
        float mouseX = mouseDelta.x * lookSpeed * Time.deltaTime;
        float mouseY = mouseDelta.y * lookSpeed * Time.deltaTime;

        yaw += mouseX;
        pitch -= mouseY;
        pitch = Mathf.Clamp(pitch, -80f, 80f);
        transform.rotation = Quaternion.Euler(pitch, yaw, 0f);

        // --- Movement ---
        float speed = moveSpeed;
        if (keyboard.leftShiftKey.isPressed)
            speed *= sprintMultiplier;

        Vector3 move = Vector3.zero;

        if (keyboard.wKey.isPressed) move += transform.forward;
        if (keyboard.sKey.isPressed) move -= transform.forward;
        if (keyboard.dKey.isPressed) move += transform.right;
        if (keyboard.aKey.isPressed) move -= transform.right;

        if (keyboard.eKey.isPressed) move += transform.up;
        if (keyboard.qKey.isPressed) move -= transform.up;

        transform.position += move.normalized * speed * Time.deltaTime;

        // Unlock cursor with ESC
        if (keyboard.escapeKey.wasPressedThisFrame)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}

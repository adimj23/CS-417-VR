using UnityEngine;
using UnityEngine.InputSystem;

public class ExternalViewScript : MonoBehaviour
{
    public Transform externalViewPoint;

    private Vector3 roomPosition;
    private Quaternion roomRotation;
    private bool isInRoom = true;

    void Start()
    {
        roomPosition = transform.position;
        roomRotation = transform.rotation;
    }

    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            ToggleView();
        }

        if (Gamepad.current != null && Gamepad.current.buttonSouth.wasPressedThisFrame)
        {
            ToggleView();
        }
    }

    void ToggleView()
    {
        if (isInRoom)
        {
            transform.position = externalViewPoint.position;
            transform.rotation = externalViewPoint.rotation;
        }
        else
        {
            transform.position = roomPosition;
            transform.rotation = roomRotation;
        }

        isInRoom = !isInRoom;
    }
}
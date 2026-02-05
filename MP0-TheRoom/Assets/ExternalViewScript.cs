using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;

public class ExternalViewScript : MonoBehaviour
{
    public Transform externalViewPoint;
    public Transform cameraOffset;
    
    public InputActionReference primaryButtonAction;

    private Vector3 roomPosition;
    private Quaternion roomRotation;
    private bool isInRoom = true;

    void Start()
    {
        roomPosition = transform.position;
        roomRotation = transform.rotation;

        primaryButtonAction.action.Enable();
        primaryButtonAction.action.performed += ctx => ToggleView();
    }

    void Update()
    {
        if (Keyboard.current.digit8Key.wasPressedThisFrame)
        {
            ToggleView();
        }

        UnityEngine.XR.InputDevice rightHand = UnityEngine.XR.InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
        if (rightHand.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primaryButton, out bool primaryPressed) && primaryPressed)
        {
            ToggleView();
        }
    }

    void ToggleView()
    {
        // if (isInRoom)
        // {
        //     transform.position = externalViewPoint.position;
        //     transform.rotation = externalViewPoint.rotation;
        // }
        // else
        // {
        //     transform.position = roomPosition;
        //     transform.rotation = roomRotation;
        // }
        if (isInRoom)
            cameraOffset.position = externalViewPoint.position;
        else
            cameraOffset.position = roomPosition;

        isInRoom = !isInRoom;
    }
}
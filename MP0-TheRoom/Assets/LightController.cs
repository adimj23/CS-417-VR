using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;

public class LightController : MonoBehaviour
{
    public Light light;

    private Color originalColor;
    private bool isRed = false;

    void Start()
    {
        light = GetComponent<Light>();
        originalColor = light.color;
    }

    void Update()
    {
        if (Keyboard.current.digit3Key.wasPressedThisFrame)
        {
            ToggleLight();
        }

        // XR input: left-hand primary button (X button)
        UnityEngine.XR.InputDevice leftHand = UnityEngine.XR.InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
        if (leftHand.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primaryButton, out bool primaryPressed) && primaryPressed)
        {
            ToggleLight();
        }
    }

    private void ToggleLight()
    {
        if (isRed)
        {
            light.color = originalColor;
            isRed = false;
        }
        else
        {
            light.color = Color.red;
            isRed = true;
        }
    }
}

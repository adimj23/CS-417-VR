using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;

public class Quit : MonoBehaviour
{
    private bool bButtonLastFrame = false;

    void Update()
    {

        if (Keyboard.current.digit2Key.wasPressedThisFrame)
        {
            QuitGame();
        }

        // Check XR right-hand controller B button (secondary button)
        UnityEngine.XR.InputDevice rightHand = UnityEngine.XR.InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
        if (rightHand.TryGetFeatureValue(UnityEngine.XR.CommonUsages.secondaryButton, out bool secondaryPressed))
        {
            if (secondaryPressed && !bButtonLastFrame)
            {
                QuitGame();
            }
            bButtonLastFrame = secondaryPressed;
        }

        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            QuitGame();
        }
    }

    private void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
        Debug.Log("Quit triggered");
    }
}

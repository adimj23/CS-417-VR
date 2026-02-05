using UnityEngine;
using UnityEngine.InputSystem;

public class LightController : MonoBehaviour
{

    public Light light;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        light = GetComponent<Light>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.tabKey.wasPressedThisFrame) {
            light.color = Color.red;
        }
        
    }
}

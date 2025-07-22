using UnityEngine;
using UnityEngine.XR.OpenXR.Input;

public class InputTesting : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.One)){
            UnityEngine.Debug.Log("FUCK YESSSSSSS");
        }
    }
}

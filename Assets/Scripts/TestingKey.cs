using UnityEngine;
using OVRTouchSample;

public class TestingKey : MonoBehaviour
{
    public GameObject tester;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.Two)) {
            Instantiate(tester, new Vector3(0, 5, 0),Quaternion.identity);
        }
    }
}

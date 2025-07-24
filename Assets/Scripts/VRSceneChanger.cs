using UnityEngine;
using UnityEngine.SceneManagement;

public class VRSceneChanger : MonoBehaviour
{

    public void LoadScene()
    {
        SceneManager.LoadScene(2);
        Debug.Log("Button works");
    }
}

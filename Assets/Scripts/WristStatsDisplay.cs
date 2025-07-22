using TMPro;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    private InventorySystem weight;
    public TextMeshProUGUI invText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        weight = GetComponent<InventorySystem>();
    }

    // Update is called once per frame
    void Update()
    {
        invText.text = "Weight: " + weight.haulWeight + "/100";
    }
}
 
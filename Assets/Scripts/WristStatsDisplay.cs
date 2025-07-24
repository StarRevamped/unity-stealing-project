using TMPro;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    private InventorySystem weight;
    public TextMeshProUGUI invText;

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        weight = player.GetComponent<InventorySystem>();
    }

    void Update()
    {
        if (weight != null)
        {
            invText.text = "Weight: " + weight.GetHaulWeight().ToString() + "/100";
        }
    }
}
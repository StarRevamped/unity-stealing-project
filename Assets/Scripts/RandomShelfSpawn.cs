using UnityEngine;

public class RandomShelfSpawn : MonoBehaviour
{
    private GameObject[] spawnableObjects;
    public GameObject[] spawningLocations;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnableObjects = GameObject.FindGameObjectsWithTag("StorableObjects");
    }
    // Update is called once per frame
        void Update()
    {
        
    }
}

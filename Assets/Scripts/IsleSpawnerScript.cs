using UnityEngine;

public class IsleSpawnerScript : MonoBehaviour
{
    private readonly System.Random rnd = new();
    private GameObject[] spawningLocations;
    private GameObject[] aisles;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawningLocations = GameObject.FindGameObjectsWithTag("AisleSpawner");
        aisles = GameObject.FindGameObjectsWithTag("aisle");
        foreach (GameObject location in spawningLocations)
        {
            int randInt = rnd.Next(aisles.Length);
            Instantiate(aisles[randInt], location.transform.position, location.transform.rotation);
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

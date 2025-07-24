using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class chasecodetest : MonoBehaviour
{
    public Transform transformToFollow;
    //NavMesh Agent variable
    NavMeshAgent agent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = transformToFollow.position;
    }
}

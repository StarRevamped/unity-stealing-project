using Oculus.Interaction.DebugTree;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class detection : MonoBehaviour
{
    public Material VisionConeMaterial;
    public float VisionRange;
    public float VisionAngle;
    public LayerMask VisionObstructingLayer;
    public LayerMask playerLayer;
    public int VisionConeResolution = 120;
    Mesh VisionConeMesh;
    MeshFilter MeshFilter_;
    public double detectMin;
    public double detectPerSec;
    public double detectionLevel;
    public double detectMax;
    public Transform transformToFollow;
    //NavMesh Agent variable
    NavMeshAgent agent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        transform.AddComponent<MeshRenderer>().material = VisionConeMaterial;
        MeshFilter_ = transform.AddComponent<MeshFilter>();
        VisionConeMesh = new Mesh();
        VisionAngle *= Mathf.Deg2Rad;
    }

    // Update is called once per frame
    void Update()
    {
        DrawVisionCone();
        if (detectionLevel >= detectMax)
        {
            agent.destination = transformToFollow.position;
        }
    }

   
    void DrawVisionCone()//this method creates the vision cone mesh
    {
        int[] triangles = new int[(VisionConeResolution - 1) * 3];
        Vector3[] Vertices = new Vector3[VisionConeResolution + 1];
        Vertices[0] = Vector3.zero;
        float Currentangle = -VisionAngle / 2;
        float angleIcrement = VisionAngle / (VisionConeResolution - 1);
        float Sine;
        float Cosine;

        for (int i = 0; i < VisionConeResolution; i++)
        {
            Sine = Mathf.Sin(Currentangle);
            Cosine = Mathf.Cos(Currentangle);
            Vector3 RaycastDirection = (transform.forward * Cosine) + (transform.right * Sine);
            Vector3 VertForward = (Vector3.forward * Cosine) + (Vector3.right * Sine);
            if (Physics.Raycast(transform.position, RaycastDirection, out RaycastHit hit, VisionRange, VisionObstructingLayer))
            {
                Vertices[i + 1] = VertForward * hit.distance;
            }
            else
            {
                Vertices[i + 1] = VertForward * VisionRange;
            }

            if (Physics.Raycast(transform.position, RaycastDirection, out RaycastHit intersect, VisionRange, playerLayer))
            {
                if (GameObject.FindGameObjectWithTag("Player").GetComponent<InventorySystem>().GetHaulWeight() >= detectMin)
                {
                    detectionLevel += detectPerSec;
                }
                if (GameObject.FindGameObjectWithTag("Player").GetComponent<InventorySystem>().GetJustAddedToInv())
                {
                    detectionLevel += 10;
                }
            }
            else
            {
                detectionLevel -= (detectPerSec/10);
            }
                Currentangle += angleIcrement;
        }
        for (int i = 0, j = 0; i < triangles.Length; i += 3, j++)
        {
            triangles[i] = 0;
            triangles[i + 1] = j + 1;
            triangles[i + 2] = j + 2;
        }
        VisionConeMesh.Clear();
        VisionConeMesh.vertices = Vertices;
        VisionConeMesh.triangles = triangles;
        MeshFilter_.mesh = VisionConeMesh;
    }

    public double GetDetection()
    {
        return detectionLevel;
    }
}

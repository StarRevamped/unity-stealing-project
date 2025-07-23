using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "DetectionMaybe", story: "[self] detects [player] changing [detectionLevel]", category: "Action", id: "d7dd5e15c4a8b785f4eb569e61ef4c6f")]
public partial class DetectionMaybeAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<GameObject> Player;
    [SerializeReference] public BlackboardVariable<double> DetectionLevel;
    protected override Status OnStart()
    {
        return Status.Running;

    }

    protected override Status OnUpdate()
    {
        DetectionLevel.ObjectValue = GameObject.FindGameObjectWithTag("visionCone").GetComponent<detection>().GetDetection();
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}


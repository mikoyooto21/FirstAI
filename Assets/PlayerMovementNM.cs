using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Unity.AI.Navigation;

public class PlayerMovementNM : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform greenZone;
    public NavMeshSurface surface;

    void OnEnable()
    {
        greenZone = FindAnyObjectByType<Finish>().transform;
        surface = FindAnyObjectByType<NavMeshSurface>();
        surface.RemoveData();
        surface.BuildNavMesh();
        //agent.SetDestination(greenZone.position);
    }

    private void Update() {
        agent.destination = greenZone.position;
    }
}

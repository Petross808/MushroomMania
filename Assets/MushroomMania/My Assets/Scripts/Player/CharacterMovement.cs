using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class CharacterMovement : MonoBehaviour
{
    private NavMeshAgent _agent;
    [SerializeField] private float _speed;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    } 

    public void GoToPosition(Vector3 position)
    {
        _agent.SetDestination(position);
        _agent.speed = _speed;
        _agent.isStopped = false;
    }

    public void Stop()
    {
        _agent.isStopped = true;
    }
}

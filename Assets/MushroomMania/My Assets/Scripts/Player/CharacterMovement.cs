using EventSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class CharacterMovement : MonoBehaviour
{
    private NavMeshAgent _agent;
    [SerializeField] private float _speed;
    [SerializeField] GameEvent _onCharacterRun;
    [SerializeField] GameEvent _onCharacterStop;

    private bool _idleLastTick;

    private Vector3 _startingPos;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _startingPos = transform.position;
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

    public void Tick()
    {
        bool isIdle = _agent.velocity == Vector3.zero;
        if (isIdle != _idleLastTick)
        {
            if(isIdle)
            {
                _onCharacterStop?.Raise();
            }
            else
            {
                _onCharacterRun?.Raise();
            }
        }

        _idleLastTick = isIdle;
    }

    public void Restart()
    {
        Stop();
        _agent.Warp(_startingPos);
    }
}

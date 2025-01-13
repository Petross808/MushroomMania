using EventSystem;
using System;
using System.Collections.Generic;
using UnityEngine;

// File from a previous project that I wrote https://github.com/Petross808/MazeEscapeUDP

namespace Tick
{
    public class TickSystem : MonoBehaviour
    {
        [SerializeField] private float _tickTime;
        [SerializeField] private List<TickEvent> _tickEvents;

        private float _timer;
        private int _ticks;
        private int _maxTicks;

        void Awake()
        {
            _timer = 0;
            _maxTicks = 1;

            foreach (TickEvent e in _tickEvents)
            {
                if (_maxTicks % e.TickAmount != 0)
                    _maxTicks *= e.TickAmount;
            }
        }

        void Update()
        {
            _timer += Time.deltaTime;

            if (_timer > _tickTime)
            {
                Tick();
                _timer -= _tickTime;
            }
        }

        private void Tick()
        {
            _ticks++;

            foreach (TickEvent e in _tickEvents)
            {
                if (_ticks % e.TickAmount == 0)
                {
                    e.GameEvent?.Raise();
                }
            }

            if (_ticks >= _maxTicks)
            {
                _ticks = 0;
            }
        }

        [Serializable]
        struct TickEvent
        {
            [Min(1)] public int TickAmount;
            public GameEvent GameEvent;
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MYR
{
    public class EnemyAi : MonoBehaviour
    {
        private EnemyMotion enemyMotion;
        private PlayerDetector playerDetector;

        private Dictionary<Type, BaseState> availableStates;
        private BaseState currentState;

        private void Awake()
        {
            enemyMotion = GetComponent<EnemyMotion>();
            playerDetector = GetComponent<PlayerDetector>();
            SetupStateDictionary();
            InitState();
        }

        private void SetupStateDictionary()
        {
            availableStates = new Dictionary<Type, BaseState>();
            availableStates.Add(typeof(WanderState), new WanderState(enemyMotion, playerDetector));
        }

        private void InitState()
        {
            currentState = availableStates[typeof(WanderState)];
        }

        private void Update()
        {
            BaseState nextState = currentState.Tick();

            if (nextState == null)
            {
                return;
            }

            currentState = nextState;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MYR
{
    public class EnemyAi : MonoBehaviour
    {
        private AnimatorHandler animatorHandler;
        private EnemyMotion enemyMotion;
        private PlayerDetector playerDetector;

        private Dictionary<Type, BaseState> availableStates;
        private BaseState currentState;

        private void Awake()
        {
            animatorHandler = GetComponentInChildren<AnimatorHandler>();
            enemyMotion = GetComponent<EnemyMotion>();
            playerDetector = GetComponent<PlayerDetector>();
            SetupStateDictionary();
            InitState();
        }

        private void SetupStateDictionary()
        {
            availableStates = new Dictionary<Type, BaseState>();
            availableStates.Add(typeof(WanderState), new WanderState(enemyMotion, playerDetector));
            availableStates.Add(typeof(ChaseState), new ChaseState(enemyMotion, playerDetector));
            availableStates.Add(typeof(ApproachState), new ApproachState(enemyMotion, playerDetector));
            availableStates.Add(typeof(DodgeState), new DodgeState(animatorHandler, enemyMotion));
        }

        private void InitState()
        {
            currentState = availableStates[typeof(WanderState)];
        }

        private void Update()
        {
            Type nextState = currentState.Tick();

            if (nextState == null)
            {
                return;
            }

            currentState = availableStates[nextState];
        }
    }
}

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
        private EnemyAttacker enemyAttacker;

        private Dictionary<Type, BaseState> availableStates;
        private BaseState currentState;

        private void Awake()
        {
            animatorHandler = GetComponentInChildren<AnimatorHandler>();
            enemyMotion = GetComponent<EnemyMotion>();
            playerDetector = GetComponent<PlayerDetector>();
            enemyAttacker = GetComponent<EnemyAttacker>();
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
            availableStates.Add(typeof(TauntState), new TauntState(animatorHandler));
            availableStates.Add(typeof(AttackState), new AttackState(animatorHandler, enemyAttacker));
            availableStates.Add(typeof(RetreatState), new RetreatState(animatorHandler, enemyMotion, playerDetector));
            availableStates.Add(typeof(IdleState), new IdleState(animatorHandler, enemyMotion, playerDetector));
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

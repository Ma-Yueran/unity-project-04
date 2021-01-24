using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MYR
{
    public class EnemyManager : MonoBehaviour
    {
        public static EnemyManager instance;

        public Transform[] enemies;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(instance);
            }
        }
    }
}

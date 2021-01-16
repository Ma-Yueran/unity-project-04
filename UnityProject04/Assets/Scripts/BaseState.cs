using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MYR
{
    public abstract class BaseState
    {
        public abstract BaseState Tick();
    }
}

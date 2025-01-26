#define TEST_IMPLEMENTATION

using System;
using UnityEngine;

namespace Assets.MBG.Develop.PlayerPhysics
{
    public interface IInputHandler
    {
        public event Action<Vector3> MovedHorizontally;
    }
}

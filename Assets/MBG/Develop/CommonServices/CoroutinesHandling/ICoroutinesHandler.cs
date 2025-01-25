using System.Collections;
using UnityEngine;

namespace Assets.MBG.Develop.CommonServices.CoroutinesHandling
{
    public interface ICoroutinesHandler
    {
        public Coroutine StartRoutine(IEnumerator coroutine);
        public void StopRoutine(Coroutine routine);
    }
}

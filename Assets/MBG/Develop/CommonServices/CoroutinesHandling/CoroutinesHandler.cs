using System.Collections;
using UnityEngine;

namespace Assets.MBG.Develop.CommonServices.CoroutinesHandling
{
    public class CoroutinesHandler : MonoBehaviour, ICoroutinesHandler
    {
        #region Singleton Impl
        private static CoroutinesHandler _instance;
        private static readonly object _instanceLock = new();

        public static ICoroutinesHandler Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock(_instanceLock)
                    {
                        if (_instance == null)
                        {
                            GameObject coroutinesHandlerInstance = new GameObject("[Coroutines Handler]");
                            _instance = coroutinesHandlerInstance.AddComponent<CoroutinesHandler>();

                            DontDestroyOnLoad(coroutinesHandlerInstance);
                        }
                    }
                }

                return _instance;
            }
        }
        #endregion

        public Coroutine StartRoutine(IEnumerator coroutine)
            => StartCoroutine(coroutine);

        public void StopRoutine(Coroutine routine)
            => StopCoroutine(routine);
    }
}

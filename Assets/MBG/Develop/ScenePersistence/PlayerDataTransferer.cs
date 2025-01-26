using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.MBG.Develop.ScenePersistence
{
    public sealed class PlayerDataTransferer : MonoBehaviour
    {
        #region Singleton Impl
        private static PlayerDataTransferer _instance;
        private static readonly object _instanceLock = new();

        public static PlayerDataTransferer Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_instanceLock)
                    {
                        if (_instance == null)
                        {
                            GameObject instanceObject = new("[ Player Data Transferer ]");
                            _instance = instanceObject.AddComponent<PlayerDataTransferer>();

                            DontDestroyOnLoad(instanceObject);
                        }
                    }
                }

                return _instance;
            }
        }
        #endregion

        public Material Material { get; set; }

        public void ApplyTo(MonoBehaviour gameObject)
        {
            gameObject.GetComponent<Renderer>().material = Material;
        }
    }
}

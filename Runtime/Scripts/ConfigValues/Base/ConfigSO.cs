using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.RemoteConfig;
using UnityEngine.Events;
using Elysium.Core;
using Elysium.Utils.Attributes;

namespace Elysium.RemoteConfig
{
    public abstract class ConfigSO : ValueSO
    {
        [Tooltip("Set this to the exact string set in the remote config console")]
        [SerializeField] protected string configName = default;
        [SerializeField, ReadOnly] private bool isLoaded = default;

        public bool IsLoaded
        {
            get => isLoaded;
            set => isLoaded = value;
        }

        public abstract void SetValueOnLoad(ConfigResponse _response);

        public virtual void LoadConfig(ConfigResponse _response)
        {
            SetValueOnLoad(_response);
            isLoaded = true;
        }
    }
}
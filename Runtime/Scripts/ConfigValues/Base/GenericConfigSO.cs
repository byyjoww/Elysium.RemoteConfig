using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.RemoteConfig;
using UnityEngine.Events;
using Elysium.Utils;
using Elysium.Utils.Attributes;

namespace Elysium.RemoteConfig
{
    public abstract class GenericConfigSO<T> : ConfigSO
    {
        [Separator("Values", true)]
        [Tooltip("This is set automatically by the remote config system once the config is loaded")]
        [SerializeField, ReadOnly] protected T value = default;
        [Tooltip("Default value to be used if the remote config system cannot load the config")]
        [SerializeField] protected T defaultValue = default;

        public virtual T Value
        {
            get
            {
                if (!IsLoaded) { return defaultValue; }
                return value;
            }

            set
            {
                this.value = value;
                InvokeOnValueChanged();
            }
        }

        public override string ValueAsString => Value.ToString();

        private void OnValidate()
        {
#if UNITY_EDITOR
            EditorPlayStateNotifier.RegisterOnExitPlayMode(this, () =>
            {
                value = defaultValue;
                IsLoaded = false;
            });
#endif
        }
    }
}
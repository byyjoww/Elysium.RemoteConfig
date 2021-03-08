using UnityEngine;
using Unity.RemoteConfig;
using Elysium.Utils;
using Elysium.Core;
using Elysium.Utils.Attributes;
using System;

namespace Elysium.RemoteConfig
{
    [CreateAssetMenu(fileName = "RemoteConfigSystemSO", menuName = "Scriptable Objects/Remote Config/Remote Config System")]
    public class RemoteConfigSystemSO : ScriptableObject, IInitializable
    {
        [SerializeField] private EventSO DoFetchRemoteConfig = default;
        [SerializeField] private EventSO OnFetchRemoteConfig = default;

        [Separator("All Remote Configs", true)]
        public RemoteConfigDatabase remoteConfigs;
        
        public struct userAttributes { }
        public struct appAttributes { }
        [field: NonSerialized] public bool Initialized { get; set; }

        // Ignore requests while currently fetching for configs
        private bool fetchingConfigs = false;

        public void Init()
        {
            if (Initialized) { return; }

            DoFetchRemoteConfig.OnRaise += ReceiveFetchRequest;
            GetConfigsFromRemote();
            Initialized = true;

            Debug.Log("Remote Config System Started");
        }

        public void End()
        {
            if (!Initialized) { return; }

            DoFetchRemoteConfig.OnRaise -= ReceiveFetchRequest;
            Initialized = false;

            Debug.Log("Remote Config System Terminated");
        }

        private void ReceiveFetchRequest()
        {
            Debug.Log("Received remote config fetch request");
            GetConfigsFromRemote();
        }

        private void GetConfigsFromRemote()
        {
            if (fetchingConfigs) { return; }

            Debug.Log("Remote Config Fetch Started.");
            fetchingConfigs = true;

            StartListeningForConfigFetch();
            ConfigManager.FetchConfigs(new userAttributes(), new appAttributes());
        }

        private void ConfigFetchComplete(ConfigResponse _response)
        {
            StopListeningForConfigFetch();
            OnFetchRemoteConfig.Raise();
            Debug.Log("Remote Config Fetch Completed.");
            fetchingConfigs = false;
        }

        private void StartListeningForConfigFetch()
        {            
            foreach (var config in remoteConfigs.Elements)
            {
                ConfigManager.FetchCompleted += config.LoadConfig;
            }

            ConfigManager.FetchCompleted += ConfigFetchComplete;
        }

        private void StopListeningForConfigFetch()
        {            
            foreach (var config in remoteConfigs.Elements)
            {
                ConfigManager.FetchCompleted -= config.LoadConfig;
            }

            ConfigManager.FetchCompleted -= ConfigFetchComplete;
        }

        private void OnValidate()
        {
            remoteConfigs.Refresh();
        }
    }
}
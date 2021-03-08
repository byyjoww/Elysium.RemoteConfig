using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.RemoteConfig;

namespace Elysium.RemoteConfig
{
    [CreateAssetMenu(fileName = "ConfigSO_Int", menuName = "Scriptable Objects/Remote Config/Int")]
    public class IntConfigSO : GenericConfigSO<int>
    {
        public override void SetValueOnLoad(ConfigResponse _response)
        {
            Value = ConfigManager.appConfig.GetInt(configName);
        }
    }
}
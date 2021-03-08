using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.RemoteConfig;

namespace Elysium.RemoteConfig
{
    [CreateAssetMenu(fileName = "ConfigSO_String", menuName = "Scriptable Objects/Remote Config/String")]
    public class StringConfigSO : GenericConfigSO<string>
    {
        public override void SetValueOnLoad(ConfigResponse _response)
        {
            Value = ConfigManager.appConfig.GetString(configName);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.RemoteConfig;

namespace Elysium.RemoteConfig
{
    [CreateAssetMenu(fileName = "ConfigSO_Long", menuName = "Scriptable Objects/Remote Config/Long")]
    public class LongConfigSO : GenericConfigSO<long>
    {
        public override void SetValueOnLoad(ConfigResponse _response)
        {
            Value = ConfigManager.appConfig.GetLong(configName);
        }
    }
}
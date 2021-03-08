using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.RemoteConfig;

namespace Elysium.RemoteConfig
{
    [CreateAssetMenu(fileName = "ConfigSO_Bool", menuName = "Scriptable Objects/Remote Config/Bool")]
    public class BoolConfigSO : GenericConfigSO<bool>
    {
        public override void SetValueOnLoad(ConfigResponse _response)
        {
            Value = ConfigManager.appConfig.GetBool(configName);
        }
    }
}
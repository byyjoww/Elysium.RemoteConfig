using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.RemoteConfig;

namespace Elysium.RemoteConfig
{
    [CreateAssetMenu(fileName = "ConfigSO_Float", menuName = "Scriptable Objects/Remote Config/Float")]
    public class FloatConfigSO : GenericConfigSO<float>
    {
        public override void SetValueOnLoad(ConfigResponse _response)
        {
            Value = ConfigManager.appConfig.GetFloat(configName);
        }
    }
}
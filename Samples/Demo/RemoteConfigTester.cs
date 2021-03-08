using Elysium.Core;
using Elysium.RemoteConfig;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class RemoteConfigTester : MonoBehaviour
{
    public RemoteConfigSystemSO RemoteConfigSystem;
    public ConfigSO Config;
    public EventSO DoFetch;
    public EventSO OnFetch;

    public Text textComponent;

    private void Start()
    {
        UpdateText();
    }

    [ContextMenu("Initialize")]
    public void Initialize()
    {
        OnFetch.OnRaise += UpdateText;
        RemoteConfigSystem.Init();
    }

    [ContextMenu("Get Configs")]
    public void GetConfigs()
    {
        DoFetch.Raise();
    }

    public void UpdateText()
    {
        textComponent.text = Config.ValueAsString;
    }
}

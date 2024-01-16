using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSettingUI : MonoBehaviour
{
    public Scrollbar bgmBar;
    public Scrollbar EffectBar;
    [SerializeField] private SoundSettingManager ssm;

    private void Start()
    {
        ssm = FindObjectOfType<SoundSettingManager>();
        bgmBar.value = ssm.bgmVolume;
        EffectBar.value = ssm.effectVolume;
    }

    private void Update()
    {
        ssm.bgmVolume = bgmBar.value;
        ssm.effectVolume = EffectBar.value;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSound : MonoBehaviour
{
    public AudioClip audioClip;
    public AudioSource audioSource;
    public SoundSettingManager soundSetting;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.Play();
        soundSetting = FindObjectOfType<SoundSettingManager>();
    }

    // Update is called once per frame
    void Update()
    {
        soundSetting = FindObjectOfType<SoundSettingManager>();
        audioSource.volume = soundSetting.bgmVolume / 2;
    }
}

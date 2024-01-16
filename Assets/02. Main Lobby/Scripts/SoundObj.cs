using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoundObj : MonoBehaviour
{
    private AudioSource sound;
    private SoundSettingManager soundSettingManager;
    public bool isBGM;

    void Start()
    {
        sound = GetComponent<AudioSource>();
        sound.loop = isBGM;
        sound.Play();
    }

    void Update()
    {
        soundSettingManager = FindObjectOfType<SoundSettingManager>();

        if (!isBGM)
        {
            sound.volume = soundSettingManager.effectVolume;
        }
        else
        {
            sound.volume = soundSettingManager.bgmVolume;
        }

        if (!sound.isPlaying && !sound.loop)
            Destroy(gameObject);
    }
}

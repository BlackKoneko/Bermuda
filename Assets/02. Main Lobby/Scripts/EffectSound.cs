using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSound : MonoBehaviour
{
    [SerializeField] private GameObject soundObj;
    [SerializeField] private AudioClip soundClip;

    public void Play()
    {
        soundObj.GetComponent<AudioSource>().clip = soundClip;
        Instantiate(soundObj);
    }
}

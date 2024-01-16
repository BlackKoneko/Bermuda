using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{

    public SoundSettingManager soundSetting;
    public float effectEnd;
    int time;
    public AudioClip audioClip;
    [SerializeField] AudioSource audioSource;
    IEnumerator Time()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            time++;
        }
        yield return null;
    }
    // Start is called before the first frame update
    void Start()
    {
        soundSetting = FindObjectOfType<SoundSettingManager>();
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.volume = soundSetting.effectVolume;
        audioSource.Play();
        StartCoroutine(Time());
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.volume = soundSetting.effectVolume / 2;
        if (time > effectEnd)
        {
            Destroy(gameObject);
        }
    }
}

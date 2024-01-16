using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Key : MonoBehaviour
{
    public SoundSettingManager soundSetting;
    public AudioClip audioClip;
    AudioSource audioSource;
    public int bossPotal; 
    // Start is called before the first frame update
    void Start()
    {
        soundSetting = FindObjectOfType<SoundSettingManager>();
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = soundSetting.effectVolume;
        audioSource.clip = audioClip;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag =="Player")
        {
            if(bossPotal == 1)
            {
                GameObject.Find("SecondBoss").GetComponent<Collider>().enabled = true;
            }
            else if (bossPotal == 2)
            {
                GameObject.Find("ThirdBoss").GetComponent<Collider>().enabled = true;
            }
            else if (bossPotal == 3)
            {
                SceneManager.LoadScene("MainEndingScenes");
                return;
            }

            FindObjectOfType<StartPosition>().start = true;
            Destroy(gameObject);
        }
    }
}

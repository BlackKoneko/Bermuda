using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlDie : MonoBehaviour
{
    public AudioClip audioClip;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClip;
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<Player>().hp <= 0)
        {
            audioSource.Play();
            Destroy(GameObject.FindWithTag("Monster"));
            FindObjectOfType<StartPosition>().start = true;
        }
        
    }
}

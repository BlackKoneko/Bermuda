using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DogDie : MonoBehaviour
{
    public AudioClip[] auClip;
    private float pulsTime;
    private float doTime;

    void Start()
    {
        pulsTime = 3;
        doTime = 0;
        GetComponent<AudioSource>().Play();

    }

    void Update()
    {
        doTime += Time.deltaTime;
        if (doTime >= pulsTime)
        {
            SceneManager.LoadScene("Adventure");
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BearDie : MonoBehaviour
{
    public AudioClip[] auClip;
    private float pulsTime;
    private float doTime;
    // Start is called before the first frame update
    void Start()
    {
        pulsTime = 3;
        doTime = 0;
        GetComponent<AudioSource>().Play();

    }

    // Update is called once per frame
    void Update()
    {
        doTime += Time.deltaTime;
        if (doTime >= pulsTime)
        {
            SceneManager.LoadScene("Adventure");
        }

    }
}

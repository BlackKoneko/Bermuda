using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotCook : MonoBehaviour
{
    public AudioClip[] auClip;
    public GameObject healingFoodObjects;

    GameObject gm;
    ClickResponse clickResponse;

    void Start()
    {
        gm = GameObject.Find("Main Camera");
        clickResponse = gm.GetComponent<ClickResponse>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void MainCook()
    {
        if (clickResponse.healingFoodStuffCount == 9)
        {
            Debug.Log("Èú¸µÆ÷¼Ç ¿ä¸®µÊ");
            GetComponent<AudioSource>().clip = auClip[0];
            GetComponent<AudioSource>().Play();
            Invoke("Cook", 5);
            clickResponse.healingFoodStuffCount = 0;
        }
    }
    void Cook()
    {
        Instantiate(healingFoodObjects, new Vector3(-43.03f, 6.25f, 67.9f), Quaternion.identity);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FryingPenCook : MonoBehaviour
{
    public AudioClip[] auClip;
    public GameObject missionFoodObjects;

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
        if (clickResponse.foodStuffCount == 8)
        {
            Debug.Log("¿ä¸®µÊoo");
            GetComponent<AudioSource>().clip = auClip[0];
            GetComponent<AudioSource>().Play();
            Invoke("Cook", 8);
            clickResponse.foodStuffCount = 0;
        }
    }
    void Cook()
    {
        GetComponent<AudioSource>().clip = auClip[1];
        GetComponent<AudioSource>().Play();
        Instantiate(missionFoodObjects, new Vector3(-44.25f, 5.85f, 66.8f), Quaternion.identity);
    }

}

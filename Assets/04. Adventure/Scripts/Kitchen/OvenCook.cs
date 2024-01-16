using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvenCook : MonoBehaviour
{
    public AudioClip[] auClip;
    public GameObject dogFoodMissionObjects;

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
        if (clickResponse.dogFoodStuffCount == 7)
        {
            Debug.Log("개간식 요리됨");
            GetComponent<AudioSource>().clip = auClip[0];
            GetComponent<AudioSource>().Play();
            Invoke("Cook", 3);
            clickResponse.dogFoodStuffCount = 0;

        }
    }
    void Cook()
    {
        Instantiate(dogFoodMissionObjects, new Vector3(-43.62f, 4.8f, 65.3f), Quaternion.identity);
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DogMotion : MonoBehaviour
{
    public AudioClip[] auClip;

    GameObject gm;
    AdventureGameManager gmComponent;

    EndingManager emComponent;
    PlayerProperty playerProperty;
    public GameObject audioGameobj;
    int soundNum;
    PlayerData playerData;

    void Start()
    {
        gm = GameObject.Find("GameManager");
        gmComponent = gm.GetComponent<AdventureGameManager>();

        gm = GameObject.Find("Player");
        playerProperty = gm.GetComponent<PlayerProperty>();
        playerData = FindObjectOfType<PlayerData>();

        Setting(0);
    }

    void Update()
    {
        if(playerProperty.dogFoodQuest == true)
        {
            audioGameobj.GetComponent<AudioSource>().Stop();
        }
    }
    public void DogFoodEat()
    {
        if(playerProperty.dogFoodQuest ==true)
        {
            transform.position = new Vector3(-23f, 22.5f, 0);
            playerData.dogEatQuest = true;
            Setting(1);
        }
        else
        {
            DogWakeUp();
        }
    }
    public void DogWakeUp() //죽음
    {
        Debug.Log("개 다이");
        playerProperty.dogDie = true;
    }

    void OnCollisionEnter(Collision collision)//바로일어나는 조건
    {
        if (playerData.dogEatQuest == false)
        {
            Debug.Log("개와 충돌 : " + collision.gameObject.name);
            if (collision.gameObject.tag == "Player")
            {
                DogWakeUp();
            }
        }
        else 
        {
        }
    }

    void Setting(int num)
    {
        audioGameobj.GetComponent<AudioSource>().clip = auClip[num];
        audioGameobj.GetComponent<AudioSource>().Play();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClickResponse : MonoBehaviour
{

    public int foodStuffCount;
    public int dogFoodStuffCount;
    public int healingFoodStuffCount;
    public TextMeshProUGUI foodText;
    public GameObject reward;
    public GameObject rewardPotion;


    GameObject gm;
    FryingPenCook fryingPenCook;
    PotCook potCook;
    OvenCook ovenCook;
    NPCMent npcMent;
    BearMotion bearMotion;
    DogMotion dogMotion;

    PlayerProperty playerProperty;
    PlayerData playerData;

    float MaxDistance = 8f;

    private RaycastHit hit;
    void Start()
    {
        foodStuffCount = 0;
        dogFoodStuffCount = 0;
        healingFoodStuffCount = 0;

        gm = GameObject.Find("NPC");
        npcMent = gm.GetComponent<NPCMent>();

        gm = FindObjectOfType<BearMotion>().gameObject;
        bearMotion = gm.GetComponent<BearMotion>();

        gm = FindObjectOfType<DogMotion>().gameObject;
        dogMotion = gm.GetComponent<DogMotion>();

        gm = FindObjectOfType<FryingPenCook>().gameObject;
        fryingPenCook = gm.GetComponent<FryingPenCook>();

        gm = FindObjectOfType<PotCook>().gameObject;
        potCook = gm.GetComponent<PotCook>();

        gm = FindObjectOfType<OvenCook>().gameObject;
        ovenCook = gm.GetComponent<OvenCook>();

        gm = GameObject.Find("Player");
        playerProperty = gm.GetComponent<PlayerProperty>();


        playerData = FindObjectOfType<PlayerData>();
    }

        void Update()
        {
            Raycast();
        }
        void Raycast()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (Physics.Raycast(this.transform.position, transform.forward, out hit, MaxDistance))
                {
                    Debug.Log(hit.transform.gameObject.name);
                    if (hit.transform.gameObject.tag == "NPC")
                    {
                        npcMent.NPClickMent();
                    }
                    else if (hit.transform.gameObject.tag == "Bear")
                    {
                        bearMotion.WakeUp();
                    }
                    else if (hit.transform.gameObject.tag == "Dog")
                    {
                        dogMotion.DogFoodEat();
                    }
                    else if (hit.transform.gameObject.tag == "GoldBox")
                    {
                        Destroy(hit.transform.gameObject);
                        playerData.adventureClear = true;
                        //이미지 ui뛰움
                        reward.SetActive(true);

                    }
                    else if (playerData.adventureClear == false && playerProperty.bearFoodQuest == false)
                    {
                        if (hit.transform.gameObject.tag == "MainFood")
                        {
                            Destroy(hit.transform.gameObject);
                            foodStuffCount++;
                            foodText.text = foodStuffCount.ToString() + "/8";
                            if (foodStuffCount == 8)
                            { foodText.text = " "; }
                        }
                        else if (hit.transform.gameObject.tag == "FryingPen")
                        {
                            fryingPenCook.MainCook();
                        }
                        else if (hit.transform.gameObject.tag == "MissionFood")
                        {
                            Debug.Log("미션푸드맞음");
                            Destroy(hit.transform.gameObject);
                            playerProperty.bearFoodQuest = true;
                        }
                    }
                    else if (playerData.adventureClear == false && playerProperty.bearFoodQuest == true)
                    {
                        if (playerProperty.boxKeyGet == false)
                        {
                            if (hit.transform.gameObject.tag == "BoxKey")
                            {
                                Destroy(hit.transform.gameObject);
                                playerProperty.boxKeyGet = true;
                            }
                        }
                        else if (playerProperty.boxKeyGet == true)
                        {
                            if (hit.transform.gameObject.tag == "DogFood")
                            {
                                Destroy(hit.transform.gameObject);
                                dogFoodStuffCount++;
                                foodText.text = dogFoodStuffCount + "/7";
                                if (dogFoodStuffCount == 7)
                                { foodText.text = " "; }
                            }
                            else if (hit.transform.gameObject.tag == "Oven")
                            {
                                ovenCook.MainCook();
                            }
                            else if (hit.transform.gameObject.tag == "DogMissionFood")
                            {
                                Destroy(hit.transform.gameObject);
                                playerProperty.dogFoodQuest = true;
                            }
                        }
                    }
                    else if (playerData.adventureClear == true)
                    {
                        if (hit.transform.gameObject.tag == "HealingFood")
                        {
                            Destroy(hit.transform.gameObject);
                            healingFoodStuffCount++;
                            foodText.text = healingFoodStuffCount + "/9";
                            if (healingFoodStuffCount == 9)
                            { foodText.text = " "; }
                        }
                        else if (hit.transform.gameObject.tag == "Pot")
                        {
                            potCook.MainCook();
                        }
                    else if (hit.transform.gameObject.tag == "HealingPotion")
                    {
                        Debug.Log("힐링포션맞음");
                        Destroy(hit.transform.gameObject);
                        playerProperty.healingFoodQuest = true;
                        rewardPotion.SetActive(true);
                    }
                }
                    else
                    {
                    }
                }
            }
        }
}

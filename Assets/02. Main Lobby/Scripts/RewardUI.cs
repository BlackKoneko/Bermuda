using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RewardUI : MonoBehaviour
{
    public AddItemButton rewardButton;
    public GameObject nameBox;
    public GameObject toolTipBox;
    [SerializeField] private GameObject rewardUIButton;

    public WeaponItem rewardWeapon;
    public ShieldItem rewardShield;
    public ShoesItem rewardShoes;
    public PotionItem rewardPotion;

    private void Start()
    {   
        Cursor.lockState = CursorLockMode.None;

        if(rewardWeapon != null )
        {
            RewardUIButton button = Instantiate(rewardUIButton, GameObject.Find("Canvas").transform.position, Quaternion.identity, GameObject.Find("RewardPanel").transform).GetComponent<RewardUIButton>();
            button.reward = rewardWeapon;
            button.nameBox = nameBox;
            button.toolTipBox = toolTipBox;
            rewardButton.rewardWeapon = rewardWeapon;
        }
        if (rewardShield != null)
        {
            RewardUIButton button = Instantiate(rewardUIButton, GameObject.Find("Canvas").transform.position, Quaternion.identity, GameObject.Find("RewardPanel").transform).GetComponent<RewardUIButton>(); 
            button.reward = rewardShield;
            button.nameBox = nameBox;
            button.toolTipBox = toolTipBox;
            rewardButton.rewardShield = rewardShield;
        }
        if (rewardShoes != null)
        {
            RewardUIButton button = Instantiate(rewardUIButton, GameObject.Find("Canvas").transform.position, Quaternion.identity, GameObject.Find("RewardPanel").transform).GetComponent<RewardUIButton>();
            button.reward = rewardShoes;
            button.nameBox = nameBox;
            button.toolTipBox = toolTipBox;
            rewardButton.rewardShoes = rewardShoes;
        }
        if (rewardPotion != null)
        {
            RewardUIButton button = Instantiate(rewardUIButton, GameObject.Find("Canvas").transform.position, Quaternion.identity, GameObject.Find("RewardPanel").transform).GetComponent<RewardUIButton>();
            button.reward = rewardPotion;
            button.nameBox = nameBox;
            button.toolTipBox = toolTipBox;
            rewardButton.rewardPotion = rewardPotion;
        }
    }
}

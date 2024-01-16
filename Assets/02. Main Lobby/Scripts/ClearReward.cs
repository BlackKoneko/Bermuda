using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearReward : MonoBehaviour
{
    [SerializeField] private GameObject rewardUI;
    
    [SerializeField] private WeaponItem rewardWeapon;
    [SerializeField] private ShieldItem rewardShield;
    [SerializeField] private ShoesItem rewardShoes;
    [SerializeField] private PotionItem rewardPotion;
    public void AddReward()
    {
        GameObject ui = Instantiate(rewardUI, GameObject.Find("Canvas").transform.position, Quaternion.identity, GameObject.Find("Canvas").transform);
        FindObjectOfType<UiManager>().CurrentUI = ui;
        RewardUI reward = ui.GetComponent<RewardUI>();
        if (rewardWeapon != null)
            reward.rewardWeapon = rewardWeapon;
        if (rewardShield != null)
            reward.rewardShield = rewardShield;
        if (rewardShoes != null)
            reward.rewardShoes = rewardShoes;
        if (rewardPotion != null)
            reward.rewardPotion = rewardPotion;
    }
}

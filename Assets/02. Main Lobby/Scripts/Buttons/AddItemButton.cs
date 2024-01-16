using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddItemButton : MonoBehaviour
{
    public WeaponItem rewardWeapon;
    public ShieldItem rewardShield;
    public ShoesItem rewardShoes;
    public PotionItem rewardPotion;

    public void AddItem()
    {
        PlayerData plData = FindObjectOfType<PlayerData>();

        if(rewardWeapon != null)
            plData.AddEquipment(rewardWeapon);
        if (rewardShield != null)
            plData.AddEquipment(rewardShield);
        if (rewardShoes != null)
            plData.AddEquipment(rewardShoes);
        if (rewardPotion != null)
            plData.AddEquipment(rewardPotion);
    }
}

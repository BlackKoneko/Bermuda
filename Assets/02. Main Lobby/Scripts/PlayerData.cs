using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public int hp;
    public int shield;
    public int atk;
    public float speed;
    public bool dash = true;
    public float dashCool = 3.0f;
    public bool cool = false;
    public bool potion;
    public bool adventureClear;
    public bool dogEatQuest;

    public Equipment weaponEquip;
    public Equipment shieldEquip;
    public Equipment shoesEquip;
    public Equipment potionEquip;

    private Equipment[] inven = new Equipment[4];

    private void Start()
    {
        int count = FindObjectsOfType<PlayerData>().Length;
        if(count > 1)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        adventureClear = false;
        dogEatQuest = false;
    }

    public void DataUpdata()
    {
        if (weaponEquip)
            weaponEquip.Application();
        if (shieldEquip)
            shieldEquip.Application();
        if (shoesEquip)
            shoesEquip.Application();
        if (potionEquip)
            potionEquip.Application();
    }

    public void AddEquipment(WeaponItem equip)
    {
        weaponEquip = equip;
        DataUpdata();
    }
    public void AddEquipment(ShieldItem equip)
    {
        shieldEquip = equip;
        DataUpdata();
    }
    public void AddEquipment(ShoesItem equip)
    {
        shoesEquip = equip;
        DataUpdata();
    }
    public void AddEquipment(PotionItem equip)
    {
        potionEquip = equip;
        DataUpdata();
    }
}

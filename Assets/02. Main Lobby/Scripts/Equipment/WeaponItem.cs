using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponItem : Equipment
{
    public int atkValue;
    public override void Application()
    {
        FindObjectOfType<PlayerData>().atk = atkValue;
    }
}

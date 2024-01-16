using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldItem : Equipment
{
    public int shieldValue;
    public override void Application()
    {
        FindObjectOfType<PlayerData>().shield = shieldValue;
    }
}

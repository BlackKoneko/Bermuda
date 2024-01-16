using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionItem : Equipment
{
    public int count;
    public float RecoveryValue;
    public override void Application()
    {
        FindObjectOfType<PlayerData>().potion = true;
    }
}

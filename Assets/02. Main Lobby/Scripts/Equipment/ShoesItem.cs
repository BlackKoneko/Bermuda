using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoesItem : Equipment
{
    public float speedValue;
    public float dashCoolValue;
    public override void Application()
    {
        FindObjectOfType<PlayerData>().speed = speedValue;
        FindObjectOfType<PlayerData>().dashCool = dashCoolValue;
    }
}

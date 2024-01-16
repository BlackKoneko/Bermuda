using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeBlock : Trap
{
    protected override void OnTrap(PlayerHp player)
    {
        GetComponent<Collider>().enabled = false;
    }
}

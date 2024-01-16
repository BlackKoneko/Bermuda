using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    protected virtual void OnTrap(PlayerHp player)
    {
        player.CurrentHp--;

        // 각 함정의 기능 추가
        // 맞으면 플레어가 날아간다던가...
        // 이동속도가 느려진다던가...
    }
    protected void OnTriggerEnter(Collider other)
    {
        PlayerHp pl;
        if (other.TryGetComponent<PlayerHp>(out pl))
        {
            OnTrap(pl);
        }
    }
}

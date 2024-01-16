using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Player3DControl player3D = other.GetComponent<Player3DControl>();
        PlayerControl player = other.GetComponent<PlayerControl>();

        GetComponent<ClearReward>().AddReward();
        gameObject.SetActive(false);

        if(player3D != null)
        {
            player3D.isStart = false;
        }

        if(player != null)
        {
            player.isStart = false;
        }
        Cursor.lockState = CursorLockMode.None;
    }
}

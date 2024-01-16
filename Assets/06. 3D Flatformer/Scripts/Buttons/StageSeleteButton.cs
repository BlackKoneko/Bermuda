using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSeleteButton : MonoBehaviour
{
    public GameObject map;
    public GameObject UI;
    public Player3DControl player;
    public void StageSelete()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Instantiate(map);
        player.isStart = true;
        UI.SetActive(false);
    }
}

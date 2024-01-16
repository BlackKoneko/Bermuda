using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPosition : MonoBehaviour
{
    public GameObject player;
    public GameObject bossHpBar;
    public bool start;
    // Start is called before the first frame update
    void Start()
    {

        start = false;
        player.transform.position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(start)
        {
            bossHpBar.SetActive(false);
            player.GetComponent<Player>().potion = player.GetComponent<Player>().plData.potion;
            player.GetComponent<Player>().hp = player.GetComponent<Player>().plData.hp;
            player.GetComponent<Player>().shield = player.GetComponent<Player>().plData.shield;
            player.transform.position = transform.position;
            start = false;
        }
    }
}

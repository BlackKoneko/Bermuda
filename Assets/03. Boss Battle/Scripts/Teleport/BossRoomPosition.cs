using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class BossRoomPosition : MonoBehaviour
{

    public GameObject playerPosition;
    public GameObject player;
    public GameObject boss;
    public GameObject BossPosition;
    public GameObject bossHpBar;
  

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        bossHpBar.SetActive(true);
        player.transform.position = playerPosition.transform.position;
        GameObject bossObj = Instantiate(boss, BossPosition.transform);
        FindObjectOfType<BossHp>().monster = bossObj.GetComponent<Monster>();
    }
}

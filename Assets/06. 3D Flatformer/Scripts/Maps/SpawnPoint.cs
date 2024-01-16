using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player3DControl>().gameObject;
        SpawnPlayer();
    }

    public void SpawnPlayer()
    {
        player.transform.position = transform.position;
    }
}

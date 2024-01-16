using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPoint : MonoBehaviour
{
    public GameObject player;



    PlayerData plData;
    // Start is called before the first frame update
    void Start()
    {
        plData = FindObjectOfType<PlayerData>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

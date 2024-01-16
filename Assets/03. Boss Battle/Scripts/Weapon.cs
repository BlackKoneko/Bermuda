using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject gameObj;
    public int wAtk;
    public int pAtk;
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<BoxCollider>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObj.GetComponent<Player>())
        {
            pAtk = gameObj.GetComponent<Player>().plData.atk;
        }
        damage = wAtk + pAtk;
    }
}

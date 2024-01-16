using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    int bossType;
    Monster mon;

    StartPosition startPosition;
    public GameObject key;

    // Start is called before the first frame update
    void Start()
    {
        bossType = GetComponent<Monster>().bossType;
        mon = GetComponent<Monster>();
        startPosition = FindObjectOfType<StartPosition>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (bossType)
        {
            case 1:
                if (mon.hp <= 0)
                {
                    Instantiate(key,transform.position = new Vector3(0,0,-1),Quaternion.identity);
                    Destroy(gameObject);
                }
                break;
            case 2:
                if (mon.hp <= 0)
                {    
                    Instantiate(key, transform.position = new Vector3(0, 0, -1), Quaternion.identity);
                    Destroy(gameObject);
                }
                break;
            case 3:
                if (mon.hp <= 0)
                {
                    Instantiate(key, transform.position = new Vector3(0, 0, -1), Quaternion.identity);
                    Destroy(gameObject);
                }
                break;
        }
    }
}

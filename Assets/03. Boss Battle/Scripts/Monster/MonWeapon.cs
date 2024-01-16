using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonWeapon : MonoBehaviour
{
    public int atk;


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("³ª ¶§¸²");
            GetComponent<BoxCollider>().enabled = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

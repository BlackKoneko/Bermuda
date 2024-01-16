using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterTakeDamage : MonoBehaviour
{
    Collider plWeaponCol;
    // Start is called before the first frame update
    void Start()
    {
        plWeaponCol = GameObject.FindWithTag("Weapon").GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("¸ÂÀ½");
        if (other.tag == "Weapon")
        {
            plWeaponCol.enabled = false;
            TakeDamege(other.GetComponent<Weapon>().damage);
            Debug.Log(other.GetComponent<Weapon>().damage);
        }
    }


    public void TakeDamege(int damage)
    {
        GetComponent<Monster>().hp -= damage;
    }
}

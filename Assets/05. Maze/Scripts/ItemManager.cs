using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public Item[] item = new Item[3];

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<Inventory>().AddItem(item[Random.Range(0,3)]);
            Destroy(gameObject);
        }
    }
}

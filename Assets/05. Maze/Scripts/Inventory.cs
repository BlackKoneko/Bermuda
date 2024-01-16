using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    //public List<Item> items;
    public Item[] items;
    public int arrCount = 0;
    public Transform bag;
    public Slot[] slots;
    public int currentIndex;

    private void OnValidate()
    {
       // slots = bag.GetComponentsInChildren<Slot>();
    }
    void Awake()
    {
        items = new Item[4];
        slots = bag.GetComponentsInChildren<Slot>();
        //SlotEngine();
    }
    /*
    public void SlotEngine()
    {
        for (int i = 0; i < 4; i++)
        {
            if (slots[i].item == null)
            {
                slots[i].item = items[i];
                slots[i].image.sprite = items[i].itemImgage;
                return;
            }
        }
    }
    */

    public void SlotEngine(Item _item)
    {
        for (int i = 0; i < 4; i++)
        {
            if (slots[i].item == null)
            {
                slots[i].item = _item;
                slots[i].image.sprite = _item.itemImgage;
                return;
            }
        }
    }
    public void AddItem(Item _item)
    {
        SlotEngine(_item);
    }

    public void RemoveAt(int index)
    {
        slots[index].item = null;
        slots[index].image.sprite = null;
        /*
        items[index] = null;
        currentIndex = index;
        arrCount = index;*/
    }
}

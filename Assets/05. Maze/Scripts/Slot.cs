using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Image image;

    public Item _item;
    public Item item
    {
        get 
        { 
            return _item; 
        }
        set 
        { 
            _item = value;
            if(_item != null) 
            {
                image.sprite = item.itemImgage;
                image.color = new Color(1, 1, 1, 1);
            }
            else
            {
                image.color = new Color(1, 1, 1, 0);
            }
        }
    }
}
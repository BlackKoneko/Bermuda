using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHp : MonoBehaviour
{
    // Start is called before the first frame update
    public Image image;
    public Monster monster;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        //monster = FindObjectOfType<Monster>();
    }

    // Update is called once per frame
    void Update()
    {
        if(monster != null)
        {
            image.fillAmount = ((float)monster.hp / (float)monster.maxHp);
            Debug.Log("TEST:"+ (float)monster.hp / (float)monster.maxHp);
        }
    }
}

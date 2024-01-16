using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionCool : MonoBehaviour
{
    Image image;
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindObjectOfType<Player>();
        image = GetComponent<Image>();
    }
    // Update is called once per frame
    void Update()
    {
        if (player.potion)
        {
            image.fillAmount = 1;
        }
        else
        {
            image.fillAmount = 0;
        }
    }
}

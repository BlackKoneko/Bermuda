using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlHp : MonoBehaviour
{
    public Image image;
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        player = GameObject.Find("PlayerObject").GetComponent<Player>();

    }

    // Update is called once per frame
    void Update()
    {
        image.fillAmount = ((float)player.hp/ (float)player.plData.hp);
    }
}

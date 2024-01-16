using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlShield : MonoBehaviour
{
    // Start is called before the first frame update
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
        image.fillAmount = ((float)player.shield / (float)player.plData.shield);
    }
}

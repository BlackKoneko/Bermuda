using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static BearMotion;

public class BearStateUI : MonoBehaviour
{
    GameObject gm;
    BearMotion bearMotion;

    public Sprite state1;
    public Sprite state2;
    public Sprite state3;

    public GameObject image;

    BearState state;
    private void Start()
    {
        bearMotion = FindObjectOfType<BearMotion>();
    }
    private void Update()
    {
        if (bearMotion.start == true)
        {
            image.gameObject.SetActive(true);
            switch (bearMotion.state)
            {
                case BearState.deepSleep:
                    image.GetComponent<Image>().sprite = state1;
                    break;
                case BearState.ramSleep:
                    image.GetComponent<Image>().sprite = state2;
                    break;
                case BearState.halfEyes:
                    image.GetComponent<Image>().sprite = state3;
                    break;
            }
        }
        else if (bearMotion.start == false)
        {
            image.gameObject.SetActive(false);
        }
    }
}

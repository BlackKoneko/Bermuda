using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HpText : MonoBehaviour
{
    public TextMeshProUGUI hpText;
    public int hpValue;
    private PlayerManager plManager;

    void Start()
    {
        plManager = FindObjectOfType<PlayerManager>();
    }

    void Update()
    {
        hpValue = plManager.gameHp;
        hpText.text = hpValue.ToString();
    }
    public int GetHpValue()
    {
        return hpValue;
    }
}

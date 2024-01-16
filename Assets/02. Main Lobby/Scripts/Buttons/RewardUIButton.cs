using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RewardUIButton : MonoBehaviour
{
    public Equipment reward;
    [SerializeField] private TextMeshProUGUI rewardName;
    [SerializeField] private TextMeshProUGUI rewardToolTip;
    public GameObject nameBox;
    public GameObject toolTipBox;

    private void Start()
    {
        GetComponent<Image>().sprite = reward.icon;
    }

    public void OnClicked()
    {
        nameBox.SetActive(true);
        toolTipBox.SetActive(true);

        rewardName = GameObject.Find("NameText").GetComponent<TextMeshProUGUI>();
        rewardToolTip = GameObject.Find("TooltipText").GetComponent<TextMeshProUGUI>();

        rewardName.text = reward.equipName;
        rewardToolTip.text = reward.toolTip;
    }
}

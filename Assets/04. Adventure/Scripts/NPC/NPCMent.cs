using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCMent : MonoBehaviour
{
    public TextMeshProUGUI tempText;
    public int mouseClickCount;
    public int mouseClickCount2 = 0;
    public float timeCount;

    public GameObject boxKey;

    GameObject gm;
    PlayerProperty playerProperty;
    PlayerData playerData;

    void Start()
    {
        mouseClickCount = 0;

        gm = GameObject.Find("Player");
        playerProperty = gm.GetComponent<PlayerProperty>();
        playerData = FindObjectOfType<PlayerData>();
    }

    void Update()
    {

    }

    public void NPClickMent()
    {
        if (playerProperty.bearFoodQuest == false && playerData.adventureClear ==false)
        {
            mouseClickCount++;
            if (mouseClickCount == 1)
            {
                tempText.text = "오...인간인가? 이것 참 반갑구만!(NPC를 누르세요)";
            }
            else if (mouseClickCount == 2)
            {
                tempText.text = "그렇게 귀엽다는 눈으로 보지말아줄래? 이래뵈도 한때는 엄청난 마법사였다구!(NPC를 누르세요)";
            }
            else if (mouseClickCount == 3)
            {
                tempText.text = "몬스터들에게 당해서 지금은 이런 작은 동물이 되었지만...(NPC를 누르세요)";
            }
            else if (mouseClickCount == 4)
            {
                tempText.text = "다행히 아직은 널 도와줄수 있을거같아. 그전에 부탁이 하나있어.(NPC를 누르세요)";
            }
            else if (mouseClickCount == 5)
            {
                tempText.text = "예전에 먹던 음식이 그리운데 가게에 고양이는 출입금지래...(NPC를 누르세요)";
            }
            else if (mouseClickCount == 6)
            {
                tempText.text = "부엌엔 무서운 곰이 자고있는데 이 몸으론 이길 수 없어 너가 만들어 줄 수있어?(퀘스트를 시작하려면 NPC를 누르세요)";
            }
            else if (mouseClickCount == 7)
            {
                tempText.text = " ";
            }
        }
        else if (playerProperty.bearFoodQuest == true && playerData.adventureClear == false)
        {
            mouseClickCount2++;
            if (mouseClickCount2 == 1)
            {
                tempText.text = "와아아! 엄청 맛있어! 우걱우걱! 잠시만!(NPC를 누르세요)";
            }
            else if (mouseClickCount2 == 2)
            {
                tempText.text = "자! 이 열쇠를 가져가. 이제 너에게 필요한 것 같아. 나중에 힐링포션이 필요하면 다시 찾아줘!(보상을 받으려면 NPC를 누르세요)";
            }
            else if (mouseClickCount2 == 3)
            {
                tempText.text = " ";
                Instantiate(boxKey, new Vector3(0, 7.3f, -4.5f), Quaternion.identity);
            }
        }
        else
        {
            tempText.text = " ";
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashCool : MonoBehaviour
{
    // Start is called before the first frame update
    public bool timeBool;
    public float time;
    Image image;
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindObjectOfType<Player>();
        image = GetComponent<Image>();
        timeBool = true;
    }
    IEnumerator Time()
    {
        timeBool = false;
        yield return new WaitForSeconds(1);
        time++;
        timeBool = true;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(time);
        Debug.Log(player.plData.dash);
        if (player.plData.dash)
        {
            image.fillAmount = 1;
            time = 0;
            timeBool = true;
        }
        else
        {
            if(timeBool)
            {
                StartCoroutine(Time());
            }
            image.fillAmount = ((float)time / (float)player.plData.dashCool);
        }
    }
}

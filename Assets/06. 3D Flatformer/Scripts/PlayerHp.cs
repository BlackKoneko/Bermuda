using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHp : MonoBehaviour
{
    public int maxHp;
    private int currentHp;
    private int lifeCount;
    private PlayerData plData;

    [SerializeField] GameObject[] Hearts;
    [SerializeField] TextMeshProUGUI lifeText;

    public int CurrentHp
    {
        get
        { 
            return currentHp;
        }
        set
        {
            currentHp = value;
            
            if(currentHp > maxHp)
                currentHp = maxHp;

            if (currentHp <= 0)
            {
                currentHp = maxHp;
                LifeCount--;
                FindObjectOfType<SpawnPoint>().SpawnPlayer();
            }

            HpUpdate();
        }
    }

    public int LifeCount
    {
        get 
        {
            return lifeCount;
        }
        set
        {
            lifeCount = value;

            if (lifeCount <= 0)
            {
                GameOver();
            }

            lifeText.text = "X " + lifeCount.ToString();
        }
    }

    private void Start()
    {
        plData = FindFirstObjectByType<PlayerData>();
        maxHp = plData.hp / 20;
        CurrentHp = maxHp;
        LifeCount = 3;
    }

    void HpUpdate()
    {
        for(int count = 0; count < Hearts.Length; count++)
        {
            if (count < CurrentHp)
                Hearts[count].SetActive(true);
            else
                Hearts[count].SetActive(false);
        }
    }

    void GameOver()
    {
        SceneManager.LoadScene("Main Lobby");
    }
}

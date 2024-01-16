using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingManager : MonoBehaviour
{
    GameObject gm;
    PlayerProperty playerProperty;
    AdventureGameManager gameManager;
    PlayerData playerData;

    void Start()
    {
        gm = GameObject.Find("Player");
        playerProperty = gm.GetComponent<PlayerProperty>();

        gm = GameObject.Find("GameManager");
        gameManager = gm.GetComponent<AdventureGameManager>();

        playerData = FindObjectOfType<PlayerData>();
    }

    void Update()
    {
        if (playerProperty.bearDie == true)
        {
            BearDie();
        }
        else if (playerProperty.dogDie == true)
        {
            DogDie();
        }
        else if (playerData.adventureClear ==true)
        {
            AdventureClearUI();
        }
        
    }

    public void BearDie()
    {
        gameManager.bearDieCount++;
        SceneManager.LoadScene("BearEnding");
    }
    public void DogDie()
    {
        gameManager.dogDieCount++;
        playerProperty.dogDie = true;
        SceneManager.LoadScene("DogEnding");
    }

    public void AdventureClearUI()
    {
        //¿Áøµ¿Ã∞° ¡‹
    }
}

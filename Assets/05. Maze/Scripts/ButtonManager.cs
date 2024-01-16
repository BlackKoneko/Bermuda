using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void GameControllScene()
    {
        SceneManager.LoadScene("GameControllScene");

    }
    public void GameScene()
    {
        int num = Random.Range(0, 3);
        SceneManager.LoadScene("MazeRoute"+num);
    }
    public void OptionScene()
    {
        SceneManager.LoadScene("StartOption");
    }
    public void LobbyScene()
    {
        SceneManager.LoadScene("Main Lobby");
    }
    public void StartOptionExit()
    {
        SceneManager.LoadScene("Start");
    }
    public void ItemExplain()
    {
        SceneManager.LoadScene("Itemexplain");
    }
    public void Retry()
    {
        GameScene();
    }
}

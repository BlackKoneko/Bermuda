using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSettingManager : MonoBehaviour
{
    public float bgmVolume;
    public float effectVolume;
    public GameObject soundUI;
    public GameObject currentUI;

    [SerializeField] private UiManager uiManager;

    private void Start()
    {
        bgmVolume = 1.0f;
        effectVolume = 1.0f;
        uiManager = FindObjectOfType<UiManager>();
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            if(uiManager.currentUI == null)
            {
                Time.timeScale = 0.0f;
                currentUI = Instantiate(soundUI, GameObject.Find("Canvas").transform.position, Quaternion.identity, GameObject.Find("Canvas").transform);
                uiManager.CurrentUI = currentUI;
            }
            else if(uiManager.currentUI == currentUI)
            {
                Time.timeScale = 1.0f;
                Destroy(currentUI);
                uiManager.CurrentUI = null;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public GameObject currentUI;

    public GameObject CurrentUI
    {
        get
        {
            return currentUI;
        }
        set
        {
            currentUI = value;

            if (currentUI != null)
            {
                Time.timeScale = 0.0f;
            }
            else
            {
                Time.timeScale = 1.0f;
            }
        }
    }

    private void Start()
    {
        int count = FindObjectsOfType<UiManager>().Length;
        if (count > 1)
            Destroy(gameObject);

        currentUI = null;
        DontDestroyOnLoad(gameObject);
    }
}

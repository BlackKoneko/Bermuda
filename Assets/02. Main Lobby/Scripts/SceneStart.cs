using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneStart : MonoBehaviour
{
    public string sceneName;
    private void OnTriggerEnter(Collider other)
    {
        SceneChange();
    }

    public void SceneChange()
    {
        Cursor.lockState = CursorLockMode.None;
        FindObjectOfType<UiManager>().CurrentUI = null;
        SceneManager.LoadScene(sceneName);
    }
}

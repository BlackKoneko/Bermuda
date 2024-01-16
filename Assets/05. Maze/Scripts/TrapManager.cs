using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrapManager : MonoBehaviour
{

    public int damage;
    private void Start()
    {
        damage = 5;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (!other.GetComponent<PlayerManager>().isInvisible)
            {
                FindObjectOfType<PlayerManager>().gameHp -= damage;
                if (FindObjectOfType<PlayerManager>().gameHp <= 0)
                {
                    SceneManager.LoadScene("Die");
                }
            }
        }
    }
}

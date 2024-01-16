using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpRecovery : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(0f, 90f * Time.deltaTime, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerHp playerHp = other.GetComponent<PlayerHp>();

        if (playerHp.TryGetComponent<PlayerHp>(out playerHp))
        {
            playerHp.CurrentHp++;
        }

        Destroy(gameObject);
    }
}

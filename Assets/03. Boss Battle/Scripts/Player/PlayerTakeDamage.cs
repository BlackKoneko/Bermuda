using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTakeDamage : MonoBehaviour
{
    public Player player;
    private void Start()
    {
        player = FindObjectOfType<Player>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "MonWeapon")
        {
            Debug.Log("데미지 입음");
            TakeDamage(other.gameObject.GetComponent<MonWeapon>().atk);
        }
    }   

    public void TakeDamage(int damage)
    {
        if(player.shield <= 0)
        {
            player.hp -= damage;
        }
        else if (player.shield < damage)
        {
            damage -= player.shield;
            player.shield = 0;    
            player.hp -= damage;
        }
        else
        {
            player.shield -= damage;
        }
    }
    // Start is called before the first frame update
    
}

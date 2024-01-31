using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MonsterAtkRange : MonoBehaviour
{
    public bool check;
    public float skillRadius;
    public LayerMask playerLayer;

    private void Start()
    {
        InvokeRepeating("SkillRange", 0.2f, 0.2f);
    }
    private void SkillRange()
    {
        Collider[] players = Physics.OverlapSphere(transform.position, skillRadius, playerLayer);
        if(players.Length > 0)
            check = true;
        else
            check = false;  
    }
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, skillRadius);
    }
}

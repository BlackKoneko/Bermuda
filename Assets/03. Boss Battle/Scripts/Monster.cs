using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{


    public int hp;
    public int maxHp;

    public int speed;
    public int bossType;
    public Transform plTrans;
    public Rigidbody monRb;
    GameObject plObj;


    // Start is called before the first frame update
    void Start()
    {
        plObj = GameObject.Find("Player");
        GetComponent<MonsterAtkRange>();
        monRb = GetComponent<Rigidbody>();
        plTrans = plObj.GetComponent<Transform>();

        hp = maxHp;
    }
    
    
    // Update is called once per frame
    void Update()
    {
        
        if (GetComponentInChildren<MonsterAtkRange>().Check)
        {

        }
        else 
        {
            Vector3 vector = new Vector3(plObj.transform.position.x, transform.position.y, plObj.transform.position.z) - (transform.position);
            monRb.velocity = vector.normalized * speed * 50 * Time.deltaTime;
        }
        Vector3 lookVector = new Vector3(plObj.transform.position.x, transform.position.y, plObj.transform.position.z);
        if(GetComponent<MonsterSkill>().check)
        {
            transform.LookAt(lookVector);
        }
        else
        {

        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }

}

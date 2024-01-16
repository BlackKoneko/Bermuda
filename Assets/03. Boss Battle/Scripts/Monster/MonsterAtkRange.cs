using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MonsterAtkRange : MonoBehaviour
{
    public bool Check;
    public bool atkRange;
    //public MonsterSkill monSkill;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Check = true;
            //monSkill.time = 0;
        }
                
    }
   
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Check = false;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

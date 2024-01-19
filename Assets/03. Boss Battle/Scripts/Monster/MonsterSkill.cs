using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSkill : MonoBehaviour
{


    public GameObject monWeapon;
    public GameObject rightArm;
    public GameObject player;

    public Rigidbody monRb;

    public GameObject[] circleSkillEffect;
    public GameObject squareMatSkillEffect;
    public GameObject straightLineSkillEffect;

    public SoundSettingManager soundSetting;
    public AudioClip[] audioClip;
    AudioSource audioSource;

    public bool timeX;
    public int time;
    public bool skill;
    public int speed;
    public int skillRandom;

    public bool check;
    IEnumerator Time()
    {
        while(timeX)
        {
            yield return new WaitForSeconds(1);
            time++;
        }
        yield return null;
    }

    IEnumerator StraightPatternAction()
    {
        yield return new WaitForSeconds(1);
        audioSource.clip = audioClip[0];
        audioSource.Play();
        monRb.AddRelativeForce(Vector3.forward.normalized * speed, ForceMode.Impulse);
        monWeapon.GetComponent<BoxCollider>().enabled = true;

        yield return new WaitForSeconds(1);
        time = 0;
        check = true;
    }

    IEnumerator WindmillPatternAction()
    {
        yield return new WaitForSeconds(1);
        audioSource.clip = audioClip[1];
        audioSource.Play();
        monWeapon.GetComponent<BoxCollider>().enabled = true;
        int count = 0;
        while (count <= 100)
        {
            transform.Rotate(0, 20, 0);
            
            yield return new WaitForSeconds(0.01f);
            
            count++;
        }
        
        yield return new WaitForSeconds(1);
        time = 0;
        check = true;
    }
    IEnumerator WideAreaPatternAction()
    {
        int current = 0;
        int dir = 1;
        while(dir != -1 && current != 0)
        {
            yield return new WaitForSeconds(1);
            Instantiate(circleSkillEffect[current], transform.position,Quaternion.identity);
            current+=dir;
            if(current >= 2)
            {
                dir *= -1;
            }
        }
        
        //yield return new WaitForSeconds(1);
        //Instantiate(circleSkillEffect[1], transform.position,Quaternion.identity);
        
        //yield return new WaitForSeconds(1);
        //Instantiate(circleSkillEffect[2], transform.position,Quaternion.identity);
        
        //yield return new WaitForSeconds(1);
        //Instantiate(circleSkillEffect[1], transform.position, Quaternion.identity);
        
        //yield return new WaitForSeconds(1);
        //Instantiate(circleSkillEffect[0], transform.position, Quaternion.identity);
        monWeapon.GetComponent<BoxCollider>().enabled = true;
        
        yield return new WaitForSeconds(1);
        time = 0;
        check = true;
    }

    IEnumerator StraightLinePatternAction()
    {
        yield return new WaitForSeconds(1);
        Instantiate(straightLineSkillEffect, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1);
        Instantiate(straightLineSkillEffect, transform.position, Quaternion.EulerRotation(0,120,0));
        yield return new WaitForSeconds(1);
        Instantiate(straightLineSkillEffect, transform.position, Quaternion.EulerRotation(0, 240, 0));
        yield return new WaitForSeconds(1);
        Instantiate(straightLineSkillEffect, transform.position, Quaternion.EulerRotation(0, 360, 0));
        yield return new WaitForSeconds(1);
        Instantiate(squareMatSkillEffect, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1);
        monWeapon.GetComponent<BoxCollider>().enabled = true;

        yield return new WaitForSeconds(1);
        time = 0;
        check = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        timeX = true;
        time = 0;
        skillRandom = 0;
        monRb = GetComponent<Rigidbody>();
        StartCoroutine(Time());
        check = true;

        soundSetting = FindObjectOfType<SoundSettingManager>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.volume = soundSetting.effectVolume;

        if (GetComponentInChildren<MonsterAtkRange>().Check)
        {
            if(time <=0)
            {
                
            }
            if (time >=1 && check)
            {
                switch(GetComponent<Monster>().bossType)
                {
                    case 1:
                        skillRandom = Random.Range(0, 2);
                        break;
                    case 2:
                        skillRandom = Random.Range(2, 4);
                        break;
                    case 3:
                        skillRandom = Random.Range(0, 4);
                        break;
                }
                

                check = false;
                switch (skillRandom)
                {
                    case 0:
                            Debug.Log("스킬발동1");
                           
                            StartCoroutine(StraightPatternAction());
                  
                            
                            break;
                    case 1:
                            Debug.Log("스킬발동2");

                        StartCoroutine(WindmillPatternAction());

                            break;
                    case 2:
                        StartCoroutine(WideAreaPatternAction());
                            Debug.Log("스킬발동3");
                            break;
                    case 3:
                        StartCoroutine(StraightLinePatternAction());
                        Debug.Log("스킬발동4");
                        break;

                }

                   
            }


        }
        else
        {

            monWeapon.GetComponent<BoxCollider>().enabled = false;
            rightArm.transform.Rotate(0, 0, 0);
        }
    }


}

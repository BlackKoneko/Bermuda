 using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BearMotion : MonoBehaviour
{
    public AudioClip[] auClip;
    public float timeCount;

    public float result;
    int i;
    public int soundNum;

    GameObject gm;
    AdventureGameManager gmComponent;
    EndingManager emComponent;
    PlayerProperty playerProperty;
    public GameObject audioGameobj;

    public bool start;
    public BearState state;

    public enum BearState
    {
        deepSleep,
        ramSleep,
        halfEyes,
        WakeUp
    };
    
    void Start()
    {
        gm = GameObject.Find("GameManager");
        gmComponent = gm.GetComponent<AdventureGameManager>();

        gm = GameObject.Find("Player");
        playerProperty = gm.GetComponent<PlayerProperty>();

        result = Random.Range(4, 7);
    }

    void Update()
    {
        if (start == true)
        {
            if (state == BearState.deepSleep)
                DeepSleep(); 
            else if (state == BearState.ramSleep)
                RamSleep(); 
            else if (state == BearState.halfEyes)
                HalfEyes();
            else if (state == BearState.WakeUp)
                WakeUp();
        }
        else if(start == false)
        {
            Nothing();
        }

    }

    public void TimeValue(int i)
    {
        timeCount = Time.time + result + i;
    }//타입값 모션별로 조금 다르게 적용
    public void BeatState()
    {
        state = BearState.ramSleep;
    }//외부에서 기본 뒤척임 적용을 위한 함수

    void DeepSleep() //푹잠
    {
        if (soundNum != 0) //음악재생조건 1회만 실행되게 체크실행
        {
            Setting(0);
            soundNum = 0;//담에는 실행안되게
        }
        if (gmComponent.keyCount >= result) //키카운트 확인
        {
            TimeValue(2);//다음 뒤척임시 기간 2초더 늘려주기 위함
            gmComponent.keyCount = 0; //조건해당 시 상태넘어가기전 키카운트 초기화
            state = BearState.ramSleep;
        }
        else if (timeCount <= Time.time) //타임오버시
        {
            TimeValue(0);
            gmComponent.keyCount = 0; //무조건 상태넘어가지전 키카운트 초기화
            state = BearState.deepSleep;
        }
    }
    public void RamSleep() //뒤척임
    {
        if (soundNum != 1) //음악재생조건 1회만 실행되게 체크실행
        {
            Debug.Log("뒤척임");
            Setting(1);
            soundNum = 1;
        }
        if (gmComponent.keyCount >= result)
        {
            TimeValue(0);
            gmComponent.keyCount = 0;
            state = BearState.halfEyes;
        }
        else if (timeCount <= Time.time)
        {
            TimeValue(0);
            gmComponent.keyCount = 0;
            state = BearState.deepSleep;
        }
    }
    void HalfEyes() //실눈뜸
    {
        Debug.Log("실눈뜸");
        audioGameobj.GetComponent<AudioSource>().Stop();
        soundNum = 4;//null과 비슷한 역할
        if (gmComponent.keyCount >= 2)
        {
            TimeValue(2);
            gmComponent.keyCount = 0;
            state = BearState.WakeUp;
        }
        else if (timeCount <= Time.time)
        {
            TimeValue(2);
            gmComponent.keyCount = 0;
            state = BearState.ramSleep;
        }
    }
    public void WakeUp() //눈뜸
    {
        gmComponent.keyCount = 0;
        soundNum = 4;//null과 비슷한 역할
        Debug.Log("눈뜸 다이");
        start = false;
        playerProperty.bearDie = true;

    }
    void Nothing()
    {
        gmComponent.keyCount = 0;
        audioGameobj.GetComponent<AudioSource>().Stop();
    }

    void OnCollisionEnter(Collision collision)//바로일어나는 조건
    {
        Debug.Log("곰과 충돌 : "+collision.gameObject.name);
        if (collision.gameObject.tag == "Player")
        {
            WakeUp();
        }
    }

    void Setting(int i)
    {
        if (gmComponent.keyCount == 0)
        {
            audioGameobj.GetComponent<AudioSource>().clip = auClip[i];
            audioGameobj.GetComponent<AudioSource>().Play();
        }
    }
}

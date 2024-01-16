using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class KitchenCount : MonoBehaviour
{
    GameObject gm;
    BearMotion bearMotion;

    public TextMeshProUGUI tempText;
    IEnumerator coroutine; //스탑코루틴을 사용하기 위해 선언해주는 것
    void Start()
    {
        gm = FindObjectOfType<BearMotion>().gameObject;
        bearMotion = gm.GetComponent<BearMotion>();

        coroutine = OnSecondCheckCo(); //스타트가 잘된다해서 스탑이 잘되진않음.
                                       //이유는 IEnumerator 메서드를 실행할때마다 참조값이 바뀌기 때문
                                       //OnSecondCheckCo 메서드를 실행한 반환값을 StartCoroutine 메서드에 전달
                                       //즉 OnSecondCheckCo 실행 마다 참조값이 바뀌게되어 스탑을 해도 중단되지 않음
                                       //따라서 변수 선언 후 할당해줄 것
    }

    void Update()
    {
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            StartCoroutine(coroutine);

            bearMotion.start = true;
            bearMotion.soundNum = 4;//초기화 개념 안에들어가면 상태에 따라 알아서 바뀔것
            Debug.Log("곰문곰문입장");
            bearMotion.TimeValue(2);
            bearMotion.BeatState();
        }
    }
    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            StopCoroutine(coroutine); //이것은 일시정지
            coroutine = OnSecondCheckCo(); //코루틴 시간 초기화
            Debug.Log("곰문곰문퇴장");
            bearMotion.start = false;
            bearMotion.soundNum = 4;
            bearMotion.BeatState();
        }
    }

    IEnumerator OnSecondCheckCo()
    {
        int time = 180;
        while (time > 0)
        {
            //초지남 카운트
            tempText.text = time + " 초";
            yield return new WaitForSeconds(1);
            time--;
        }
        bearMotion.WakeUp();
    }
}
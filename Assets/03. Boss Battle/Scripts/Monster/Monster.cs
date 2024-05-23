using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Monster : MonoBehaviour
{
    private enum State
    {
        Idle,
        Move,
        Attack
    }

    public int hp;
    public int maxHp;

    public int speed;
    public int bossType;
    public Transform plTrans;
    public Rigidbody monRb;
    public GameObject plObj;
    public MonsterSkill monsterSkill;
    MonsterAtkRange monsterAtkRange;

    private FSM fsm;
    private State curState; 

    // Start is called before the first frame update
    void Start()
    {
        plObj = GameObject.Find("Player");
        GetComponent<MonsterAtkRange>();
        monRb = GetComponent<Rigidbody>();
        plTrans = plObj.GetComponent<Transform>();
        monsterAtkRange =GetComponentInChildren<MonsterAtkRange>();
        monsterSkill = GetComponent<MonsterSkill>();
        hp = maxHp;
        curState = State.Idle;
        fsm = new FSM(new IdleState(this));
    }
    
    
    // Update is called once per frame
    void Update()
    {
        switch (curState)
        {
            case State.Idle:
                if (!monsterAtkRange.check)
                    ChangeState(State.Move);
                else
                    ChangeState(State.Attack);
                break;
            case State.Move:
                if (monsterAtkRange.check)
                    ChangeState(State.Attack);
                break;
            case State.Attack:
                if (!monsterAtkRange.check)
                    ChangeState(State.Idle);
                break;
        }
        fsm.UpdateState();
        if(!monsterSkill.skillCheck)
            transform.LookAt(new Vector3(plObj.transform.position.x, plObj.transform.position.y, plObj.transform.position.z));
    }
    private void ChangeState(State nextState)
    {
        curState = nextState;
        switch (curState)
        {
            case State.Idle:
                fsm.ChangeState(new IdleState(this));
                break;
            case State.Move:
                fsm.ChangeState(new MoveState(this));
                break;
            case State.Attack:
                fsm.ChangeState(new AttackState(this));
                break;
        }
    }
}

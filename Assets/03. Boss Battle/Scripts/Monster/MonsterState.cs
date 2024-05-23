using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public abstract class MonsterState 
{
    protected Monster monster;
    protected MonsterState(Monster monster)
    {
        this.monster = monster;
    }
    public abstract void OnStateEnter();
    public abstract void OnStateUpdate();
    public abstract void OnStateExit();

}
public class IdleState : MonsterState
{
    public IdleState(Monster monster) : base(monster) { }
    public override void OnStateEnter() { }
    public override void OnStateExit() { }
    public override void OnStateUpdate() { }
}
public class AttackState : MonsterState
{
    public AttackState(Monster monster) : base(monster) { }

    public override void OnStateEnter()
    {
        monster.monsterSkill.enabled = true;
        monster.monsterSkill.time = 0;
    }

    public override void OnStateExit()
    {
        monster.monsterSkill.enabled = false;
    }

    public override void OnStateUpdate() { }
}
public class MoveState : MonsterState
{
    public MoveState(Monster monster) : base(monster) { }

    private GameObject player;
    private Rigidbody rigidbody;
    public override void OnStateEnter()
    {
        player = monster.plObj;
        rigidbody = monster.monRb;
    }

    public override void OnStateExit() { }

    public override void OnStateUpdate()
    {
        monster.transform.LookAt(new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z));
        Vector3 vector = new Vector3(player.transform.position.x, monster.transform.position.y, player.transform.position.z) - (monster.transform.position);
        rigidbody.velocity = vector.normalized * monster.speed * 50 * Time.deltaTime;
    }
}

public class FSM
{
    private MonsterState curState;
    public FSM(MonsterState initState)
    {
        curState = initState;
    }
    public void ChangeState(MonsterState nextState)
    {
        if (curState == nextState)
        {
            return;
        }
        curState.OnStateExit();
        curState = nextState;
        curState.OnStateEnter();
    }
    public void UpdateState()
    {
        curState.OnStateUpdate();
    }
}

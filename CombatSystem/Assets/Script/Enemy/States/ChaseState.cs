using UnityEngine;

public class ChaseState : State<EnemyController>
{
    public override void Enter(EnemyController owner)
    {
        Debug.Log("ü�̽� Enter ������Ʈ");
    }

    public override void Execute()
    {
        Debug.Log("ü�̽� Execute ������Ʈ");
    }

    public override void Exit()
    {
        Debug.Log("ü�̽� Exit ������Ʈ");
    }


}

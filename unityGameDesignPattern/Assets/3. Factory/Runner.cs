using UnityEngine;

public class Runner : EnemyBase
{

    public override void Initialize(Vector3 position)
    {
        base.Initialize(position);
        health = 30;
        speed = 6f;
        damage = 5f;
    }
    public override void Attak()
    {
        Debug.Log("Runner�� ������ ���� ������ �մϴ�.");
    }
}
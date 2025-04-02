using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Enemy _enemy;

    void Start()
    {
        _enemy = GetComponent<Enemy>();
    }

    void Update()
    {
        //Ű �Է¿� ���� �̵� ���� ����(�׽�Ʈ ��)
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _enemy.SetMovementStrategy(new StraightMovement());
            Debug.Log("���� �̵� �������� ����");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _enemy.SetMovementStrategy(new ZigzagMovement());
            Debug.Log("������� �̵� �������� ����");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _enemy.SetMovementStrategy(new CircularMovement());
            Debug.Log("���� �̵� �������� ����");
        }
    }
}

using UnityEngine;


//## 3. ���丮(Factory) ����

//���丮 ������ ��ü ���� ������
//ĸ��ȭ�Ͽ� Ŭ���̾�Ʈ �ڵ�� �и��ϴ� �����Դϴ�.
//Unity������ �پ��� ��, ������, ȿ�� ���� ������ �� �����մϴ�.

//�� Ÿ�� ������
public enum EnemyType
{
    Grunt,
    Runner,
    Tank,
    Boss
}

//��� ���� �⺻ �������̽�
public interface IEnemy
{
    void Initialize(Vector3 position);
    void Attak();
    void TakeDamage(float damage);
}

//�⺻�� Ŭ����
public abstract class EnemyBase : MonoBehaviour, IEnemy
{
    public float health;
    public float speed;
    public float damage;


    public virtual void Initialize(Vector3 position)
    {
        transform.position = position;
    }
    public abstract void Attak();

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }


    protected virtual void Die()
    {
        Destroy(gameObject);
    }
}
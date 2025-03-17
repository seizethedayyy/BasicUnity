using UnityEngine;

public class PBullet : MonoBehaviour
{
    public float Speed = 4.0f;
    //���ݷ�
    public int Attack = 10;
    //����Ʈ
    public GameObject effect;

    void Update()
    {
        //�̻��� ���ʹ������� �����̱�
        //���� ���� * ���ǵ� * Ÿ��
        transform.Translate(Vector2.up * Speed * Time.deltaTime);
    }


    //ȭ�� ������ �������
    private void OnBecameInvisible()
    {
        //�ڱ� �ڽ� �����
        Destroy(gameObject);
    }


    //�浹 ó��
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {

            //����Ʈ ����
            GameObject go = Instantiate(effect, transform.position, Quaternion.identity);
            //1�� �ڿ� �����
            Destroy(go, 1);

            //���� ����
            //collision.gameObject.GetComponent<Monster>().Damage(Attack);
            PoolManager.Instance.Return(collision.gameObject);

            //�̻��� ����
            Destroy(gameObject);

        }

        if (collision.CompareTag("Boss"))
        {

            //����Ʈ ����
            GameObject go = Instantiate(effect, transform.position, Quaternion.identity);
            //1�� �ڿ� �����
            Destroy(go, 1);

            //�̻��� ����
            Destroy(gameObject);

        }
    }
}
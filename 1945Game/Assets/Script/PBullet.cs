using UnityEngine;

public class PBullet : MonoBehaviour
{
    public float Speed = 4.0f;
    //���ݷ�
    //����Ʈ
    public GameObject effect;

    void Update()
    {
        //�̻��� ���� �������� ������
        //���� ���� * ���ǵ� * Ÿ��
        transform.Translate(Vector2.up * Speed * Time.deltaTime);
    }

    //ȭ�� ������ ���� ���
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    //�浹 ó��
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Monster"))
        {
            //����Ʈ ����
            GameObject go = Instantiate(effect, transform.position, Quaternion.identity);
            //1�� �ڿ� �����
            Destroy(go, 1);

            //����
            Destroy(collision.gameObject);

            //�̻��� ����
            Destroy(gameObject);
        }
    }
}

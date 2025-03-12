using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float moveSpeed = 0.45f;
    public GameObject exposion;

    void Start()
    {

    }
    void Update()
    {
        //Y축 이동
        transform.Translate(0, moveSpeed * Time.deltaTime, 0);
    }

    private void OnBecameInvisible()
    {
        //미사일이 화면 밖으로 나갈 경우 삭제
        Destroy(gameObject);
    }
    //2D충돌 트리거이벤트
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //미사일과 적이 부딫혔다
        //if (collision.gameObject.tag == "Enemy")
        if(collision.gameObject.CompareTag("Enemy")) //Comparetag 더 안정적
        {
            //폭발 이펙트 생성
            Instantiate(exposion, transform.position, Quaternion.identity);
            //죽음 사운드
            SoundManager.instance.SoundDie();
            //점수 올려주기
            GameManager.intance.AddScore(10);
            //적 지우기
            Destroy(collision.gameObject);
            //총알 지우기 자기자신
            Destroy(gameObject);
        }
    }
}
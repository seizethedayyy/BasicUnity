using UnityEngine;

public class PBullet : MonoBehaviour
{
    public float Speed = 4.0f;
    //공격력
    //이펙트
    public GameObject effect;

    void Update()
    {
        //미사일 위쪽 방향으로 움직이
        //위의 방향 * 스피드 * 타임
        transform.Translate(Vector2.up * Speed * Time.deltaTime);
    }

    //화면 밖으로 나갈 경우
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    //충돌 처리
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Monster"))
        {
            //이펙트 생성
            GameObject go = Instantiate(effect, transform.position, Quaternion.identity);
            //1초 뒤에 지우기
            Destroy(go, 1);

            //몬스터
            Destroy(collision.gameObject);

            //미사일 삭제
            Destroy(gameObject);
        }
    }
}

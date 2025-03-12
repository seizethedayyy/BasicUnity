using UnityEngine;

public class launcher : MonoBehaviour
{
    public GameObject bullet; //미사일 프리팹을 가져올 변수

    void Start()
    {
        //InvokeRepeating(함수 이름, 초기 지연 시간, 지연할 시간)
        InvokeRepeating("Shoot", 0.5f, 0.5f);
    }

    void Shoot()
    {
        //미사일 프리팹, 런쳐 포지션 방향값 안 줌
        Instantiate(bullet, transform.position, Quaternion.identity);

        //사운드 사용해 보기 (사운드 매니저에서 총 사운드 바로 실행)
        SoundManager.instance.PlayBulletSound();
    }

    void Update()
    {
        
    }
}

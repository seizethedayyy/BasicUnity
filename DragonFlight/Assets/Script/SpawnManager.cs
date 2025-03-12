using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //몬스터 가지고 오기 
    public GameObject enemy;

    //적을 생성하는 함수
    void SpawnEnemy()
    {
        float randomX = Random.Range(-2f, 2f); //적이 나타날 x 좌표를 랜덤으로 생성하기

        //적을 랜덤한 위치에 생성
        Instantiate(enemy, new Vector3(randomX, transform.position.y, 0f), Quaternion.identity);

    }

    void Start()
    {
        //SpawnEnemy  1  0.5f 
        InvokeRepeating("SpawnEnemy", 1, 0.5f);
    }
    void Update()
    {

    }
}
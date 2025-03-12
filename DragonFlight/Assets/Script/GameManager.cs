using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    //싱글톤
    //어디에서나 접근 할수 있도록 static(정적)으로 자기자신을 저장해서 싱글톤이라는 디자인패턴을 
    //사용해본다.
    public static GameManager intance;
    public Text scoreText; //점수를 표시하는 Text객체를 에디터에서 받아옵니다.
    public Text StartText; //게임시작전3,2,1

    int score = 0; //점수를 관리합니다.

    private void Awake()
    {
        if (intance == null) //정적으로 자신을 체크합니다. null인지
        {
            intance = this; //자기자신을 저장한다.
        }
    }

    void Start()
    {
        StartCoroutine("StartGame");
    }

    IEnumerator StartGame()
    {
        int i = 3;

        Time.timeScale = 0; //전체 시간멈춤

        while (i > 0)
        {
            StartText.text = i.ToString();

            //  yield return new WaitForSeconds(1);
            yield return new WaitForSecondsRealtime(1); //게임이 멈춰도 동작하는 대기
            i--;

            if (i == 0)
            {
                StartText.gameObject.SetActive(false);  //UI감추기
                Time.timeScale = 1; //다시 시간 정상으로
            }
        }
    }







    public void AddScore(int num)
    {
        score += num; //점수를 더해줍니다.
        scoreText.text = "Score : " + score; //텍스트에 반영합니다.
    }





}
using System.Collections;
using UnityEngine;

public class CoroutineStudy : MonoBehaviour
{
    void Start()
    {
        StartCoroutine("ExampleCoroutine");
    }

    IEnumerator ExampleCoroutine()
    {
        //Debug.Log("�ڷ�ƾ ����");
        //yield return new WaitForSeconds(2f); //2�� ���
        //Debug.Log("2�� �� ����");
        while (true)
        {
            Debug.Log("�� 1�ʸ��� ����!");
            yield return new WaitForSeconds(1f);
        }
    }
}

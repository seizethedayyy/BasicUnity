using System.Collections;
using UnityEngine;


//��Ʈ��ž����
//1.������ ī�޶� ��鸲ȿ�� �߰�
//2.�ð� ������ �������κ���
//3.��Ʈ��ž ���� �Ķ����ȭ

//�ֿ� ���� ����:

//�ν����� ���� ����

//SerializeField �Ӽ��� Header �Ӽ��� ����Ͽ� �ν����� UI�� ����
//�������� �������� �׷�ȭ
//ī�޶� ��鸲 ����

//������ ��ġ�� ī�޶� ���� �� �������� ȿ�� ����
//��鸲 ������ �󵵸� ������ �� �ִ� �Ķ���� �߰�
//���� ī�޶� ��ġ�� �����ϰ� ����
//�ð� ���� ����

//�ð� �������� �ε巴�� ����
//��Ʈ��ž ������ �Ķ���ͷ� ���� ����
//�ߺ� ���� ���� ���� ����
//�ڵ� ������

//�ڷ�ƾ ���� ����
//��Ȯ�� ������ ���
//������ ���� ������ ���
//�� ������ ������ ����ϸ� �� �پ��ϰ� Ŀ���͸����� ������ ��Ʈ��ž ȿ���� ���� �� �ֽ��ϴ�.


public class HitStop : MonoBehaviour
{
    public static HitStop Instance;


    [Header("Time Settings")]
    public float stopTime = 0.1f;
    public float timeScaleRecoverySpeed = 0.1f;

    [Header("Camera Shake")]
    [SerializeField] private Transform shakeCam;
    public float shakeIntensity = 0.1f;
    public float shakeFrequency = 0.1f;

    private bool isHitStopped;
    private Vector3 originalCamPosition;
    private Coroutine shakeCoroutine;


    private void Awake()
    {
        if(Instance == null)
        Instance = this;
    }



    public void StopTime()
    {
        if (!isHitStopped)
        {
            isHitStopped = true;
            Time.timeScale = 0f;

            if (shakeCoroutine != null)
                StopCoroutine(shakeCoroutine);

            shakeCoroutine = StartCoroutine(ShakeCamera());
            StartCoroutine(ReturnTimeScale());
        }
    }

    private IEnumerator ShakeCamera()
    {
        originalCamPosition = shakeCam.localPosition;
        float elapsed = 0f;

        while (elapsed < stopTime)
        {
            float x = Random.Range(-1f, 1f) * shakeIntensity * stopTime;
            float y = Random.Range(-1f, 1f) * shakeIntensity * stopTime;

            shakeCam.localPosition = new Vector3(x, y, originalCamPosition.z);

            elapsed += Time.unscaledDeltaTime;
            yield return new WaitForSecondsRealtime(shakeFrequency);
        }

        shakeCam.localPosition = originalCamPosition;
    }

    private IEnumerator ReturnTimeScale()
    {
       

        yield return new WaitForSecondsRealtime(stopTime);

        while (Time.timeScale < 1f)
        {
            Time.timeScale = Mathf.MoveTowards(Time.timeScale, 1f, Time.unscaledDeltaTime * timeScaleRecoverySpeed);
            yield return null;
        }

        Time.timeScale = 1f;
        isHitStopped = false;
        if (shakeCoroutine != null)
            StopCoroutine(shakeCoroutine);
    }
}






//public class HitStop : MonoBehaviour
//{




//    bool stop;
//    public float stopTime;

//    public Transform shakeCam;
//    public Vector3 shake;


//    public void StopTime()
//    {
//        if(!stop)
//        {
//            stop = true;
//            shakeCam.localPosition = shake;
//            Time.timeScale = 0f;

//            StartCoroutine("ReturnTimeScale");
//        }

//    }

//    IEnumerator ReturnTimeScale()
//    {
//        yield return new WaitForSecondsRealtime(stopTime);// ���� �ð����� ���
//        Time.timeScale = 1;
//        shakeCam.localPosition = Vector3.zero;
//        stop = false;
//    }





//}

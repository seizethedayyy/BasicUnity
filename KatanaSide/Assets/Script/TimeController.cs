using UnityEngine;

public class TimeController : MonoBehaviour
{
    private static TimeController instance;
    public static TimeController Instance { get { return instance; } }

    public float slowMotionTimeScale = 0.3f;
    public float slowMotionDuration = 0.5f; // ���ο� ��� ���� �ð�
    private float slowMotionTimer = 0f;   // Ÿ�̸�

    public bool isSlowMotion { get; private set; }

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    void Update()
    {
        if (isSlowMotion)
        {
            slowMotionTimer += Time.unscaledDeltaTime;
            if (slowMotionTimer >= slowMotionDuration)
            {
                SetSlowMotion(false); // ���ο� ��� ����
            }
        }
    }

    public float GetTimeScale()
    {
        return isSlowMotion ? slowMotionTimeScale : 1f;
    }

    public void SetSlowMotion(bool slow)
    {
        isSlowMotion = slow;
        if (slow)
        {
            slowMotionTimer = 0f;
            Time.timeScale = slowMotionTimeScale;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
}

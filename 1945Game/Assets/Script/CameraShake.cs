using Unity.Cinemachine;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake instance;
    //Impulse Source������Ʈ ����
    private CinemachineImpulseSource impulseSource;

    void Awake()
    {
        instance = this;


    }
    public void SetImpulseSource(CinemachineImpulseSource source)
    {
        impulseSource = source;
    }
    //ī�޶���ũ ����
    public void CameraShakeShow()
    {
        if (impulseSource != null)
        {
            //�⺻ �������� ���޽� ����
            impulseSource.GenerateImpulse();
        }
    }


}
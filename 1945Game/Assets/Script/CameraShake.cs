using Unity.Cinemachine;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake instance;
    //Impulse Source컴포넌트 참조
    private CinemachineImpulseSource impulseSource;

    void Awake()
    {
        instance = this;


    }
    public void SetImpulseSource(CinemachineImpulseSource source)
    {
        impulseSource = source;
    }
    //카메라쉐이크 동작
    public void CameraShakeShow()
    {
        if (impulseSource != null)
        {
            //기본 설정으로 임펄스 생성
            impulseSource.GenerateImpulse();
        }
    }


}
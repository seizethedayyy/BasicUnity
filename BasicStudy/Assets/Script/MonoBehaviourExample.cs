using UnityEngine;

public class MonoBehaviourExample : MonoBehaviour
{
    
    void Start()
    {
        Debug.Log("Start: ������ ���۵� �� ȣ��˴ϴ�.");
    }

    void Update()
    {
        Debug.Log("Update: �����Ӹ��� ȣ��˴ϴ�.");
    }

    private void FixedUpdate()
    {
        Debug.Log("Fixedupdate: ���� ���꿡 ���˴ϴ�.");
    }
}

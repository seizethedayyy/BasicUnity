using UnityEngine;

public class StateMachine
{
    private IState currentState;

    public void ChangeState(IState newState)
    {
        currentState?.Exit(); //���� ������ Exit() ����
        currentState = newState; //�� ���·� ����
        currentState.Enter(); //�� ������ Enter() ����
    }

    public void Update()
    {
        currentState?.Update(); //���� ������ Update() ����
    }
}

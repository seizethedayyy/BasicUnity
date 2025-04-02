using UnityEngine;
using UnityEngine.UIElements.Experimental;

//##4. ��Ʈ��Ƽ��(Strategy) ����
//��Ʈ��Ƽ�� ������ �˰����� ĸ��ȭ�ϰ� �ʿ信 ���� ��ü�� �� �ְ� �ϴ� �����Դϴ�.
//Unity������ AI �ൿ, ĳ���� ������ � �����մϴ�.

//�̵� ���� �������̽�

public interface IMovementStrategy
{
    void Move(Transform transform, float speed);
}

//���� �̵� ����
public class StraightMovement : IMovementStrategy
{
    public void Move(Transform transform, float speed)
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}

//������� �̵� ����
public class ZigzagMovement : IMovementStrategy
{
    private float _amplitude = 2f;
    private float _frequency = 2f;
    private float _time = 0;

    public void Move(Transform transform, float speed)
    {
        _time += Time.deltaTime;

        //���� �̵�
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        //�¿� ������ �߰�
        float x0ffset = Mathf.Sin(_time * _frequency) * _amplitude;
        transform.position = new Vector3(x0ffset, transform.position.y, transform.position.z);
    }
}

//���� �̵� ����
public class CircularMovement : IMovementStrategy
{
    private float _radius = 5f;
    private float _angularSpeed = 50f;
    private float _angle = 0;
    private Vector3 _center;
    private bool _isInitialized = false;

    public void Move(Transform transform, float speed)
    {
        if (!_isInitialized)
        {
            _center = transform.position;
            _isInitialized = true;
        }

        _angle += _angularSpeed * Time.deltaTime;

        float x = _center.x + Mathf.Cos(_angle * Mathf.Deg2Rad) * _radius;
        float z = _center.z + Mathf.Sin(_angle * Mathf.Deg2Rad) * _radius;

        transform.position = new Vector3(x, transform.position.y, z);

        //ȸ�� ���� ���
        transform.LookAt(new Vector3(
              _center.x + Mathf.Cos((_angle + 90) * Mathf.Deg2Rad) * _radius
            , transform.position.y
            , _center.z + Mathf.Sin((_angle + 90) * Mathf.Deg2Rad) * _radius
            ));
    }
}

public class Enemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;

    //���� �̵� ����
    private IMovementStrategy _movementStrategy;

    void Start()
    {
        //�⺻ �̵� ����
        _movementStrategy = new StraightMovement();
    }

    //�̵� ���� ���� �޼���
    public void SetMovementStrategy(IMovementStrategy strategy)
    {
        _movementStrategy = strategy;
    }

    void Update()
    {
        if(_movementStrategy != null)
        {
            _movementStrategy.Move(transform, moveSpeed);
        }
    }
}

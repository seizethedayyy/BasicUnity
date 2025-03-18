using TreeEditor;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //���ǵ�
    public float moveSpeed = 5f;

    Animator ani; //�ִϸ����͸� ������ ����

    public GameObject[] bullet;  //�Ѿ� ���� 4�� �迭�� ���鿹��
    public Transform pos = null;

    public int power = 0;
    [SerializeField]
    private GameObject powerup;  //private �ν����Ϳ��� ����ϴ¹��



    //������
    public GameObject lazer;
    public float gValue = 0;

    public Image Gage;



    void Start()
    {
        ani = GetComponent<Animator>();
    }


    void Update()
    {
        //����Ű������ ������
        float moveX = moveSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        float moveY = moveSpeed * Time.deltaTime * Input.GetAxis("Vertical");

        // -1   0   1
        if (Input.GetAxis("Horizontal") <= -0.5f)
            ani.SetBool("left", true);
        else
            ani.SetBool("left", false);


        if (Input.GetAxis("Horizontal") >= 0.5f)
            ani.SetBool("right", true);
        else
            ani.SetBool("right", false);


        if (Input.GetAxis("Vertical") >= 0.5f)
        {
            ani.SetBool("up", true);
        }
        else
        {
            ani.SetBool("up", false);
        }

        //�����̽�
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //������ ��ġ ���� �ְ� ����
            Instantiate(bullet[power], pos.position, Quaternion.identity);
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            gValue += Time.deltaTime;
            Gage.fillAmount = gValue;

            if (gValue >= 1)
            {
                GameObject go = Instantiate(lazer, pos.position, Quaternion.identity);
                Destroy(go, 3);
                gValue = 0;
            }
        }
        else
        {
            gValue -= Time.deltaTime;

            if (gValue <= 0)
            {
                gValue = 0;
            }

            Gage.fillAmount = gValue;

        }






        transform.Translate(moveX, moveY, 0);



        //ĳ������ ���� ��ǥ�� ����Ʈ ��ǥ��� ��ȯ���ش�.
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        viewPos.x = Mathf.Clamp01(viewPos.x); //x���� 0�̻�, 1���Ϸ� �����Ѵ�.
        viewPos.y = Mathf.Clamp01(viewPos.y); //y���� 0�̻�, 1���Ϸ� �����Ѵ�.
        Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos);//�ٽÿ�����ǥ�� ��ȯ
        transform.position = worldPos; //��ǥ�� �����Ѵ�.




    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            power += 1;
            if (power >= 3)
                power = 3;


            //�Ŀ���
            GameObject go = Instantiate(powerup, transform.position, Quaternion.identity);
            Destroy(go, 1);

            //������ ���� ó��
            Destroy(collision.gameObject);
        }
    }
}
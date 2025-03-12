using UnityEngine;

public class MoveObject : MonoBehaviour
{

    public float speed = 5.0f; //이동속도


    void Update()
    {

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        //transform.position += move * speed * Time.deltaTime;
        transform.Translate(move * speed * Time.deltaTime);
    }
}
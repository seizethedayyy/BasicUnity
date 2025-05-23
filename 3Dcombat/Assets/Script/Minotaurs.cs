using UnityEditor.SpeedTree.Importer;
using UnityEngine;

public class Minotaurs : MonoBehaviour
{
    public Animator minoAnim;
    public Transform target;
    public float minoSpeed;
    bool enableAct;
    int atkStep;


    void Start()
    {
        minoAnim = GetComponent<Animator>();
        enableAct = true;
    }


    private void RotateMino()
    {
        Vector3 dir = target.position - transform.position;
        dir.y = 0; // 수직 방향 제거 (y축 고정)

        if (dir != Vector3.zero) // 방향 벡터가 0이 아닌 경우에만 회전
        {
            Quaternion targetRotation = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 5 * Time.deltaTime);
        }
    }

    void MoveMino()
    {
        if((target.position - transform.position).magnitude >= 3)
        {
            minoAnim.SetBool("Walk", true);
            transform.Translate(Vector3.forward * minoSpeed * Time.deltaTime, Space.Self);
        }

        if((target.position - transform.position).magnitude <3)
        {
            minoAnim.SetBool("Walk", false);
        }

    }

        
    void Update()
    {
        
        if(enableAct)
        {
            RotateMino();
            MoveMino();
        }
    }

    void MinoAtk()
    {
        if((target.position - transform.position).magnitude < 10)
        {
            switch(atkStep)
            {
                case 0:
                    atkStep += 1;
                    minoAnim.Play("attack1");
                    break;
                case 1:
                    atkStep += 1;
                    minoAnim.Play("attack2");
                    break;
                case 2:
                    atkStep =0;
                    minoAnim.Play("attack3");
                    break;
            }
        }
    }

    void FreezeMino()
    {
        enableAct = false;
    }


    void UnFreezeMino()
    {
        enableAct = true;
    }
















}

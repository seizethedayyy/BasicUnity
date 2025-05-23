using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    [SerializeField] Vector2 timeRangeBetweenAttacks = new Vector2(1, 4);

    public static EnemyManager i {  get; private set; }

    private void Awake()
    {
        i = this; 
    }



    List<EnemyController> enemiesInRange = new List<EnemyController>();
    float notAttackingTimer = 2;

    public void AddEnemyInRange(EnemyController enemy)
    {
        if (!enemiesInRange.Contains(enemy))
            enemiesInRange.Add(enemy);
    }


    public void RemoveEnemyInRange(EnemyController enemy)
    {
        enemiesInRange.Remove(enemy);
    }

    private void Update()
    {
        if (enemiesInRange.Count == 0) return;



        if (!enemiesInRange.Any(e => e.IsInState(EnemyStates.Attack)))
        {
            if (notAttackingTimer > 0)
            {
                notAttackingTimer -= Time.deltaTime;
            }

            if (notAttackingTimer <= 0)
            {
                //����
                var attackingEnemy =  SelectenemyForAttack();
                attackingEnemy.ChangeState(EnemyStates.Attack);
                notAttackingTimer = Random.Range(timeRangeBetweenAttacks.x, timeRangeBetweenAttacks.y);
            }
        }
    }

    EnemyController SelectenemyForAttack()
    {
        return enemiesInRange.OrderByDescending(e => e.combatMovementTimer).FirstOrDefault();
    }




}

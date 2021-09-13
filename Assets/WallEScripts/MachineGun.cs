using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : MonoBehaviour
{
    AgroDetection aggroDetect;
    private EnemyM healthTarget;
    [SerializeField]
    private float attackTimer;
    [SerializeField]
    private float attackRefreshRate = 1f;

    public Transform firePoint;

    private void Awake()
    {
        aggroDetect = GetComponent<AgroDetection>();
        aggroDetect.OnAggro += AggroDetect_OnAggro;
    }

    private void AggroDetect_OnAggro(Transform target)
    {
        EnemyM health = target.GetComponent<EnemyM>();
        if (health != null)
        {
            healthTarget = health;
        }
    }
    private bool CanAttack()
    {
        return attackTimer >= attackRefreshRate;
    }
    private void Update()
    {
        if (healthTarget != null)
        {
            attackTimer += Time.deltaTime;
            if (CanAttack())
            {
                Attack();
               

                
            }
        }
    }

    private void Attack()
    {
        attackTimer = 0f;
       

    }
}

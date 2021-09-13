using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{
    public float enemySpeed;
    private Vector3 dir = Vector3.left;

    public GameObject player;
    public float Distance;

    public bool Istaret;
    public NavMeshAgent navMesh;

    public GameObject enemyFirePOint;
    public float range = 100f;
    public float damage = 1f;
    public GameObject impackteffect;
    public float timer = 0f;
    public float firerate = 1f;
    private float bSpeed = 1f;

    void Start()
    {

    }

    void Update()
    {
        Distance = Vector3.Distance(player.transform.position, this.transform.position);

        if (Distance <= 5)
        {
            Istaret = false;
        }
        if (Distance <= 15)
        {
            Istaret = true;
        }
        if (Istaret)
        {
            navMesh.isStopped = false;
            navMesh.SetDestination(player.transform.position);
        }
        if (!Istaret)
        {
            navMesh.isStopped = true;
        }

        if (!Istaret)
        {
            transform.Translate(dir * enemySpeed * Time.deltaTime);

            if (transform.position.x <= -7)
            {
                dir = Vector3.right;
            }
            else if (transform.position.x >= 7)
            {
                dir = Vector3.left;
            }
        }

        Shoot();



    }


    public void Shoot()
    {

        if (Distance <= 5)
        {

       
            RaycastHit hit;
        Debug.DrawRay(enemyFirePOint.transform.position, enemyFirePOint.transform.forward * 100, Color.red);
            if (Physics.Raycast(enemyFirePOint.transform.position, enemyFirePOint.transform.forward * bSpeed * Time.deltaTime, out hit, range))

            {         
                timer += Time.deltaTime;

                if (timer > firerate)
                {
                    GameObject ImpactGo = Instantiate(impackteffect, hit.point, Quaternion.LookRotation(hit.normal));

                    Destroy(ImpactGo, 2f);
                }

                var playerHealth = hit.collider.gameObject.GetComponent<PlayerHealth>();
                if (playerHealth != null)
                {
                    playerHealth.Damage(1);
                }
            }
        }
    }
}
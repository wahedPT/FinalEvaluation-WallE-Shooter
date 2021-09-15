using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieAttack : MonoBehaviour
{
    public float enemySpeed;
    private AgroDetection agro;
    Animator anim;
    NavMeshAgent navMeshAgent;
    private Transform target;
    public float Distance;
    public GameObject player;
    private void Awake()
    {

        navMeshAgent = GetComponent<NavMeshAgent>();
        agro = GetComponent<AgroDetection>();
        agro.OnAggro += AgroDetection_OnAggro;
        anim = GetComponentInChildren<Animator>();
    }


    private void AgroDetection_OnAggro(Transform target)
    {
        this.target = target;
        //navMeshAgent.SetDestination(target.position);

    }

    private void Update()
    {
        if (target != null)
        {
            navMeshAgent.SetDestination(target.position);
            float currenspeed = navMeshAgent.velocity.magnitude;
            anim.SetFloat("Speed", navMeshAgent.velocity.magnitude);

          
        }

        Distance = Vector3.Distance(player.transform.position, this.transform.position);
        
       
    }


    private void OnTriggerEnter(Collider other)
    {
        if (Distance <= 5)
        {
            var playerHealth = other. GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.Damage(5);
              
               
            }
        }
        if (other.gameObject.tag == "Player")
        {
            if (Distance < 3)
            {
                anim.SetFloat("Speed", -1);
                Debug.Log("Attack");
            }
        }
    }




    //public float enemySpeed;
    //private Vector3 dir = Vector3.left;

    //public GameObject player;
    //public float Distance;

    //public bool Istaret;
    //public NavMeshAgent navMesh;

    //Animator anim;

    //private void Awake()
    //{
    //    anim = GetComponentInChildren<Animator>();
    //}
    //void Update()
    //{
    //    Distance = Vector3.Distance(player.transform.position, this.transform.position);

    //    if (Distance <= 15)
    //    {
    //        Istaret = false;
    //    }
    //    if (Distance <= 15)
    //    {
    //        Istaret = true;
    //    }
    //    if (Istaret)
    //    {
    //        navMesh.isStopped = false;
    //        navMesh.SetDestination(player.transform.position);
    //    }
    //    if (!Istaret)
    //    {
    //        navMesh.isStopped = true;
    //    }


    //}

    //private void OnTriggerEnter(Collider other)
    //{
    //    var playerHealth =other. GetComponent<PlayerHealth>();
    //    if (playerHealth != null)
    //    {
    //        playerHealth.Damage(5);
    //    }


    //    Debug.Log(playerHealth);
    //}
    //NavMeshAgent nav;
    //bool follow;
    //Vector3 pos;
    //// Start is called before the first frame update
    //void Start()
    //{
    //    nav = GetComponent<NavMeshAgent>();
    //}
    //private void OnTriggerEnter(Collider other)
    //{
    //    follow = true;
    //    pos = other.transform.position;
    //    var health =other. GetComponent<PlayerHealth>();
    //    if (health != null)
    //    {
    //        health.Damage(1);
    //    }
    //}
    //// Update is called once per frame
    //void Update()
    //{
    //    if (follow)
    //    {
    //        nav.SetDestination(pos);

    //    }
    //}
}

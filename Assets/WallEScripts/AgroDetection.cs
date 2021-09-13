using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class AgroDetection : MonoBehaviour
{
   
    public event Action<Transform> OnAggro = delegate { };
    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<PlayerCharCintroller>();
        if (player != null)
        {
            OnAggro(player.transform);
            Debug.Log("Aggro detector");
            //GetComponent<NavMeshAgent>().SetDestination(player.transform.position);
           
        }


    }
   
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpGuns : MonoBehaviour
{
    public WallEShoot gunScript;
    public Rigidbody rb;
    public BoxCollider col;

    public Transform player, gunContainer, fpscam;


    public float pickUpRange;
    public float dropForwardForce, dropUpwardForce;


    public bool equipped;
    public static bool slotFull;


    private void Start()
    {
        if (!equipped)
        {
            gunScript.enabled = false;
          //  rb.isKinematic = false;
            col.isTrigger = false;

        }
        if (equipped)
        {
            gunScript.enabled = true;
          //  rb.isKinematic = true;
            col.isTrigger = true;
            slotFull = true;

        }
    }

    private void Update()
    {
        Vector3 distoplayer = player.position - transform.position;
        if (!equipped && distoplayer.magnitude <= pickUpRange && Input.GetKeyDown(KeyCode.E) && !slotFull) pickUp();
        if (equipped && Input.GetKeyDown(KeyCode.Q)) Drop();
    }

    private void pickUp()
    {
        equipped = true;
        slotFull = true;



        transform.SetParent(gunContainer);
        transform.localPosition = (Vector3.zero);
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.localScale = Vector3.one;


     //   rb.isKinematic = true;
        col.isTrigger = true;

        gunScript.enabled = true;
    }
    private void Drop()
    {
        equipped = false;
        slotFull = false;

        transform.SetParent(null);

        rb.isKinematic = false;
        col.isTrigger = false;

        gunScript.enabled = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallEShoot : MonoBehaviour
{

    public int damage = 10;
    public float range = 100f;
    public float impactForce = 30f;
    public float firerate = 20f;
    public Transform firePoint;


    public int maxAmmo = 30;
    public int currentAmmo;
    public float reloadTime = 0.2f;
    private bool isReloading = false;
    //public Animator animator;

    public AudioSource audi;


    public Transform fpsCam;
    public GameObject impackteffect;

    private float nexttimeToFire = 5f;
   
    void Start()
    {

        audi = GetComponent<AudioSource>();
        if (currentAmmo == -1)
            currentAmmo = maxAmmo;
        
    }

    // Update is called once per frame
    void Update()
    {
       
       
        if (isReloading)
            return;



        if (currentAmmo <= 0)
        {
            if (Input.GetKeyDown(KeyCode.R))
     
                StartCoroutine(Reload());
                return;
            
          
        }


        if (Input.GetMouseButton(0) && Time.time >= nexttimeToFire)
        {
           nexttimeToFire = Time.time + 0.25f / firerate;
            audi.Play();
            Shoot();
        }

    }

    public void Shoot()
    {
        GameObject bt = Pool.instance.Get("Flsah");

        currentAmmo--;

        if (bt != null)
        {
            bt.transform.position = firePoint.position;
            bt.transform.position = firePoint.position;
            bt.SetActive(true);

          
        }
       


        //enemy damage
        RaycastHit hit;

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {

            EnemyM enemy = hit.transform.GetComponent<EnemyM>();
            WinGame win= hit.transform.GetComponent<WinGame>();
            if (enemy != null)
            {
                enemy.takeDamage(damage);
                ScoreManager.instance.AddScore();
            }
            if (win != null)
            {
                win.Damage(10);


            }

            //if (hit.rigidbody != null)
            //{
            //    hit.rigidbody.AddForce(-hit.normal * impactForce);
            //}
            GameObject ImpactGo = Instantiate(impackteffect, hit.point, Quaternion.LookRotation(hit.normal));
         
            Destroy(ImpactGo, 1f);


        }



        if (currentAmmo <= 0)
        {
           Reload();
            return;
           
        }


    }
    IEnumerator Reload()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
        
            isReloading = true;
        }

        Debug.Log("Reloading");
        yield return new WaitForSeconds(reloadTime);
 
        currentAmmo = maxAmmo;
        isReloading = false;


    }

   
}

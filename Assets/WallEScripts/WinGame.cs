using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinGame : MonoBehaviour
{
    public float health;
    public float currentHealth;
   

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = health;

    }

    // Update is called once per frame
    public void Damage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            this.gameObject.SetActive(false);
            SceneManager.LoadScene(4);

        }
    }
}

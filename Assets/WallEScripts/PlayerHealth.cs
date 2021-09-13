using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int currentHealth;
    public GameObject player;

    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = health;
        healthBar.SetMaxHealth(health);
    }

    // Update is called once per frame
    public void Damage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            player.gameObject.SetActive(false);
            SceneManager.LoadScene(5);

        }
    }
}

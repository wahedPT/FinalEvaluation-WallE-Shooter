using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyM : MonoBehaviour
{
    public int health = 100;
    public void takeDamage(int amount)
    {
               amount = 1;
        health -= amount;
        if (health <= 0f)
        {
            Die();

        }
    } 
    void Die()
    {
        Destroy(gameObject);
    }
}

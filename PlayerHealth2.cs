using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth2 : MonoBehaviour
{
    public int maxHealth = 100;
    public int health2;
    public Slider slider;

    private Vector2 initialPosition;

    void Start()
    {
        health2 = maxHealth;
        initialPosition = transform.position;
    }

    void Update()
    {
        slider.value = health2;
    }

    public void TakeDamage(int damage)
    {
        health2 -= damage;
        Debug.Log(gameObject.name + " took " + damage + " damage. Current health: " + health2);

        if (health2 <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log(gameObject.name + " died.");
        // Handle death (e.g., disable the game object, respawn, etc.)
 
        health2 = maxHealth;
        transform.position = initialPosition;
        Debug.Log(gameObject.name + " respawned with full health.");
    }   
}
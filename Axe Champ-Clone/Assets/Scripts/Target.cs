using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private const int MAX_HEALTH = 100;
    private int currentHealth;

  

    private void Awake()
    {
        currentHealth = MAX_HEALTH;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "knife")
        {
            TakeDamage();
        }

    }
    private void TakeDamage()
    {
        currentHealth -= 30;
        if (currentHealth < 0)
        {
            GameManager.gameManagerInstance.CheckIfTheSceneIsCompleted();
            Destroy(transform.parent.gameObject);
        }
    }
   
}

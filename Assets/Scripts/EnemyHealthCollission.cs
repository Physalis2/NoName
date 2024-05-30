using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthCollission : MonoBehaviour
{
    public float health = 100f;

    public void Update()
    {
        alive();
    }

    public void alive()
    {
        if (health <= 0)
        { 
            Destroy(gameObject);
        }
    }

    public void takeDmg(float dmg)
    {
        health -= dmg;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Debug.Log("bullet");
        }
        else
        {
            Debug.Log("Player");
        }

    }
}

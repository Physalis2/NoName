using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    float dmg = 50f;
    int bulletDurability = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<EnemyHealthCollission>().takeDmg(dmg);
        collision.gameObject.GetComponent<EnemyHealthCollission>().alive();
        bulletDurability--;
        if (bulletDurability <= 0)
        {
            GameObject.Destroy(gameObject);
        }
    }
}

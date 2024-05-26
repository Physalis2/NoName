using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    float dmg = 50f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collisiojn");
        collision.gameObject.GetComponent<EnemyHealthCollission>().takeDmg(dmg);
        collision.gameObject.GetComponent<EnemyHealthCollission>().alive();
    }
}

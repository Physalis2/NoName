using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    float dmg = 50f;
    int bulletDurability = 1;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collisiojn");
        other.gameObject.GetComponent<EnemyHealthCollission>().takeDmg(dmg);
        other.gameObject.GetComponent<EnemyHealthCollission>().alive();
        if(bulletDurability <= 0)
        {
            GameObject.Destroy(gameObject);
        }
    }
}

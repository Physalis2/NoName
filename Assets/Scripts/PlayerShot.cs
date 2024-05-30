using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    public GameObject[] bulletTypes;
    public GameObject selectedBullet;

    private void Start()
    {
        bulletTypes = GameObject.Find("Manager").GetComponent<BulletTypes>().bulletTypes;
        selectedBullet = bulletTypes[0];
    }

    void Update()
    {
        if (!TimerCS.istPausiert)
        {
            if (Input.GetMouseButtonDown(0))
            {
                spawnPrefab(selectedBullet);
            }
        }
    }

    private void spawnPrefab(GameObject prefab)
    {
        Vector3 spawnPosition = transform.position;
        GameObject Bullet = Instantiate(prefab, spawnPosition, Quaternion.identity);
        BulletMovement bulletCs = Bullet.GetComponent<BulletMovement>();

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        Vector3 direction = mousePosition - transform.position;

        bulletCs.direction = direction;

    }
}

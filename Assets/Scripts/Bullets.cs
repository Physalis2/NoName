using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    [SerializeField] public GameObject[] projectiles;

    public static Bullets BulletScript;
    public float bulletDmg;

    private void Awake()
    {
        BulletScript = this;
    }

}

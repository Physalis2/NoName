using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    [SerializeField] public GameObject[] projectiles;

    public static Bullets BulletScript;

    private void Awake()
    {
        BulletScript = this;
    }

}

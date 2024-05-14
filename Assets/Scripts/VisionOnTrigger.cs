using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class VisionOnTriger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hi2");
        if (other.CompareTag("enemy"))
        {
            Debug.Log("Hi3");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] GameObject PLayer;
    [SerializeField] GameObject battelFieldMarker;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        folliwPlayer();
    }

    private void folliwPlayer()
    {
        Vector3 newPos;
        if (PLayer.transform.position.y > 0) 
        {
            newPos = battelFieldMarker.transform.position;
            newPos.z = transform.position.z;
            transform.position = newPos;
        }
        else
        {
            newPos = PLayer.transform.position;
            newPos.z = transform.position.z;
            transform.position = newPos;

        }

    }
}

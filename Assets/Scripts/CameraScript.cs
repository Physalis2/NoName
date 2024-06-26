using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject battelFieldMarker;
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        folliwPlayer();
    }

    private void folliwPlayer()
    {
        Vector3 newPos;
        if (Input.GetKey(KeyCode.F)) 
        {
            newPos = battelFieldMarker.transform.position;
            newPos.z = transform.position.z;
            transform.position = newPos;
        }
        else
        {
            newPos = player.transform.position;
            newPos.z = transform.position.z;
            transform.position = newPos;

        }

    }
}

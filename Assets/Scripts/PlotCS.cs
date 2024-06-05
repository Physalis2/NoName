using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotCS : MonoBehaviour
{

    [Header("Plot properties")]
    public int size = 1;
    public Vector3Int middelTile;

    [Header("")]
    [SerializeField] GameObject SaatLochParent;
    [SerializeField] GameObject[] Saatl�cher;

    void Start()
    {
        Saatl�cher = saatL�cher();
    }

    void Update()
    {
        
    }

    private GameObject[] saatL�cher()
    {
        int childCount = SaatLochParent.transform.childCount;

        GameObject[] holes = new GameObject[childCount];

        for (int i = 0; i < childCount; i++)
        {
            holes[i] = gameObject.transform.GetChild(i).gameObject;
        }
        return holes;
    }
}

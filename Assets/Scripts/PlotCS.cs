using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotCS : MonoBehaviour
{

    [Header("Plot properties")]
    public int size = 1;
    public Vector2 middelTile;

    [Header("")]
    [SerializeField] GameObject SaatLochParent;
    [SerializeField] GameObject[] Saatl�cher;

    [Header("")]
    [SerializeField] GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
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

    public Vector2 nearestPlotPosition()
    {
        float nearestDistance = 1000000;
        int nearestPlot = 0;
        for (int i = 0; i < Saatl�cher.Length; i++)
        {
            if (nearestDistance > Vector2.Distance(player.transform.position, Saatl�cher[i].transform.position));
            {
                nearestDistance = Vector2.Distance(player.transform.position, Saatl�cher[i].transform.position);
                nearestPlot = i;
            }
        }
        return Saatl�cher[nearestPlot].transform.position;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileCurserCS : MonoBehaviour
{
    [SerializeField] Grid grid;
    [SerializeField] GameObject player;
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] char playerDirection;

    [Header("")]
    [SerializeField] GameObject curser;
    [SerializeField] Vector2 positionMiddel;
    void Start()
    {
        curser = GameObject.Find("TileCurserInvis");
        curser.SetActive(false);
        grid = GameObject.Find("Grid").GetComponent<Grid>();
        player = GameObject.Find("Player");
        playerMovement = player.GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        playerDirection = playerMovement.direction;
    }

    void FixedUpdate()
    {
        position();
    }

    private void position()
    {
        Vector3 playerPos = player.transform.position;
        Vector3Int gridPos = grid.WorldToCell(playerPos);
        
        if (playerDirection == 'W')
        {
            gridPos += new Vector3Int(0, 1, 0);
        }
        if (playerDirection == 'S')
        {
            gridPos += new Vector3Int(0, -1, 0);
        }
        if (playerDirection == 'A')
        {
            gridPos += new Vector3Int(-1, 0, 0);
        }
        if (playerDirection == 'D')
        {
            gridPos += new Vector3Int(1, 0, 0);
        }

        transform.position = grid.CellToWorld(gridPos);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Soil")
        {
            Debug.Log("hi");
            positionMiddel = collision.gameObject.GetComponent<PlotCS>().middelTile;
            curser.SetActive(true);
            curser.transform.position = collision.gameObject.GetComponent<PlotCS>().nearestPlotPosition();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Soil")
        {
            curser.SetActive(false);
        }
    }
}

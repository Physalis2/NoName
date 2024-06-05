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
    [SerializeField] GameObject curser1;
    void Start()
    {
        curser1 = GameObject.Find("TileCurser");
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
}

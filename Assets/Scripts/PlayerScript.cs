using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerScript : MonoBehaviour
{
    public Tilemap Tilemap;
    public TileBase PlayerTile;

    private List<Vector3Int> _tail;

    // Start is called before the first frame update
    void Start()
    {
        Vector3Int cell = Tilemap.WorldToCell(this.transform.position);
        _tail = new List<Vector3Int>();
        _tail.Add(new Vector3Int(cell.x + 1, cell.y, cell.z));
        Tilemap.SetTile(cell, PlayerTile);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3Int cellPrev = Tilemap.WorldToCell(this.transform.position);
        //Tilemap.SetTile(cellPrev, null);

        Vector3 nextPos = this.transform.position;
        bool willMove = false;
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            nextPos = new Vector3(this.transform.position.x - 1, this.transform.position.y);
            willMove = true;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            nextPos = new Vector3(this.transform.position.x + 1, this.transform.position.y);
            willMove = true;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            nextPos = new Vector3(this.transform.position.x, this.transform.position.y - 1);
            willMove = true;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            nextPos = new Vector3(this.transform.position.x, this.transform.position.y + 1);
            willMove = true;
        }

        if (willMove == true)
        {

            Vector3Int nextCell = Tilemap.WorldToCell(nextPos);

            // Adding to tail

            // Clipping

            // Only move
            Tilemap.SetTile(_tail[_tail.Count - 1], null);
            _tail.RemoveAt(_tail.Count - 1);
            _tail.Add(cellPrev);
            this.transform.position = nextPos;

            // Paint head cell and tail
            Vector3Int cell = Tilemap.WorldToCell(this.transform.position);
            Tilemap.SetTile(cell, PlayerTile);

            //foreach (Vector3Int tailCell in _tail)
            //{
            //    Tilemap.SetTile(tailCell, PlayerTile);
            //}
        }
        
    }
}

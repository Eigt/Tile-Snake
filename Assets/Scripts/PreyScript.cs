using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PreyScript : MonoBehaviour
{
    public Tilemap Tilemap;
    public TileBase Tilebase;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3Int cellPrev = Tilemap.WorldToCell(this.transform.position);
        Tilemap.SetTile(cellPrev, null);

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            this.transform.position = new Vector3(this.transform.position.x + 1, this.transform.position.y);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            this.transform.position = new Vector3(this.transform.position.x - 1, this.transform.position.y);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 1);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 1);
        }

        Vector3Int cell = Tilemap.WorldToCell(this.transform.position);
        Tilemap.SetTile(cell, Tilebase);
    }
}

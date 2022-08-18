using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class PathCreate : MonoBehaviour
{
    Tilemap tilemap;
    public Sprite path_sprite;
    // Start is called before the first frame update
    void Start()
    {
        tilemap = GetComponent<Tilemap>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector3Int tilemapPos = tilemap.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            Tile tile = tilemap.GetTile<Tile>(tilemapPos);      
            if(tile == null) return;       
            print(tile);
            ChangeTileTexture(tilemapPos);
        }
    }

    public void ChangeTileTexture(Vector3Int coord)
    {
        Tile tile = ScriptableObject.CreateInstance<Tile>();
        tile.sprite = path_sprite;
        tilemap.SetTile(coord, tile);
        tilemap.RefreshAllTiles();
    }
}

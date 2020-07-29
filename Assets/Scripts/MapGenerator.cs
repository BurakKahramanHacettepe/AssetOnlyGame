using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public Texture2D tilemap;
    public Color2Tile[] mapping;
    public GameObject Entities;
    // Start is called before the first frame update

    [ContextMenu("Generate New Map")]
    void GenerateFromTileMap()
    {
        Entities = Instantiate(Entities, Vector3.zero, Quaternion.identity);

        Vector2 pos = new Vector2(0, 0);
        for (int x = 0; x < 100; x++)
        {
            for (int y = 0; y < 100; y++)
            {
                for (int i = 0; i < mapping.Length; i++)
                {
                    if (mapping[i].color.Equals(tilemap.GetPixel(x, y)))
                    {
                        pos.x = x - 49;
                        pos.y = y - 49;
                        if (mapping[i].tile.CompareTag("Enemy") || mapping[i].tile.CompareTag("Player"))
                        {
                            Instantiate(mapping[i].tile, pos, Quaternion.identity, Entities.transform);
                            Instantiate(mapping[0].tile, pos, Quaternion.identity, transform);
                        }
                        else if (mapping[i].tile.CompareTag("Torch") || mapping[i].tile.CompareTag("Chest"))
                        {
                            Instantiate(mapping[i].tile, pos, Quaternion.identity, transform);
                            Instantiate(mapping[0].tile, pos, Quaternion.identity, transform);

                        }
                        else
                        {
                            Instantiate(mapping[i].tile, pos, Quaternion.identity, transform);

                        }
                    }
                }
                
                
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Noise : MonoBehaviour
{
    [Range(0,1)]
    public float x_offset = 0 , y_offset = 0;

    [Range(0, 1)]
    public float lim = 0;
        


    public float scale = 10f;

    [ContextMenu("Generate Noise Map")]
    public void GeneratePrimativeMap()
    {
        // Create a new 2x2 texture ARGB32 (32 bit with alpha) and no mipmaps
        var texture = new Texture2D(100, 100, TextureFormat.RGBA32, false);


        Vector2 pos = new Vector2(0, 0);
        for (int x = 0; x < 100; x ++)
        {
            for (int y = 0; y < 100; y ++)
            {
                if (Mathf.PerlinNoise(((x / 100f) + x_offset) * scale, ((y / 100f) + y_offset) * scale) < lim)
                {
                    texture.SetPixel(x, y, Color.white);
                }
                else
                {
                    texture.SetPixel(x, y, Color.black);
                }
            }
        }
        texture.Apply();
        
        SaveTextureAsPNG(texture, "Assets/Sprites/map.png");
    }
    
    public static void SaveTextureAsPNG(Texture2D _texture, string _fullPath)
    {
        byte[] _bytes = _texture.EncodeToPNG();
        System.IO.File.WriteAllBytes(_fullPath, _bytes);
        Debug.Log(_bytes.Length / 1024 + "Kb was saved as: " + _fullPath);
    }


}

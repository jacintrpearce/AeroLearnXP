using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGenCp1 : MonoBehaviour
{
    public CSVReadCp csvRead;
    public float scaleX = 0.01f;
    public float scaleY = 0.01f;
    public float scaleZ = 0.01f;
    void Start()
    {
        CSVReadCp.PointsCp[] data_setCp = csvRead.ReadCSV();
        int index = data_setCp.Length;
        
        //Colour array
        var colors = new[] { Color.blue, Color.Lerp(Color.blue, Color.cyan, 0.25f), Color.cyan, Color.Lerp(Color.cyan, Color.green, 0.25f), Color.green, Color.Lerp(Color.green, Color.yellow, 0.25f), Color.yellow, Color.Lerp(Color.yellow, new Color(1.0f, 0.5f, 0f), 0.25f), new Color(1.0f, 0.5f, 0f), Color.Lerp(new Color(1.0f, 0.5f, 0f), Color.red, 0.25f), Color.red };
        
        for (int i = 0; i < index; i++)
        {
            if (data_setCp[i].x != 0 && data_setCp[i].y != 0)
            {
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.transform.parent = transform;
                Vector3 parentPos = transform.position;
                cube.transform.position = new Vector3(parentPos.x + data_setCp[i].x, parentPos.y + data_setCp[i].y, -parentPos.z);
                cube.transform.localScale = new Vector3(scaleX, scaleY, scaleZ);
                Renderer renderer = cube.GetComponent<Renderer>();
            
                int scaleIndex = Mathf.RoundToInt(Mathf.Clamp(data_setCp[i].v, 0.0000661f, 0.000579f) / 0.000579f * (colors.Length - 1));
                Color color = colors[scaleIndex];
            
                Material material = new Material(Shader.Find("Standard"));
                material.color = color;
                renderer.material = material;

            }
           
        }
    }
}

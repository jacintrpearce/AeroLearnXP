using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGenCf : MonoBehaviour
{
    public CSVRead csvRead;
    public float ScaleX = 0.01f;
    public float ScaleY = 0.01f;
    public float ScaleZ = 0.01f;
    void Start()
    {
        CSVRead.Points[] data_set = csvRead.ReadCSV();
        int index = data_set.Length;
        
        //Colour array
        var colors = new[] { Color.blue, Color.Lerp(Color.blue, Color.cyan, 0.25f), Color.cyan, Color.Lerp(Color.cyan, Color.green, 0.25f), Color.green, Color.Lerp(Color.green, Color.yellow, 0.25f), Color.yellow, Color.Lerp(Color.yellow, new Color(1.0f, 0.5f, 0f), 0.25f), new Color(1.0f, 0.5f, 0f), Color.Lerp(new Color(1.0f, 0.5f, 0f), Color.red, 0.25f), Color.red };
        
        for (int i = 0; i < index; i++)
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.parent = transform;
            cube.transform.position = new Vector3(data_set[i].x, data_set[i].y,0);
            cube.transform.localScale = new Vector3(ScaleX, ScaleY, ScaleY);
            Renderer renderer = cube.GetComponent<Renderer>();
            
            int scaleIndex = Mathf.RoundToInt(Mathf.Clamp(data_set[i].v, 0.0000661f, 0.000579f) / 0.000579f * (colors.Length - 1));
            Color color = colors[scaleIndex];
            
            Material material = new Material(Shader.Find("Standard"));
            material.color = color;
            renderer.material = material;
            
        }
    }
}


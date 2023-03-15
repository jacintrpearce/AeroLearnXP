using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGen : MonoBehaviour
{
    public CSVRead csvRead;

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
            cube.transform.localScale = new Vector3((float)0.001, (float)0.001, (float)0.001);
            Renderer renderer = cube.GetComponent<Renderer>();
            
            int scaleIndex = Mathf.RoundToInt(Mathf.Clamp(data_set[i].v, 0, 300) / 300f * (colors.Length - 1));
            Color color = colors[scaleIndex];
            
            Material material = new Material(Shader.Find("Standard"));
            material.color = color;
            renderer.material = material;
            
        }
    }
}


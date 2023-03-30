using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CubeGenCp1 : MonoBehaviour
{
    public CSVReadCp csvRead;
    public float scaleX = 0.007f;
    public float scaleY = 0.007f;
    public float scaleZ = 0.01f;

    void Start()
    {
        CSVReadCp.PointsCp[] data_setCp = csvRead.ReadCSV();
        float maxV = float.MinValue;
        float minV = float.MaxValue;
        
        //Colour array
        var colors = new[]
        {
            Color.blue, Color.Lerp(Color.blue, Color.cyan, 0.25f), Color.cyan,
            Color.Lerp(Color.cyan, Color.green, 0.25f), Color.green, Color.Lerp(Color.green, Color.yellow, 0.25f),
            Color.yellow, Color.Lerp(Color.yellow, new Color(1.0f, 0.5f, 0f), 0.25f), new Color(1.0f, 0.5f, 0f),
            Color.Lerp(new Color(1.0f, 0.5f, 0f), Color.red, 0.25f), Color.red
        };

        for (int i = 0; i < data_setCp.Length; i++)
        {
            float v = data_setCp[i].v;

            if (v > maxV)
            {
                maxV = v;
            }

            if (v < minV)
            {
                minV = v;
            }
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.parent = transform;
            Vector3 parentPos = transform.position;
            cube.transform.position = new Vector3(parentPos.x + data_setCp[i].x, parentPos.y + data_setCp[i].y, -parentPos.z);
            cube.transform.localScale = new Vector3(scaleX, scaleY, scaleZ);
            Renderer renderer = cube.GetComponent<Renderer>();

            int scaleIndex;

            if (data_setCp[i].v == minV) 
            {
                scaleIndex = 0;
            } else if (data_setCp[i].v == maxV)
            {
                scaleIndex = colors.Length - 1;
            } else 
            {
                float range = maxV - minV;
                float normalizedValue = (data_setCp[i].v - minV) / range;
                scaleIndex = Mathf.FloorToInt(normalizedValue * colors.Length);
            }
            Color color = colors[Mathf.Clamp(scaleIndex, 0, colors.Length - 1)];

            Material material = new Material(Shader.Find("Standard"));
            material.color = color;
            renderer.material = material;
        }
       // Update Legend Max and Min values
       GameObject maxObject = GameObject.Find("Max 1");
       TextMeshPro maxText = maxObject.GetComponent<TextMeshPro>();
       maxText.text = "Max: " + maxV.ToString("0.##E+00");
       
       GameObject minObject = GameObject.Find("Min 1");
       TextMeshPro minText = minObject.GetComponent<TextMeshPro>();
       minText.text = "Min: " + minV.ToString("0.##E+00");
    }
}
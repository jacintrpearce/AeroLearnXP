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
        
        var colors = new List<Color>();
        int numColors = 20;
        // Add first color (blue)
        colors.Add(Color.blue);

        // Add 18 intermediate colors between blue and red
        for (int i = 1; i < 19; i++)
        {
            Color color = Color.Lerp(Color.blue, Color.red, (float)i / (numColors - 1));
            colors.Add(color);
        }

        // Add last color (red)
        colors.Add(Color.red);
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

            int scaleIndex = Mathf.RoundToInt(Mathf.Clamp((data_setCp[i].v - minV) / (maxV - minV), 0f, 1f) * (numColors - 1));
            Color color = colors[Mathf.Clamp(scaleIndex, 0, numColors - 1)];

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
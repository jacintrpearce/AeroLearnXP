using System;
using TMPro;
using UnityEngine;

public class CubeGenCf4 : MonoBehaviour
{
    public CSVReadCF csvRead;
    public float scaleX = 0.007f;
    public float scaleY = 0.007f;
    public float scaleZ = 0.007f;

    void Start()
    {
        CSVReadCF.Points[] data_set = csvRead.ReadCSV();
        int index = data_set.Length;
        float maxV = float.MinValue;
        float minV = float.MaxValue;
        
        // Extract angle of attack of aerofoil based on the Z rotation angle in degrees
        float aoa = transform.parent.rotation.eulerAngles.z;
        float aoaRad = aoa * Mathf.Deg2Rad;
        float sinAoA = Mathf.Sin(aoaRad);
        float cosAoA = Mathf.Cos(aoaRad);

        //Colour array
        var colors = new[] { Color.blue, Color.Lerp(Color.blue, Color.cyan, 0.25f), Color.cyan, Color.Lerp(Color.cyan, Color.green, 0.25f), Color.green, Color.Lerp(Color.green, Color.yellow, 0.25f), Color.yellow, Color.Lerp(Color.yellow, new Color(1.0f, 0.5f, 0f), 0.25f), new Color(1.0f, 0.5f, 0f), Color.Lerp(new Color(1.0f, 0.5f, 0f), Color.red, 0.25f), Color.red };
        
        for (int i = 0; i < index; i++)
        {
            float v = data_set[i].v;

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
            
            float locX = parentPos.x + ((data_set[i].x * cosAoA) - (data_set[i].y * sinAoA));
            float locY = parentPos.y + ((data_set[i].x * sinAoA) + (data_set[i].y * cosAoA));
            cube.transform.position = new Vector3(locX, locY , -parentPos.z);
            cube.transform.localScale = new Vector3(scaleX, scaleY, scaleZ);
            Renderer renderer = cube.GetComponent<Renderer>();
    
            // Specify min and max CF values
            int scaleIndex = Mathf.RoundToInt(Mathf.Clamp(data_set[i].v, minV, maxV) / maxV * (colors.Length - 1));
            Color color = colors[scaleIndex];

            Material material = new Material(Shader.Find("Standard"));
            material.color = color;
            renderer.material = material;

        }
        // Update Legend Max and Min values
        GameObject maxObject = GameObject.Find("Max 4");
        TextMeshPro maxText = maxObject.GetComponent<TextMeshPro>();
        maxText.text = "Max: " + maxV.ToString("0.##E+00");
       
        GameObject minObject = GameObject.Find("Min 4");
        TextMeshPro minText = minObject.GetComponent<TextMeshPro>();
        minText.text = "Min: " + minV.ToString("0.##E+00");
    }
}
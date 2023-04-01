using System;
using TMPro;
using UnityEngine;

public class SLGen1 : MonoBehaviour
{
    public CSVReadVSL csvRead;
    public float scaleX = 0.007f;
    public float scaleY = 0.007f;
    public float scaleZ = 0.01f;

    void Start()
    {
        CSVReadVSL.PointsSL[] data_setSL = csvRead.ReadCSV();
        int index = data_setSL.Length;
        float maxV = float.MinValue;
        float minV = float.MaxValue;
        
        // Extract angle of attack of aerofoil based on the Z rotation angle in degrees
        float aoa = transform.parent.rotation.eulerAngles.z;
        float aoaRad = aoa * Mathf.Deg2Rad;
        float sinAoA = Mathf.Sin(aoaRad);
        float cosAoA = Mathf.Cos(aoaRad);

        //Colour array
        var colors = new[]
        {
            Color.blue, Color.Lerp(Color.blue, Color.cyan, 0.25f), Color.cyan,
            Color.Lerp(Color.cyan, Color.green, 0.25f), Color.green, Color.Lerp(Color.green, Color.yellow, 0.25f),
            Color.yellow, Color.Lerp(Color.yellow, new Color(1.0f, 0.5f, 0f), 0.25f), new Color(1.0f, 0.5f, 0f),
            Color.Lerp(new Color(1.0f, 0.5f, 0f), Color.red, 0.25f), Color.red
        };

        for (int j = 0; j < index; j++)
        {
            float v = data_setSL[j].v;

            if (v > maxV)
            {
                maxV = v;
            }

            if (v < minV)
            {
                minV = v;
            }
        }
        
        for (int i = 0; i < index; i++)
        {
            GameObject cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);

            cylinder.transform.parent = transform;
            Vector3 parentPos = transform.position;
            
            float locX = parentPos.x + ((data_setSL[i].x * cosAoA) - (data_setSL[i].y * sinAoA));
            float locY = parentPos.y + ((data_setSL[i].x * sinAoA) + (data_setSL[i].y * cosAoA));
            cylinder.transform.position = new Vector3(locX, locY , parentPos.z);
            cylinder.transform.localScale = new Vector3(scaleX, scaleY, scaleZ);
	    cylinder.transform.localRotation = Quaternion.Euler(0, 0, 90); // Rotate cylinder 90 degrees (flow direction)
            Renderer renderer = cylinder.GetComponent<Renderer>();
    
            int scaleIndex;

            if (data_setSL[i].v == minV) 
            {
                scaleIndex = 0;
            } else if (data_setSL[i].v == maxV)
            {
                scaleIndex = colors.Length - 1;
            } else 
            {
                float range = maxV - minV;
                float normalizedValue = (data_setSL[i].v - minV) / range;
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
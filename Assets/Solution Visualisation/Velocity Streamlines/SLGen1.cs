using System;
using System.Collections.Generic;
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

        // Create a new GameObject to hold the Line Renderer component
        GameObject lineObject = new GameObject("LineRendererObject");
        LineRenderer lineRenderer = lineObject.AddComponent<LineRenderer>();

        // Set the width of the line
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;

        // Set the number of points in the Line Renderer to the number of points in the data_setSL array
        lineRenderer.positionCount = data_setSL.Length;

        // Loop through each point in the data_setSL array and set its position in the Line Renderer
        for (int i = 0; i < data_setSL.Length; i++)
        {
            Vector3 position = new Vector3(data_setSL[i].x, data_setSL[i].y, 0);
            lineRenderer.SetPosition(i, position);
        }

        // Set other properties of the Line Renderer as desired
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.loop = false;


        // Update Legend Max and Min values
        GameObject maxObject = GameObject.Find("Max 1");
        TextMeshPro maxText = maxObject.GetComponent<TextMeshPro>();
        maxText.text = "Max: " + maxV.ToString("0.##E+00");

        GameObject minObject = GameObject.Find("Min 1");
        TextMeshPro minText = minObject.GetComponent<TextMeshPro>();
        minText.text = "Min: " + minV.ToString("0.##E+00");
        
    }
}
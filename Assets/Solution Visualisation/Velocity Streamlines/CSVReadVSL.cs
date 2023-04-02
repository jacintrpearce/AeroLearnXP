using System;
using System.Collections.Generic;
using UnityEngine;

public class CSVReadVSL                        : MonoBehaviour
{
    public TextAsset csvFile;

    [System.Serializable]

    public class PointsSL
    {
        public float x;
        public float y;
        public float v;
    }

    public PointsSL[] ReadCSV()
        {
            string[] elements = csvFile.text.Split(new string [] {",",",","\n"}, StringSplitOptions.None);

            // initialize an empty list to store the valid points
            List<PointsSL> data_setSL = new List<PointsSL>();
            var rowCounter = 0;
            // X limits
            float xLimFF1 = -0.2f;
            float xLimFF2 = 1.2f;
            // Y limits
            var yLimGeom1 = 0;
            float yLimFF = 1f;
            
            for (int j = 0; j < elements.Length / 4; j++)
            {
                float x = float.Parse(elements[4 * j]);
                float y = float.Parse(elements[4 * j + 1]);
                float v = float.Parse(elements[4 * j + 3]);

                rowCounter++;
                
                // Check the values to be saved starting from aerofoil in the x direction
                if ((x > xLimFF1 && x < xLimFF2))
                {
                    // Only save values corresponding to N number of rows (even (N = 2), every 3 (N = 3) etc)
                    if (rowCounter % 1 == 0 && Mathf.Abs(y) >= yLimGeom1 && Mathf.Abs(y) < yLimFF)
                    {
                        PointsSL point = new PointsSL();
                        point.x = x;
                        point.y = y;
                        point.v = v;
                        // add the point to the list
                        data_setSL.Add(point);
                    } 
                }
            }

            // convert the list to an array and return it
            return data_setSL.ToArray();

        }
    void Start()
    {
        ReadCSV();
    }
}

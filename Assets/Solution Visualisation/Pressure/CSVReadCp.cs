using System;
using System.Collections.Generic;
using UnityEngine;

public class CSVReadCp : MonoBehaviour
{
    public TextAsset csvFile;

    [System.Serializable]

    public class PointsCp
    {
        public float x;
        public float y;
        public float v;
    }

    public PointsCp[] ReadCSV()
        {
            string[] elements = csvFile.text.Split(new string [] {",",",","\n"}, StringSplitOptions.None);

            // initialize an empty list to store the valid points
            List<PointsCp> data_setCp = new List<PointsCp>();
            var rowCounter = 0;
            // X limits
            var xLimGeom1 = 0;
            var xLimGeom2 = 1;
            float xLimFF1 = -0.2f;
            float xLimFF2 = 1.2f;
            // Y limits
            var yLimGeom1 = 0;
            float yLimGeom2 = 0.01f;
            float yLimFF = 0.15f;
            
            for (int j = 0; j < elements.Length / 4; j++)
            {
                float x = float.Parse(elements[4 * j]);
                float y = float.Parse(elements[4 * j + 1]);
                float v = float.Parse(elements[4 * j + 3]);

                rowCounter++;
                
                // Check the values to be saved starting from aerofoil in the x direction
                if (x >= xLimGeom1 && x <= xLimGeom2)
                {
                    // Only save values corresponding to N number of rows (even (N = 2), every 3 (N = 3) etc)
                    if (rowCounter % 2 == 0 && Mathf.Abs(y) >= yLimGeom2 && Mathf.Abs(y) < yLimFF)
                    {
                        PointsCp point = new PointsCp();
                        point.x = x;
                        point.y = y;
                        point.v = v;
                        // add the point to the list
                        data_setCp.Add(point);
                    } 
                    // Data closer to aerofoil
                    else if (rowCounter % 2 == 0 && Mathf.Abs(y) > yLimGeom1 && Mathf.Abs(y) < yLimGeom2)
                    {
                        PointsCp point = new PointsCp();
                        point.x = x;
                        point.y = y;
                        point.v = v;
                        // add the point to the list
                        data_setCp.Add(point);
                    }
                }
                // Data upstream and downstream of aerofoil
                else if ((x < xLimGeom1 && x > xLimFF1 ) || (x > xLimGeom2 && x < xLimFF2))
                {
                    // Only save values corresponding to N number of rows (even (N = 2), every 3 (N = 3) etc)
                    if (rowCounter % 2 == 0 && Mathf.Abs(y) >= yLimGeom1 && Mathf.Abs(y) < yLimFF)
                    {
                        PointsCp point = new PointsCp();
                        point.x = x;
                        point.y = y;
                        point.v = v;
                        // add the point to the list
                        data_setCp.Add(point);
                    }
                }
            }

            // convert the list to an array and return it
            return data_setCp.ToArray();

        }
    void Start()
    {
        ReadCSV();
    }
}

// int scaleIndex;
//
// if (data_setTest[i].x = minV) {
//     index = 0;
// } else if (data_setTest[i].x = maxV) {
//     scaleIndex = colors.Length - 1;
// } else {
//     float range = maxV - minV;
//     float normalizedValue = (data_setTest[i].x - minV) / range;
//     scaleIndex = Mathf.FloorToInt(normalizedValue * colors.Length);
// }

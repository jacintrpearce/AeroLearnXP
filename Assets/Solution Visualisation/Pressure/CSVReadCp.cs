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

            for (int j = 0; j < elements.Length / 4; j++)
            {
                float x = float.Parse(elements[4 * j]);
                float y = float.Parse(elements[4 * j + 1]);
                float v = float.Parse(elements[4 * j + 3]);

                rowCounter++;
                
                // Check the values to be saved starting from aerofoil in the x direction
                if (x >= 0 && x <= 1f)
                {
                    // Only save values corresponding to N number of rows (even (N = 2), every 3 (N = 3) etc)
                    if (rowCounter % 2 == 0 && Mathf.Abs(y) > 0.05 && Mathf.Abs(y) < 0.15)
                    {
                        PointsCp point = new PointsCp();
                        point.x = x;
                        point.y = y;
                        point.v = v;
                        // add the point to the list
                        data_setCp.Add(point);
                    } 
                    // Data closer to aerofoil
                    else if (rowCounter % 2 == 0 && Mathf.Abs(y) > 0.05 && Mathf.Abs(y) < 0.15)
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
                else if ((x < 0 && x > -0.2f) || (x > 1 && x < 1.2f))
                {
                    // Only save values corresponding to N number of rows (even (N = 2), every 3 (N = 3) etc)
                    if (rowCounter % 2 == 0)
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


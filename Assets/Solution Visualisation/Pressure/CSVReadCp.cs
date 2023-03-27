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
            
            for (int j = 0; j < elements.Length / 4; j++)
            {
                float x = float.Parse(elements[4 * j]);
                float y = float.Parse(elements[4 * j + 1]);
                float v = float.Parse(elements[4 * j + 3]);

                if ((x < 0 && x > -0.2f && Mathf.Abs(y) < 0.08) || (x >= 0 && x < 1f && Mathf.Abs(y) < 0.08))
                {
                    PointsCp point = new PointsCp();
                    point.x = x;
                    point.y = y;
                    point.v = v;
                    
                    // add the point to the list
                    data_setCp .Add(point);
                }
            }
            
            // convert the list to an array and return it
            return data_setCp .ToArray();
        }
    void Start()
    {
        ReadCSV();
    }
}


using System;
<<<<<<< HEAD
using System.Collections.Generic;
=======
>>>>>>> origin/master
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
<<<<<<< HEAD
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
=======

    public PointsCp[] ReadCSV()
    {
        string[] elements = csvFile.text.Split(new string [] {",",",","\n"}, StringSplitOptions.None);
        int size = elements.Length/4;
        PointsCp[] data_setCp  = new PointsCp[size];

        for (int j = 0; j < size; j++)
        {
            data_setCp[j] = new PointsCp();
            float x = float.Parse(elements[4 * (j)]);
            float y = float.Parse(elements[4 * (j) + 1]);
            float v = float.Parse(elements[4 * (j) + 3]);
            
            if ((x < 0 && x > -0.3f && Mathf.Abs(y) < 1) || (x >= 0 && x < 1f) && Mathf.Abs(y) < 1)
            {
                data_setCp[j].x = x;
                data_setCp[j].y = y;
                data_setCp[j].v = v;
            }

        }

        return data_setCp;
    }
    
>>>>>>> origin/master
    void Start()
    {
        ReadCSV();
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> origin/master

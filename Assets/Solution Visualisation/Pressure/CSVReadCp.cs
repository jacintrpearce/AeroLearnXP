using System;
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
        int size = elements.Length/4;
        PointsCp[] data_setCp  = new PointsCp[size];

        int filteredPointsCount = 0; // initialize counter variable to 0

        for (int j = 0; j < size; j++)
        {
            float x = float.Parse(elements[4 * (j)]);
            float y = float.Parse(elements[4 * (j) + 1]);
            float v = float.Parse(elements[4 * (j) + 3]);
            
            if ((x < 0 && x > -0.3f && Mathf.Abs(y) < 1) || (x >= 0 && x < 1f) && Mathf.Abs(y) < 1)
            {
                data_setCp[filteredPointsCount] = new PointsCp(); // create new instance of PointsCp
                data_setCp[filteredPointsCount].x = x;
                data_setCp[filteredPointsCount].y = y;
                data_setCp[filteredPointsCount].v = v;

                filteredPointsCount++; // increment counter variable for each filtered point
            }
        }

        PointsCp[] filteredData_setCp = new PointsCp[filteredPointsCount]; // create new array with size of filteredPointsCount

        for (int i = 0; i < filteredPointsCount; i++)
        {
            filteredData_setCp[i] = new PointsCp(); // create new instance of PointsCp
            filteredData_setCp[i].x = data_setCp[i].x;
            filteredData_setCp[i].y = data_setCp[i].y;
            filteredData_setCp[i].v = data_setCp[i].v;
        }
        return data_setCp;
    }
    
    void Start()
    {
        ReadCSV();
    }
}

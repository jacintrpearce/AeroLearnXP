using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CSVReadCp : MonoBehaviour
{
    public TextAsset csvFile;
    public int rowSkip1 = 2;
    public int rowSkip2 = 2;
    public int rowSkip3 = 2;

    [System.Serializable]
    public class PointsCp
    {
        public float x;
        public float y;
        public float v;
    }

    public PointsCp[] ReadCSV()
    {
        List<PointsCp> data_setCp = new List<PointsCp>();
        var rowCounter = 0;
        var xLimGeom1 = 0;
        var xLimGeom2 = 1;
        float xLimFF1 = -0.2f;
        float xLimFF2 = 1.2f;
        var yLimGeom1 = 0;
        float yLimGeom2 = 0.01f;
        float yLimFF = 0.15f;

        using (StringReader reader = new StringReader(csvFile.text))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] elements = line.Split(',');
                float x = float.Parse(elements[0]);
                float y = float.Parse(elements[1]);
                float v = float.Parse(elements[3]);

                rowCounter++;

                if (x >= xLimGeom1 && x <= xLimGeom2)
                {
                    if (rowCounter % rowSkip1 == 0 && Mathf.Abs(y) >= yLimGeom2 && Mathf.Abs(y) < yLimFF)
                    {
                        PointsCp point = new PointsCp();
                        point.x = x;
                        point.y = y;
                        point.v = v;
                        data_setCp.Add(point);
                    }
                    else if (rowCounter % rowSkip2 == 0 && Mathf.Abs(y) > yLimGeom1 && Mathf.Abs(y) < yLimGeom2)
                    {
                        PointsCp point = new PointsCp();
                        point.x = x;
                        point.y = y;
                        point.v = v;
                        data_setCp.Add(point);
                    }
                }
                else if ((x < xLimGeom1 && x > xLimFF1) || (x > xLimGeom2 && x < xLimFF2))
                {
                    if (rowCounter % rowSkip3 == 0 && Mathf.Abs(y) >= yLimGeom1 && Mathf.Abs(y) < yLimFF)
                    {
                        PointsCp point = new PointsCp();
                        point.x = x;
                        point.y = y;
                        point.v = v;
                        data_setCp.Add(point);
                    }
                }
            }
        }

        return data_setCp.ToArray();
    }

    void Start()
    {
        ReadCSV();
    }
}

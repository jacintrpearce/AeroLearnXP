using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CSVReadVSL : MonoBehaviour
{
    public TextAsset csvFile;
    public int rowSkip = 10;
    
    [System.Serializable]
    public class PointsSL
    {
        public float x;
        public float y;
        public float vx;
        public float vy;
        public float v;
    }

    public PointsSL[] ReadCSV()
    {
        List<PointsSL> data_setSL = new List<PointsSL>();
        var rowCounter = 0;
        float xLimFF1 = -0.2f;
        float xLimFF2 = 1.2f;
        var yLimGeom1 = 0;
        float yLimFF = 0.5f;

        using (var reader = new StreamReader(new MemoryStream(csvFile.bytes)))
        {
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');

                if (values.Length < 4) continue;

                float x, y, vx, vy, v;
                
                if (float.TryParse(values[0], out x) &&
                    float.TryParse(values[1], out y) &&
                    float.TryParse(values[3], out vx) &&
                    float.TryParse(values[4], out vy) &&
                    float.TryParse(values[5], out v))
                {
                    rowCounter++;
                    if (x > xLimFF1 && x < xLimFF2 && rowCounter % rowSkip == 0 &&
                        Mathf.Abs(y) >= yLimGeom1 && Mathf.Abs(y) < yLimFF)
                    {
                        PointsSL point = new PointsSL();
                        point.x = x;
                        point.y = y;
                        point.vx = vx;
                        point.vy = vy;
                        point.v = v;
                        data_setSL.Add(point);
                    }
                }
            }
        }

        return data_setSL.ToArray();
    }

    void Start()
    {
        ReadCSV();
    }
}
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class CSVRead : MonoBehaviour
{
    public TextAsset csvFile;

    [System.Serializable]

    public class Points
    {
        public float x;
        public float y;
        public float v;
    }

    public Points[] ReadCSV()
    {
        string[] elements = csvFile.text.Split(new string [] {",",",","\n"}, StringSplitOptions.None);
        int size = elements.Length/4;
        Points[] data_set  = new Points[size];

        for (int j = 0; j < size; j++)
        {
            data_set[j] = new Points();
            data_set[j].x = float.Parse(elements[4 * (j)]);
            data_set[j].y = float.Parse(elements[4 * (j) + 1 ]);
            data_set[j].v = float.Parse(elements[4 * (j) + 3 ]);
        }

        return data_set;
    }
    
    void Start()
    {
        ReadCSV();
    }
}

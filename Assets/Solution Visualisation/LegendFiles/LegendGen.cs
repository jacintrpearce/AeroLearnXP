using UnityEngine;

public class LegendGen : MonoBehaviour
{
    
    public Color[] colors = new[]
    {
        Color.blue,
        Color.Lerp(Color.blue, Color.cyan, 0.25f),
        Color.cyan,
        Color.Lerp(Color.cyan, Color.green, 0.25f),
        Color.green,
        Color.Lerp(Color.green, Color.yellow, 0.25f),
        Color.yellow,
        Color.Lerp(Color.yellow, new Color(1.0f, 0.5f, 0f), 0.25f),
        new Color(1.0f, 0.5f, 0f),
        Color.Lerp(new Color(1.0f, 0.5f, 0f), Color.red, 0.25f),
        Color.red
    };

    public GameObject cubePrefab;

    void Start()
    {
        for (int i = 0; i < colors.Length; i++)
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.parent = transform;
            Vector3 parentPos = transform.position;
            float l = (i * 0.05f); // set the spacing of cubes
            cube.transform.position = new Vector3(parentPos.x, parentPos.y + l, parentPos.z); // position of the cube
            cube.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f); // set the scale of the cube
            cube.GetComponent<Renderer>().material.color = colors[i]; // set the color of the cube

        }
    }
}


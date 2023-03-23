using UnityEngine;

public class CubeGenCf2 : MonoBehaviour
{
    public CSVReadCF csvRead;
    public float scaleX = 0.007f;
    public float scaleY = 0.007f;
    public float scaleZ = 0.007f;

    void Start()
    {
        CSVReadCF.Points[] data_set = csvRead.ReadCSV();
        int index = data_set.Length;

        //Colour array
        var colors = new[] { Color.blue, Color.Lerp(Color.blue, Color.cyan, 0.25f), Color.cyan, Color.Lerp(Color.cyan, Color.green, 0.25f), Color.green, Color.Lerp(Color.green, Color.yellow, 0.25f), Color.yellow, Color.Lerp(Color.yellow, new Color(1.0f, 0.5f, 0f), 0.25f), new Color(1.0f, 0.5f, 0f), Color.Lerp(new Color(1.0f, 0.5f, 0f), Color.red, 0.25f), Color.red };
        
        for (int i = 0; i < index; i++)
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            
            //Set x and y coordinate with change in AoA = 4 degrees. Refer to ChatGPT
            // cos -4 = 0.99756405f
            // sin -4 = -0.069756474f
            cube.transform.parent = transform;
            Vector3 parentPos = transform.position;
            float locX = parentPos.x + ((data_set[i].x * 0.99756405f) - (data_set[i].y * -0.069756474f));
            float locY = parentPos.y + ((data_set[i].x * -0.069756474f) + (data_set[i].y * 0.99756405f));
            cube.transform.position = new Vector3(locX, locY , -parentPos.z);
            cube.transform.localScale = new Vector3(scaleX, scaleY, scaleZ);
            Renderer renderer = cube.GetComponent<Renderer>();

            // Specify min and max CF values
            int scaleIndex = Mathf.RoundToInt(Mathf.Clamp(data_set[i].v, 0.0000182993f, 0.0014567246f) / 0.0014567246f * (colors.Length - 1));
            Color color = colors[scaleIndex];

            Material material = new Material(Shader.Find("Standard"));
            material.color = color;
            renderer.material = material;

        }
    }
}
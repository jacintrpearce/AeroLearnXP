using UnityEngine;

public class ColourGradient : MonoBehaviour
{
    public Gradient GetGradient()
    {
        Gradient gradient = new Gradient();
        // Add color keys and alpha keys to the gradient
        GradientColorKey[] colorKeys = new GradientColorKey[2];
        colorKeys[0].color = Color.red;
        colorKeys[0].time = 0.0f;
        colorKeys[1].color = Color.blue;
        colorKeys[1].time = 1.0f;
        GradientAlphaKey[] alphaKeys = new GradientAlphaKey[2];
        alphaKeys[0].alpha = 1.0f;
        alphaKeys[0].time = 0.0f;
        alphaKeys[1].alpha = 1.0f;
        alphaKeys[1].time = 1.0f;
        gradient.SetKeys(colorKeys, alphaKeys);
        
        return gradient;
    }
}
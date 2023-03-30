using UnityEngine;

public static class ColorGradient
{
    public static Gradient GetGradient()
    {
        Gradient gradient = new Gradient();
// Add color keys and alpha keys to the gradient
        GradientColorKey[] colorKeys = new GradientColorKey[7];
        colorKeys[0].color = Color.blue;
        colorKeys[0].time = 0.0f;
        colorKeys[1].color = Color.cyan;
        colorKeys[1].time = 0.1666f;
        colorKeys[2].color = Color.green;
        colorKeys[2].time = 0.3333f;
        colorKeys[3].color = Color.yellow;
        colorKeys[3].time = 0.5f;
        colorKeys[4].color = Color.magenta;
        colorKeys[4].time = 0.6666f;
        colorKeys[5].color = Color.red;
        colorKeys[5].time = 0.8333f;
        colorKeys[6].color = Color.red;
        colorKeys[6].time = 1.0f;
        GradientAlphaKey[] alphaKeys = new GradientAlphaKey[2];
        alphaKeys[0].alpha = 1.0f;
        alphaKeys[0].time = 0.0f;
        alphaKeys[1].alpha = 1.0f;
        alphaKeys[1].time = 1.0f;
        gradient.SetKeys(colorKeys, alphaKeys);
        gradient.mode = GradientMode.Fixed;
        return gradient;

    }
}

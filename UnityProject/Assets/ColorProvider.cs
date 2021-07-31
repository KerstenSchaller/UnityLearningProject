using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ColorProvider
{

    public static Color getColor()
    {  
        List<Color> colors = new List<Color>();
        colors.Add(Color.red);
        colors.Add(Color.green);
        colors.Add(Color.blue);
        colors.Add(Color.cyan);
        colors.Add(Color.black);
        colors.Add(Color.magenta);

        int randIndex = Random.Range(0, colors.Count);
        return colors[randIndex];

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathTool
{

    public static Vector3 V2To3(Vector2 input)
    {
        return new Vector3(input.x, input.y, 0);
    }

    public static bool interval(float a, float l, float r)
    {
        return (l <= a && a <= r);
    }

    public static Vector3 angelDistance(Quaternion a, Quaternion b)
    {  
        Vector3 tmp = a.eulerAngles - b.eulerAngles;
        for (int i = 0; i < 3; i++)
        {
            tmp[i] %= 180;
            if(tmp[i]<0)
                tmp[i] = (-tmp[i])<(tmp[i]+180)?tmp[i]:(tmp[i]+180);
            if(tmp[i]>0)
                tmp[i] = (tmp[i])<(180-tmp[i])?tmp[i]:(tmp[i]-180);
        }
        return tmp;
    }

    public static float BoolToOne(bool a)
    {
        return a?1f:-1f;
    }
}

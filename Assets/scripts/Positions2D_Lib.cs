using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Positions2D_Lib : MonoBehaviour
{

    public static Vector2 getMousePos()
    {
        // Camera.main.transform.position.x
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);   //mousePosition is a Vector.
    }

    public static Vector2 getCurrentPosOf(GameObject gameObj)
    {
        return new Vector2(gameObj.transform.position.x, gameObj.transform.position.y);
    }

    public static Vector2 getCurrentPosOf(Transform transf)
    {
        return new Vector2(transf.position.x, transf.position.y);
    }

}

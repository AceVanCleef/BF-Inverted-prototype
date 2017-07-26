using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// aids in calculating the facing direction of spite objects.
/// </summary>
public class FacingDirection2D : MonoBehaviour {

    public enum FacingDirection
    {
        UP = 270,
        DOWN = 90,
        LEFT = 180,
        RIGHT = 0
    }

    /// <summary>
    /// call this method by "transform.rotation = FacingDirection2D.FacingObject(...)"
    /// </summary>
    /// <param name="startingPosition"></param>
    /// <param name="targetPosition"></param>
    /// <param name="facing"></param>
    /// <returns></returns>
    public static Quaternion FaceObject(Vector2 startingPosition, Vector2 targetPosition, FacingDirection facing)
    {
        Vector2 direction = targetPosition - startingPosition;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        angle -= (float)facing;
        return Quaternion.AngleAxis(angle, Vector3.forward);
    }

    //source and usage: http://answers.unity3d.com/questions/654222/make-sprite-look-at-vector2-in-unity-2d-1.html

   
}

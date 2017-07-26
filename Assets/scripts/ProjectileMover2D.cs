using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMover2D : MonoBehaviour {

    public float speed = 1.0f;

    void Start()
    {
        shoot();
    }

    private void shoot()
    {
        faceSpriteTowardsMousePos();
        shootTowardsMousePos();
    }

    /// <summary>
    /// returns the direction towards the mouse' current position.
    /// 
    /// Note: version with FacingDirection2D.FaceObject(...).
    ///       See http://answers.unity3d.com/questions/654222/make-sprite-look-at-vector2-in-unity-2d-1.html
    /// </summary>
    /// <returns></returns>
    private void faceSpriteTowardsMousePos()
    {
        transform.rotation = FacingDirection2D.FaceObject(getCurrentPos(), getMousePos(), FacingDirection2D.FacingDirection.RIGHT);
        //fix: this aims towards wrong direction
    }


    private void shootTowardsMousePos()
    {
        Vector2 direction = GetComponent<ProjectileMover2D>().getDirectionTowardsMousePos();
        direction.Normalize();
        GetComponent<Rigidbody2D>().velocity = direction * speed;
    }


    private Vector2 getDirectionTowardsMousePos()
    {
        return getMousePos() - getCurrentPos();
    }

    private Vector2 getCurrentPos()
    {
        return new Vector2(transform.position.x, transform.position.y);
    }

    private Vector2 getMousePos()
    {
       // Camera.main.transform.position.x
        return Camera.main.ScreenToWorldPoint( Input.mousePosition );   //mousePosition = Vector.
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ProjectileMover2D : MonoBehaviour {

    public float speed = 1.0f;

    void Start()
    {
        if (tag.Equals("Projectile"))   //not quite right
        {
           shootWithMouse();
        }
        else //EnemyProjectile
        {
            shootWithcontroller();
        }

    }

    private void shootWithcontroller()
    {
        //sprite orientation
        transform.rotation = FacingDirection2D.FaceObject(getCurrentPos(), FacingDirection2D.getControllerRightAxisVector(), FacingDirection2D.FacingDirection.RIGHT);
        //shoot into direction of controller's right stick
        Vector2 direction = FacingDirection2D.getControllerRightAxisVector();
        direction.Normalize();
        GetComponent<Rigidbody2D>().velocity = direction * speed;
    }

    private void shootWithMouse()
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
        transform.rotation = FacingDirection2D.FaceObject(getCurrentPos(), Positions2D_Lib.getMousePos(), FacingDirection2D.FacingDirection.RIGHT);
    }


    private void shootTowardsMousePos()
    {
        Vector2 direction = GetComponent<ProjectileMover2D>().getDirectionTowardsMousePos();
        direction.Normalize();
        GetComponent<Rigidbody2D>().velocity = direction * speed;
    }


    private Vector2 getDirectionTowardsMousePos()
    {
        return Positions2D_Lib.getMousePos() - getCurrentPos();
    }

    private Vector2 getCurrentPos()
    {
        return new Vector2(transform.position.x, transform.position.y);
    }

    

}

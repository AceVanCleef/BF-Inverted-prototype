using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMover2D : MonoBehaviour {

    public float speed = 1.0f;


    public void setDirection2D(Vector2 direction)
    {
        GetComponent<Rigidbody2D>().velocity = direction * speed;
    }

    public Vector2 getDirectionTowardsMousePos()
    {
        return getMousePos() - getCurrentPos();
    }

    private Vector2 getCurrentPos()
    {
        return new Vector2(transform.position.x, transform.position.y + 1);
    }

    private Vector2 getMousePos()
    {
        return Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y));
    }

}

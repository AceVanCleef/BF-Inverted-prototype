using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]   //Classes need to be serialized in order to make its public fields visible in Unity's inspector.
public class Boundary2D   //no ": MonoBehavior" because this class doesn't need the given functions such as Update(), Start(), etc.
{
    public float xMin, xMax, yMin, yMax;
}

public class PlayerController2D : MonoBehaviour {


    /********************************* setup (controller) *********************************/

    //identification of player or enemy
    private string xAxis;
    private string yAxis;
    private string fire1;

    void Start()
    {
        if (tag.Equals("Player"))
        {
            xAxis = "Horizontal";
            yAxis = "Vertical";
            fire1 = "Fire1";
        }
        else //Enemy
        {
            xAxis = "HorizontalOnController";
            yAxis = "VerticalOnController";
            fire1 = "Fire1OnController";
        }
    }

    /********************************* movement of character *********************************/


    public float speed;
    public Boundary2D boundary;


    void FixedUpdate()
    {
        //source "Input.GetAxis": https://docs.unity3d.com/ScriptReference/Input.GetAxis.html
        float moveHorizontal = Input.GetAxis(xAxis) * speed;
        float moveVertical = Input.GetAxis(yAxis) * speed;

        Rigidbody2D rigidBody = GetComponent<Rigidbody2D>();
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        //rigidBody.velocity = movement;
        rigidBody.AddForce(movement);

        rigidBody.position = new Vector2(
            Mathf.Clamp(rigidBody.position.x, boundary.xMin, boundary.xMax),
            Mathf.Clamp(rigidBody.position.y, boundary.yMin, boundary.yMax)
            );
    }

    /********************************* shooting a bolt *********************************/

    public GameObject shot;
    //public GameObject shotSpawn;
    public Transform shotSpawn; //Unity automatically gets the Transform property of GameObject shotSpawn.
    public Transform gun;


    public float fireRate; //= 0.5f;
    private float newFire = 0.0f;   //when the next shot can be fired (in seconds)

    void Update()
    {
        //shotSpawn orientation:
        

        if (tag.Equals("Player"))
        {
            gun.transform.rotation = FacingDirection2D.FaceObject(
            Positions2D_Lib.getCurrentPosOf(shotSpawn),
            Positions2D_Lib.getMousePos(),
            FacingDirection2D.FacingDirection.RIGHT
            );
        }
        else
        {
            gun.transform.rotation = FacingDirection2D.FaceObject(
            new Vector2(0,0),
            FacingDirection2D.getControllerRightAxisVector(),
            FacingDirection2D.FacingDirection.RIGHT
            );
        }

            //shooting:
            if (Input.GetButton(fire1) && Time.time > newFire)
        {
            newFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);

            //when you want to get a reference to the shot object, see this:
            //https://docs.unity3d.com/ScriptReference/Input.GetButton.html
        }
    }
}

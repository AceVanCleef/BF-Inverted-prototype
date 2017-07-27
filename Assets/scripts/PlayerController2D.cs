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
    private string fire2;
    private string fire3;

    void Start()
    {
        if (tag.Equals("Player"))
        {
            xAxis = "Horizontal";
            yAxis = "Vertical";
            fire1 = "Fire1";
            fire2 = "Fire2";
            fire3 = "Fire3";
        }
        else //Enemy
        {
            xAxis = "HorizontalOnController";
            yAxis = "VerticalOnController";
            fire1 = "Fire1OnController";
            fire2 = "Fire2OnController";
            fire3 = "Fire3OnController";
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

    /********************************* shooting projectiles, dropping hazards *********************************/

    public GameObject shot;
    //public GameObject shotSpawn;
    public Transform shotSpawn; //Unity automatically gets the Transform property of GameObject shotSpawn.
    public Transform gun;

    public float fireRate = 0.25f;
    private float newFire = 0.0f;   //when the next shot can be fired (in seconds)


    //deadly medipacks:
    public GameObject hazard;
    public float hazardDropRate = 4.0f;
    private float newHazard = 0.0f;
    /* the VFX on top of shotSpawn for "while holding" */
    public SpriteRenderer hazardVFXWhileWalking;

    //either you shoot or you hold and drop a hazard
    private bool areHandsEmpty = true;

    void Update()
    {
        //shotSpawn orientation:
        

        //gun rotation
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
        if (Input.GetButton(fire1) && areHandsEmpty && Time.time > newFire)
        {
            newFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);

            //when you want to get a reference to the shot object, see this:
            //https://docs.unity3d.com/ScriptReference/Input.GetButton.html
        }

        //pick up a hazards (deadly medipacks)
        if (Input.GetButton(fire2) && Time.time > newHazard && areHandsEmpty)
        {
 
                pickupHazard();
                areHandsEmpty = false;

        }

        if (Input.GetButton(fire3) && Time.time > newHazard && !areHandsEmpty)
        {
            
                dropHazard();
                areHandsEmpty = true;
            
        }





    }

    private void pickupHazard()
    {
        //timing
        newHazard = Time.time + hazardDropRate;

        hazardVFXWhileWalking.enabled = true;
        print(hazardVFXWhileWalking.enabled);
    }

    private void dropHazard()
    {
        //deactivate hazard box VFX
        hazardVFXWhileWalking.enabled = false;
        //and drop instance of it on game level
        GameObject hazardInstance = Instantiate(hazard, shotSpawn.position, shotSpawn.rotation) as GameObject;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGame : MonoBehaviour {

    public GameObject player;
    public GameObject enemy;

    private UnitHealth playerHP;
    private UnitHealth enemyHP;


    // Use this for initialization
    void Start () {
        playerHP = player.GetComponent<UnitHealth>();
        enemyHP = enemy.GetComponent<UnitHealth>();
    }

    // Update is called once per frame
    void Update () {
		if (Input.GetButton("ResetGame") || Input.GetButton("ResetGameOnController"))
        {
            print("why the fck");
            newGame();
        }
	}

    public void newGame()
    {
        //reset playerHPs
        playerHP.resetHealth();
        enemyHP.resetHealth();
    }
}

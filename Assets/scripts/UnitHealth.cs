using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UnitHealth : MonoBehaviour {

    public int maxHealth = 100;
    private int currentHealth;

    public GameObject GUITextHolder;
    private Text healthAsText;

    private bool isDead = false;

	// Use this for initialization
	void Start () {
        currentHealth = maxHealth;

        healthAsText = GUITextHolder.GetComponent<Text>();
        healthAsText.text = currentHealth.ToString();

        print("Current health is: " + currentHealth);
	}
	

    public void sufferDamage(int amount)
    {
        print("damage: " + amount);

        if (!isDead && currentHealth - amount >= 0)
        {
            currentHealth += amount;
        }
        else
        {
            currentHealth = 0;
        }
        //update GUI
        healthAsText.text = currentHealth.ToString();

        if (currentHealth <= 0)
        {
            isDead = true;
        }
    }

    public void regainHealth(int amount)
    {
        if (!isDead && currentHealth + amount > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else if (!isDead)
        {
            currentHealth += amount;
        }
        //update GUI
        healthAsText.text = currentHealth.ToString();

    }

    public bool IsDead()
    {
        return isDead;
    }
}

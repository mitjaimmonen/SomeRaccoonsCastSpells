using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    float maxHealth;
    float currentHealth;

    public void takeDamage(float value)
    {
        currentHealth -= value;
    }

    public void heal (float value)
    {
        currentHealth += value;
    }

    public void setHealthToMax()
    {
        currentHealth = maxHealth;
    }


}

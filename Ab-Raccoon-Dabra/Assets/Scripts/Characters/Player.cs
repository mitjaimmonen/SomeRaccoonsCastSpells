using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {

    [SerializeField]
    float maxHealth;

    private void Awake()
    {
        health = new Health(maxHealth);
    }

}

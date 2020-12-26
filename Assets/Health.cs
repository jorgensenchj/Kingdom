using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int currentHealth;
    bool IsDead;




    // Start is called before the first frame update
    void Start()
    {
        currentHealth = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        print("death");
    }
}

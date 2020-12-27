using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int currentHealth;
    bool IsDead;
    public int currentStamina;
    public int loyalty;
    [SerializeField] bool RaceOrc;
    [SerializeField] bool RaceHumanHuman;
    [SerializeField] bool RaceElf;
    [SerializeField] bool RaceUndead;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = 100;
        if(RaceOrc == true)
        {
            loyalty = -20;
        }
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

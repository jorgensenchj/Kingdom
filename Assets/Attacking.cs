using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacking : MonoBehaviour
{
    public GameObject Radar;
    bool AttackEnemy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AttackEnemy = Radar.GetComponent<Radar>().Attack;
        if(AttackEnemy == true)
        {
            ChaseEnemy();
        }
    }
    void ChaseEnemy()
    {
        print("get the ENEMY");
    }
}

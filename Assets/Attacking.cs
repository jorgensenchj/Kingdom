using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacking : MonoBehaviour
{
    public GameObject Radar;
    bool AttackEnemy;
    UnityEngine.AI.NavMeshAgent nav;
    public GameObject AttackTarget;

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        AttackTarget = Radar.GetComponent<Radar>().target;
        AttackEnemy = Radar.GetComponent<Radar>().Attack;
        if(AttackEnemy == true)
        {
            ChaseEnemy();
        }
    }
    void ChaseEnemy()
    {
        print("get the ENEMY");
        if(AttackTarget != null)
        {
            nav.SetDestination(AttackTarget.transform.position);
        }
       
    }
    void AvoidEnemy()
    {
        print("RunAway");
    }
}

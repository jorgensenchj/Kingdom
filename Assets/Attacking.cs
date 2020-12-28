using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacking : MonoBehaviour
{
    Animator anim;
    public GameObject Radar;
    [SerializeField] bool AttackEnemy;
    UnityEngine.AI.NavMeshAgent nav;
    public GameObject AttackTarget;
    public GameObject Flag;
    [SerializeField] bool IsRedGuy;
    [SerializeField] bool forward;
    [SerializeField] bool retreat;
    bool useMelee;

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        IsRedGuy = Radar.GetComponent<Radar>().IsRed;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        AttackTarget = Radar.GetComponent<Radar>().target;
        AttackEnemy = Radar.GetComponent<Radar>().Attack;
        if (AttackEnemy == true)
        {
            ChaseEnemy();
            forward = true;
            retreat = false;
        }
        else
        if (AttackEnemy == false)
        {
            AvoidEnemy();
            retreat = true;
            forward = false;
        }
    }
    void ChaseEnemy()
    {
        print("get the ENEMY");
        if (AttackTarget == null)
        {
            nav.SetDestination(gameObject.transform.position);
            print("Patrol");
        }
        else
        if (AttackTarget != null)
        {
            if (IsRedGuy == true)
            {

                if (AttackTarget.GetComponent<Allegiance>().RedTeam == true)
                {
                    AttackTarget = null;
                }
                else
                if (AttackTarget.GetComponent<Allegiance>().RedTeam == false)
                {
                    float dist = Vector3.Distance(AttackTarget.transform.position, transform.position);
                    nav.SetDestination(AttackTarget.transform.position);
                    if(dist < 2)
                    {
                        useMelee = true;
                        anim.SetBool("Attacking", useMelee);
                        nav.SetDestination(gameObject.transform.position);
                    }
                    if(dist >= 2)
                    {
                        useMelee = false;
                        anim.SetBool("Attacking", useMelee);
                        nav.SetDestination(AttackTarget.transform.position);
                    }
                }
            }
            else
             if (IsRedGuy == false)
            {
                if (AttackTarget.GetComponent<Allegiance>().RedTeam == false)
                {
                    AttackTarget = null;
                }
                else
                if (AttackTarget.GetComponent<Allegiance>().RedTeam == true)
                {
                    nav.SetDestination(AttackTarget.transform.position);
                    print("Fighting");
                }
            }
        }

    }
    void AvoidEnemy()
    {
        nav.SetDestination(Flag.transform.position);
        print("Run Away");
    }

   

}

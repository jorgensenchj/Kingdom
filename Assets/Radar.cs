using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar : MonoBehaviour
{

    public List<GameObject> bodys = new List<GameObject>();
    public GameObject target;
    [SerializeField] int blues;
    [SerializeField] int reds;
    public bool Attack;
    public bool IsRed;
    int sizeOfList;
    bool tripCoroutine;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        sizeOfList = bodys.Count;
        if (sizeOfList <= 0)
        {
            if (IsRed == true)
            {
                blues = 0;
                reds = 1;
                Attack = true;
            }
            else
            if (IsRed == false)
            {
                blues = 1;
                reds = 0;
                Attack = true;
            }
            
        }
        if(sizeOfList > 0)
        {
            if (tripCoroutine == false)
            {
                if (IsRed == true)
                {
                    if (reds >= blues )
                    {
                        Attack = true;

                    }
                    else
                    if (reds < blues)
                    {
                      //  Attack = false;
                        tripCoroutine = true;
                        StartCoroutine(RetreatCoroutine());
                    }
                }
                if (IsRed == false)
                {
                    if (reds <= blues)
                    {
                        Attack = true;
                    }
                    else
                    if (reds > blues)
                    {
                      //  Attack = false;
                        tripCoroutine = true;
                        StartCoroutine(RetreatCoroutine());
                    }
                }
            }
      
        }
      
        
    }

    IEnumerator RetreatCoroutine()
    {
        yield return new WaitForSeconds(5);
        tripCoroutine = false;
        Attack = false;

    }



        void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Character")
        {
            if (!bodys.Contains(other.gameObject)) bodys.Add(other.gameObject);
            if (other.GetComponent<Allegiance>().RedTeam == true)
            {
                reds++;
            }
            else
            if (other.GetComponent<Allegiance>().RedTeam == false)
            {
                blues++;
            }
         



        }
        //   AssignSides();
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Character")
        {
            if (bodys.Contains(other.gameObject)) bodys.Remove(other.gameObject);
            {
                if (other.GetComponent<Allegiance>().RedTeam == true)
                {
                    reds--;
                }

                else
            if (other.GetComponent<Allegiance>().RedTeam == false)
                {
                    blues--;
                }
            }

        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Character")
        {
            if (IsRed == true && other.GetComponent<Allegiance>().RedTeam == false)
            {
                if (Attack == true)
                {
                    target = other.gameObject;
                }
            }else
            if (IsRed == false && other.GetComponent<Allegiance>().RedTeam == true)
            {
                if (Attack == true)
                {
                    target = other.gameObject;
                }
            }else return;
        }
    }





}



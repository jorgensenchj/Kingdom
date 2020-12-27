using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar : MonoBehaviour
{

    public List<GameObject> bodys = new List<GameObject>();
    [SerializeField] int blues;
    [SerializeField] int reds;
    public bool Attack;
    [SerializeField] bool IsRed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (bodys.GetRange == 0)
        {
            blues = 0;
            reds = 0;
        }
        if(IsRed == true)
        {
            if(reds >= blues)
            {
                Attack = true;
            }else
                if(reds < blues)
            {
                Attack = false;
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
                Attack = false;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Character")
        {
            if (!bodys.Contains(other.gameObject)) bodys.Add(other.gameObject);
        }
        AssignSides();
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Character")
        {
            if (bodys.Contains(other.gameObject)) bodys.Remove(other.gameObject);
        }
        RemoveSides();
    }

    void AssignSides()
    {
        foreach (GameObject ObjectBody in bodys)
        {
           if( ObjectBody.GetComponent<Allegiance>().RedTeam == true)
            {
                blues  ++;
            }
            else
            if (ObjectBody.GetComponent<Allegiance>().RedTeam == false)
            {
                reds  ++;
            }
        }

    }
    void RemoveSides()
    {
        foreach (GameObject ObjectBody in bodys)
        {
            if (ObjectBody.GetComponent<Allegiance>().RedTeam == true)
            {
                blues--;
            }
            else
             if (ObjectBody.GetComponent<Allegiance>().RedTeam == false)
            {
                reds--;
            }
        }

    }
}

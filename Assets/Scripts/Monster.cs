using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : AIProperty
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetTarget(Transform target)
    {
        myNavAgent.SetDestination(target.position);
        myAnim.SetBool("Walk Forward", true);
    }
}

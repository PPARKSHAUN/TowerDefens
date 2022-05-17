using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIProperty : MonoBehaviour
{
    NavMeshAgent _navAgent = null;
    protected NavMeshAgent myNavAgent
    {
        get
        {
            if(_navAgent == null)
            {
                _navAgent = this.GetComponent<NavMeshAgent>();

            }
            return _navAgent;
        }
    }

    Animator _anim = null;
    protected Animator myAnim
    {
        get
        {
            if(_anim == null)
            {
               _anim= this.GetComponentInChildren<Animator>();
            }
            return _anim;
        }
    }
}

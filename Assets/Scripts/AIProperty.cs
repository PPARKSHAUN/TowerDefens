using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIProperty : MonoBehaviour
{
    #region Component
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
               _anim = this.GetComponentInChildren<Animator>();
            }
            return _anim;
        }
    }
    #endregion
    [SerializeField] MonsterData _data = null;
    protected MonsterData myData
    {
        get => _data;        
    }
    float? CurHP = null;
    protected bool UpdateHP(float data)
    {
        if(CurHP == null)
        {
            CurHP = myData.GetMaxHP();
        }
        CurHP += data;
        if (CurHP <= 0.0f)
        {
            CurHP = 0.0f;
            return false;
        }
        return true;
    }
}

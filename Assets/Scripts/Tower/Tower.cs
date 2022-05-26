using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tower : MonoBehaviour
{
    public enum State
    {
        CREATE, WAIT, ATTACK
    }
    public State myState = State.CREATE;
    [SerializeField] protected Monster _target = null;
    [SerializeField] protected List<Monster> Monsters = new List<Monster>();
    [SerializeField] protected TowerData myData = null;
    public Transform myMuzzle = null;
    public Transform myTurret = null;
    public GameObject BulletSource = null;
    protected float playTime = 0.0f;
    protected float attackDelay = 1.0f;
    protected int myLevel = 1;

    protected abstract void OnAttack();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {        
    }

    void ChangeState(State s)
    {
        if (myState == s) return;
        myState = s;
        switch(myState)
        {
            case State.CREATE:
                break;
            case State.WAIT:
                break;
            case State.ATTACK:
                break;
        }
    }

    protected void StateProcess()
    {
        switch (myState)
        {
            case State.CREATE:
                break;
            case State.WAIT:
                break;
            case State.ATTACK:
                if (!_target.IsLive()) _target = FindTarget();
                if (_target == null)
                {
                    ChangeState(State.WAIT);
                    return;
                }
                OnAttack();                                
                break;
        }
    }

    protected void OnFire(Transform target = null)
    {
        if (target == null) return;
        Projectile bullet = Instantiate(BulletSource, myMuzzle.position, myMuzzle.rotation).GetComponent<Projectile>();
        bullet.OnFire(myData.GetDamage(myLevel - 1), target);
    }

    Monster FindTarget()
    {
        float Min = 999.0f;
        int? Select = null;
        for(int i = 0; i < Monsters.Count;)
        {
            if (Monsters[i].IsLive())
            {
                float dist = Vector3.Distance(this.transform.position, Monsters[i].transform.position);
                if (dist < Min)
                {
                    Min = dist;
                    Select = i;
                }
                ++i;
            }
            else
            {
                Monsters.RemoveAt(i);                
            }
        }

        if(Select != null)
        {
            return Monsters[Select.Value];
        }

        return null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Monster"))
        {
            Monster scp = other.gameObject.GetComponent<Monster>();
            Monsters.Add(scp);
            if(_target == null)
            {
                _target = scp;
                ChangeState(State.ATTACK);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Monster"))
        {
            Monster scp = other.GetComponent<Monster>();
            Monsters.Remove(scp);

            if(_target == scp)
            {
                _target = FindTarget();
                if(_target == null)
                {
                    ChangeState(State.WAIT);
                }
            }
        }
    }

    protected void LookAtTarget()
    {
        myTurret.rotation = Quaternion.Slerp(myTurret.rotation,
          Quaternion.LookRotation(_target.transform.position - myTurret.position), Time.deltaTime * 10.0f);
    }
}

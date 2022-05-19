using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public enum State
    {
        CREATE,WAIT,ATTACK
    }
    public State myState = State.CREATE;
    [SerializeField] Monster _target = null;
    [SerializeField] List<Monster> Monsters = new List<Monster>();
    public Transform myMuzzle = null;
    public Transform myTurret = null;
    public GameObject BulletSource = null;
    float playTime = 0.0f;
    float attackDelay = 1.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        StateProcess();
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

    void StateProcess()
    {
        switch (myState)
        {
            case State.CREATE:
                break;
            case State.WAIT:
                break;
            case State.ATTACK:
                myTurret.LookAt(_target.transform);
                playTime += Time.deltaTime;
                if(playTime >= attackDelay)
                {
                    playTime = 0.0f;
                    OnFire();
                }
                
                break;
        }
    }

    void OnFire()
    {
        Bullet bullet = Instantiate(BulletSource, myMuzzle.position,myMuzzle.rotation).GetComponent<Bullet>();
        bullet.OnFire();
    }
    Monster FindTarget()
    {
        float Min = 999.0f;
        int? Select = null;
        for(int i = 0; i<Monsters.Count;i++)
        {
            float dist = Vector3.Distance(this.transform.position, Monsters[i].transform.position);
            if(dist<Min)
            {
                Min = dist;
                Select = i;
            }
        }
        if(Select !=null)
        {
            return Monsters[Select.Value];
        }

        return null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Monster"))
        {
            Monster scp = other.gameObject.GetComponent<Monster>();
            Monsters.Add(scp);
            if (_target == null)
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
}

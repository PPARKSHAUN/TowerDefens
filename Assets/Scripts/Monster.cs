using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Monster : AIProperty
{
    public enum State
    {
        CREATE,LIVE,DEAD, GOAL
    }
    public State myState = State.CREATE;
    UnityAction<int> goalAction = null;
    UnityAction<int> dieAction = null;
    // Start is called before the first frame update
    void Start()
    {
        myNavAgent.speed = myData.GetMoveSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        StateProcess();
    }

    public void SetTarget(Transform target,UnityAction<int> goal,UnityAction<int> die)
    {
        dieAction = die;
        goalAction = goal;
        myNavAgent.SetDestination(target.position);
        myAnim.SetBool("Walk Forward", true);
        ChangeState(State.LIVE);
    }
    public void OnDamage(float damage)
    {
        if (!IsLive()) return;
        if(!UpdateHP(-damage))
        {
            ChangeState(State.DEAD);
           
        }
    }

    public bool IsLive()
    {
        return myState == State.LIVE;
    }
    void ChangeState(State s)
    {
        if (myState == s) return;
        myState = s;
        switch (myState)
        {
            case State.LIVE:
                break;
                case State.DEAD:
                dieAction.Invoke(myData.GetScore());
                myNavAgent.isStopped = true;
                Destroy(myNavAgent);
                Destroy(this.GetComponent<Collider>());
                myAnim.SetBool("Walk Forward", false);
                myAnim.SetTrigger("Die");
                StartCoroutine(Disapearing());
                break;
            case State.CREATE:
                break;
            case State.GOAL:
                goalAction?.Invoke(myData.GetReduceLife());
                Destroy(this.gameObject);
                break;

        }
    }

    void StateProcess()
    {
        switch (myState)
        {
            case State.LIVE:
                if(myNavAgent.remainingDistance<0.2f)
                {
                    ChangeState(State.GOAL);
                }
                break;
            case State.DEAD:
                break;
            case State.CREATE:
                break;
            case State.GOAL:
                break;

        }
    }


    IEnumerator Disapearing()
    {
        yield return new WaitForSeconds(2f);
        float dist = 1.0f;
        while(dist > 0.0f)
        {
            float delta = Time.deltaTime * 1.0f;
            dist -= delta;
            this.transform.Translate(Vector3.down * delta);
            yield return null;
        }

        Destroy(this.gameObject);

    }
}

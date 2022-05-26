using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Monster : AIProperty
{
    public enum State
    {
        CREATE, LIVE, DEAD, GOAL
    }
    public State myState = State.CREATE;
    UnityAction<int> goalAction = null;
    UnityAction<int> dieAction = null;
    [SerializeField]List<DeBuff> debufList = new List<DeBuff>();
    // Start is called before the first frame update
    void Start()
    {
        myNavAgent.speed = myData.GetMoveSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        StateProcess();
        for(int i=0; i<debufList.Count; )
        {
            DeBuff debuff = debufList[i];
            debuff.keepTime -= Time.deltaTime; //디버프 지속시간 - 시간 
            if(debuff.keepTime<=0.0f) //디버프 지속시간이 0보다적으면 
            {
                debufList.RemoveAt(i); //디버프 삭제 
                switch(debuff.Type) // 디버프 타입구별후 
                {
                    case DeBuffType.SLOW:

                        myNavAgent.speed = debuff.orgValue; //슬로우라면 원래속도로 복귀 
                        this.GetComponentInChildren<Renderer>().material.SetColor("_Color", Color.white); //디버프 끝나면 원래색으로
                        break;

                }
                continue;
            }
            debufList[i] = debuff;
            ++i;
        }
    }

    void ChangeState(State s)
    {
        if (myState == s) return;
        myState = s;
        switch(myState)
        {
            case State.CREATE:
                break;
            case State.LIVE:
                break;
            case State.DEAD:
                dieAction?.Invoke(myData.GetScore());
                myNavAgent.isStopped = true;
                Destroy(myNavAgent);
                Destroy(this.GetComponent<Collider>());
                myAnim.SetBool("Walk Forward", false);
                myAnim.SetTrigger("Die");
                StartCoroutine(Disapearing());
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
            case State.CREATE:
                break;
            case State.LIVE:
                if(!myNavAgent.pathPending && myNavAgent.pathStatus == UnityEngine.AI.NavMeshPathStatus.PathComplete && myNavAgent.remainingDistance < 0.2f)
                {
                    ChangeState(State.GOAL);
                }
                break;
            case State.DEAD:
                break;
        }
    }

    public void SetTarget(Transform target,UnityAction<int> goal,UnityAction<int> die)
    {
        dieAction = die;
        goalAction = goal;
        myNavAgent.SetDestination(target.position);
        myAnim.SetBool("Walk Forward", true);
        ChangeState(State.LIVE);
    }

    IEnumerator SetDest(Vector3 pos)
    {
        yield return myNavAgent.SetDestination(pos);
    }

    public void OnDamage(float damage)
    {
        if (!IsLive()) return;
        if(!UpdateHP(-damage))
        {
            ChangeState(State.DEAD);            
        }
    }

    public void AddDebuff(DeBuffType type, float keepTime, float Value) // 디버프 리스트에 디버프 추가 
    {
        float org = 0f;
        switch (type) //타입구별 
        {
            case DeBuffType.SLOW: //SLOW 타입
                for (int i = 0; i < debufList.Count; i++) 
                {
                    
                    if (debufList[i].Type == type)  //추가된 디버프와 타입이같다면 
                    {
                        DeBuff debuff = debufList[i];
                        debuff.keepTime =keepTime; // 디버프시간 초기화 
                        debufList[i] = debuff;
                        return;
                    }
                }
                org = myNavAgent.speed; //원래 속도값 저장 디버프가 끝나면 되돌아갈 속도 
                myNavAgent.speed *= Value; // 이동속도 저하 
                this.GetComponentInChildren<Renderer>().material.SetColor("_Color", Color.blue);//디버프시 몬스터색상파란색으로변경
                break;

        }
        debufList.Add(new DeBuff(type, keepTime, Value,org)); 
    }
    public bool IsLive()
    {
        return myState == State.LIVE;
    }

    IEnumerator Disapearing()
    {
        yield return new WaitForSeconds(2.0f);
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

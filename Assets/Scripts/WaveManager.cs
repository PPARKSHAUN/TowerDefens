using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WaveManager : MonoBehaviour
{
    public enum State
    {
        CREATE,PLAY,END

    }
    public State myState = State.CREATE;
    public WaveData[] Wavelist;
    [SerializeField] int CurWave = 0;
    public Transform StartPoint;
    public Transform DestPoint;

    public GameObject MonsterSource;
    public Transform MonsterGrid;
    [SerializeField]List<Monster> Monsterlist = new List<Monster>();
    [SerializeField]float timeGap = 0.0f;
    float playTime = 0.0f;
    int Curindex = 0;
    UnityAction<int> goalAction = null;
    UnityAction<int> dieAction = null;
    // Start is called before the first frame update
    void Start()
    {
        Curindex = 0;
        timeGap = Wavelist[CurWave].GetTimeGap();
       
    }

    public void OnPlay(UnityAction<int> goal,UnityAction<int> die)
    {
        dieAction = die;
        goalAction = goal;
        ChangeState(State.PLAY);

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
                case State.PLAY:
                break;
            case State.END:
                break;

        }
    }

    void StateProcess()
    {
        switch (myState)
        {
            case State.CREATE:
                break;
            case State.PLAY:
                playTime += Time.deltaTime;
                if(playTime >= timeGap)
                {
                    playTime = 0.0f;
                    CreateMonster(Wavelist[CurWave].GetMonster(Curindex++));
                }
                break;
            case State.END:
                break;

        }

    }
    void CreateMonster(MonsterType mon)
    {
        switch(mon)
        {
            case MonsterType.NONE:
                if(++CurWave == Wavelist.Length)
                {
                    ChangeState(State.END);
                }
                else
                {
                    Curindex = 0;
                    playTime=timeGap = Wavelist[CurWave].GetTimeGap();
                }
                break;
            case MonsterType.DEVIL:
                Monsterlist.Add(Instantiate(MonsterSource, StartPoint.position, StartPoint.rotation, MonsterGrid).GetComponent<Monster>());
                Monsterlist[Monsterlist.Count - 1].SetTarget(DestPoint,goalAction,dieAction);
                break;
        }
        
    }
}

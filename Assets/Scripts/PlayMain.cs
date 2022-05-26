using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayMain : MonoBehaviour
{
    [SerializeField] int myLife = 5;
    int Life
    {
        get => myLife;
        set
        {
            myLife = value;
            if(myLife <= 0)
            {
                myLife = 0;
                ChangeState(State.GAMEOVER);
            }
            myInfoUI.lifeLabel.text = myLife.ToString();
        }
    }
    [SerializeField] int myScore = 0;
    int Score
    {
        get => myScore;
        set
        {
            myScore = value;
            myInfoUI.scoreLabel.text = myScore.ToString();
        }
    }
    public enum State
    {
        CREATE, START, PLAY, GAMEOVER, CLEAR
    }
    public State myState = State.CREATE;
    public MapManager myMap = null;
    public WaveManager myWave = null;
    public GameInfoUI myInfoUI = null;
    // Start is called before the first frame update
    void Start()
    {
        ChangeState(State.START);
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
            case State.START:
                Score = 0;
                Life = 5;
                ChangeState(State.PLAY);
                break;
            case State.PLAY:
                myWave.OnPlay(v => Life -= v, v => Score += v);
                break;
            case State.GAMEOVER:
                break;
            case State.CLEAR:
                break;
        }
    }

    void StateProcess()
    {
        switch (myState)
        {
            case State.CREATE:
                break;
            case State.START:
                break;
            case State.PLAY:
                if (Input.GetMouseButtonDown(0))
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    if (Physics.Raycast(ray, out RaycastHit hit, 999.0f, 1 << LayerMask.NameToLayer("Tile")))
                    {
                        myMap.CreateTower(TowerType.ICE, hit.transform);
                    }
                }
                if (Input.GetMouseButtonDown(1))
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    if (Physics.Raycast(ray, out RaycastHit hit, 999.0f, 1 << LayerMask.NameToLayer("Tile")))
                    {
                        myMap.DestroyTower(hit.transform);
                    }
                }
                break;
            case State.GAMEOVER:
                break;
            case State.CLEAR:
                break;
        }
    }
}

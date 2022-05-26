using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MonsterType
{
    NONE,DEVIL
}
[CreateAssetMenu(fileName = "WaveData", menuName = "WaveData", order = int.MinValue)]
public class WaveData : ScriptableObject
{
    [SerializeField] MonsterType[] Monsterlist;
    [SerializeField]float timeGap = 2.0f;
    public float GetTimeGap() => timeGap;
    int CurIndex = 0;
    
    public MonsterType GetMonster( int i )
    {
        return i == Monsterlist.Length ? MonsterType.NONE : Monsterlist[i];
       
    }
}

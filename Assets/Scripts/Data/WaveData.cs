using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MonsterType
{
    NONE, DEVIL, ZOMBIE
}

[CreateAssetMenu(fileName = "WaveData", menuName = "WaveData", order = int.MinValue + 1)]
public class WaveData : ScriptableObject
{
    [SerializeField] MonsterType[] Monsterlist;
    [SerializeField] float timeGap = 2.0f;
    public float GetTimeGap() => timeGap;    
    public MonsterType GetMonster(int i) => i == Monsterlist.Length ? MonsterType.NONE : Monsterlist[i];
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MonsterData", menuName = "MonsterData", order = int.MinValue)]
public class MonsterData : ScriptableObject
{
    [SerializeField] float MaxHP = 100f;
    [SerializeField] int ReduceLife = 1;
    [SerializeField] int Score = 10;
    [SerializeField] float moveSpeed = 1.0f;
    public int GetReduceLife() => ReduceLife;
    public float GetMaxHP() => MaxHP;
    public int GetScore() => Score;
    public float GetMoveSpeed() => moveSpeed;
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public enum DeBuffType //디버프 타입 enum
{
    SLOW,POISION,BLOOD
}
public struct DeBuff //디버프 사용을위해 구조체 
{
    public DeBuffType Type; // 디버프 타입
    public float keepTime; //디버프 유지시간 
    public float Value; // 디버프 값 
    public float orgValue;
    public DeBuff(DeBuffType type,float keepTime, float Value,float org = 0f) 
    {
        Type = type;
        this.keepTime = keepTime;
        this.Value = Value;
        this.orgValue = org;
    }



}
public abstract class Projectile : MonoBehaviour
{
    public GameObject effectSource;
    protected bool Move = false;
    [SerializeField] protected float Speed = 10.0f;
    protected float Damage = 0.0f;
    public abstract void OnFire(float Damage, Transform target);
}
public enum TowerType
{
    NORMAL,CANNON,ICE
}
public class GameData
{    
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public enum DeBuffType //����� Ÿ�� enum
{
    SLOW,POISION,BLOOD
}
public struct DeBuff //����� ��������� ����ü 
{
    public DeBuffType Type; // ����� Ÿ��
    public float keepTime; //����� �����ð� 
    public float Value; // ����� �� 
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract class Projectile :MonoBehaviour
{
    public GameObject effectSource;
    protected bool Move = false;
    [SerializeField]protected float Speed = 10.0f;
    protected float Damage = 0.0f;
    public abstract void OnFire(float Damage, Transform target);
}
public enum TowerType
{
    NORMAL,CANNON
}
public class GamaData 
{
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TowerData", menuName = "TowerData", order = int.MinValue + 2)]
public class TowerData : ScriptableObject
{
    [SerializeField] int[] myDamage;
    public int GetDamage(int lv) => myDamage[lv];
}

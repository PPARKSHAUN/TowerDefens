using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    #region Instance
    static ResourceManager _inst = null;
    public static ResourceManager Inst
    {
        get => _inst;
    }
    private void Awake()
    {
        _inst = this;
    }
    #endregion
    public GameObject[] TowerSources;    
}

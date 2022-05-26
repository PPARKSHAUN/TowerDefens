using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    static ResourceManager _inst = null;

    public static ResourceManager Inst
    {
        get => _inst;
    }

    public GameObject[] TowerSources;
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{

    public Transform StartPoint;
    public Transform DestPoint;

    public GameObject MonsterSource;
    public Transform MonsterGrid;
    [SerializeField]List<Monster> Monsterlist = new List<Monster>();
    // Start is called before the first frame update
    void Start()
    {
        CreateMonster();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateMonster()
    {
        Monsterlist.Add(Instantiate(MonsterSource,StartPoint.position,StartPoint.rotation, MonsterGrid).GetComponent<Monster>());
        Monsterlist[Monsterlist.Count-1].SetTarget(DestPoint);
    }
}

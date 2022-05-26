using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class TestMapManager : MonoBehaviour
{
    static TestMapManager _ins = null;
    public static TestMapManager Ins
    {
        get
        {
            if(_ins == null)
            {
                _ins = FindObjectOfType<TestMapManager>();
            }
            return _ins;
        }
    }
    public GameObject TestSource = null;
    public Transform StartPoint;
    public Transform DestPoint;
    public Transform myGrid;
    NavMeshPath myPath = null;
    // Start is called before the first frame update
    void Start()
    {
        myPath = new NavMeshPath();
    }

    // Update is called once per frame
    void Update()
    {
        
    }  

    public void CreateTestTower(Vector3 pos, UnityAction<UnityAction> Success)
    {
        StartCoroutine(CheckingPath(pos, Success));
    }
    IEnumerator CheckingPath(Vector3 pos, UnityAction<UnityAction> Success)
    {
        GameObject obj = Instantiate(TestSource, pos, Quaternion.identity, myGrid);
        yield return new WaitForSeconds(0.1f);

        NavMesh.CalculatePath(StartPoint.position, DestPoint.position, 1 << NavMesh.GetAreaFromName("TestWalkable"), myPath);
        if (myPath.status == NavMeshPathStatus.PathComplete)
        {
            Success?.Invoke(()=>Destroy(obj));
        }
        else
        {
            Destroy(obj);
        }
    }

}

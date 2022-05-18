using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
public class TestMapmanager : MonoBehaviour
{
    static TestMapmanager _ins = null;
    NavMeshPath myPath = null;
    public static TestMapmanager Ins
    {
        get
        {
            if(_ins ==null)
            {
                _ins = FindObjectOfType<TestMapmanager>();
            }
            return _ins;
        }
    }
    public Transform StartPoint;
    public Transform DestPoint;
    public Transform myGrid;
    public GameObject TestSource = null;
    // Start is called before the first frame update
    void Start()
    {
        myPath = new NavMeshPath();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CreateTestTower(Vector3 pos,UnityAction<UnityAction> Success)
    {
        StartCoroutine(CheckingPath( pos, Success));
    }
    IEnumerator CheckingPath( Vector3 pos,UnityAction<UnityAction> Success)
    {
        GameObject obj = Instantiate(TestSource, pos, Quaternion.identity,myGrid);
        yield return new WaitForSeconds(0.1f);

        NavMesh.CalculatePath(StartPoint.position, DestPoint.position, 1<<NavMesh.GetAreaFromName("testwalers"), myPath);
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


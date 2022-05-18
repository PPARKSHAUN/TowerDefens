using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Tile : MonoBehaviour
{
    public GameObject TowerSource = null;
    [SerializeField]int TileNumber = 0;
    Tower myTower = null;
    UnityAction TestTowerDestory = null;
    public void Intialize(int tileNum, Vector3 pos)
    {
        TileNumber = tileNum;
        this.transform.localPosition = pos;
    }
    // Start is called before the first frame update
   public void CreateTower()
    {
        if (myTower != null) return;
        Vector3 pos = this.transform.position;
        pos.y += 20;
        TestMapmanager.Ins.CreateTestTower(pos, (_destroy) => 
        {
            TestTowerDestory = _destroy;
            myTower = Instantiate(TowerSource, this.transform).GetComponent<Tower>();
            });
        
    }

    public void DestoryTower()
    {
        if (myTower == null) return;
        Destroy(myTower.gameObject);
        TestTowerDestory?.Invoke();
        myTower = null;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Tile : MonoBehaviour
{    
    [SerializeField] int TileNumber = 0;
    Tower myTower = null;
    UnityAction TestTowerDestroy = null;
    public void Intialize(int tileNum, Vector3 pos)
    {
        TileNumber = tileNum;
        this.transform.localPosition = pos;
    }
    
    public void CreateTower(TowerType tower)
    {
        if (myTower != null) return;
        Vector3 pos = this.transform.position;
        pos.y += 100;
        TestMapManager.Ins.CreateTestTower(pos, 
        _destroy => 
        {
            TestTowerDestroy = _destroy;
            myTower = Instantiate(ResourceManager.Inst.TowerSources[(int)tower], this.transform).GetComponent<Tower>();
        });        
    }
    /*
    void TowerDestroy(UnityAction Do)
    {
        TestTowerDestroy = Do;
        myTower = Instantiate(TowerSource, this.transform).GetComponent<Tower>();
    }
    */

    public void DestroyTower()
    {
        if (myTower == null) return;
        Destroy(myTower.gameObject);
        TestTowerDestroy?.Invoke();
        myTower = null;
    }
}

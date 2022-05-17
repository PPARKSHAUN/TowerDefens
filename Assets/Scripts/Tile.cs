using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public GameObject TowerSource = null;
    [SerializeField]int TileNumber = 0;
    Tower myTower = null;

    public void Intialize(int tileNum, Vector3 pos)
    {
        TileNumber = tileNum;
        this.transform.localPosition = pos;
    }
    // Start is called before the first frame update
   public void CreateTower()
    {
        if (myTower != null) return;
        myTower = Instantiate(TowerSource, this.transform).GetComponent<Tower>();
    }

    public void DestoryTower()
    {
        if (myTower == null) return;
        Destroy(myTower.gameObject);
        myTower = null;
    }
}

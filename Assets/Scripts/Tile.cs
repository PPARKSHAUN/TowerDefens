using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField]int TileNumber = 0;

    public void Intialize(int tileNum, Vector3 pos)
    {
        TileNumber = tileNum;
        this.transform.localPosition = pos;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

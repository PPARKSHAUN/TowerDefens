using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMain : MonoBehaviour
{
    public MapManager myMap=null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray,out RaycastHit hit,999.0f,1<<LayerMask.NameToLayer("Tile")))
            {
                myMap.CreateTower(hit.transform);
            }
        }
        if(Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, 999.0f, 1 << LayerMask.NameToLayer("Tile")))
            {
                myMap.DestroyTower(hit.transform);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    [SerializeField] GameObject TileSource = null;
    [SerializeField] Vector2 MapSize = Vector2.zero;
    [SerializeField] List<Tile> Tilelist = new List<Tile>();

    public void CreateMap()
    {
        foreach(Tile scp in Tilelist)
        {
            if(scp != null) DestroyImmediate(scp.gameObject);
        }
        Tilelist.Clear();

        this.transform.localPosition = new Vector3(-MapSize.x / 2.0f + 0.5f, 0.0f, MapSize.y / 2.0f - 0.5f);

        for (int y = 0; y < MapSize.y; y++)
        {
            for(int x = 0; x < MapSize.x; x++)
            {
                Tilelist.Add(Instantiate(TileSource, this.transform).GetComponent<Tile>());
                Tilelist[Tilelist.Count - 1].gameObject.name = $"Tile[{y}][{x}]";
                Tilelist[Tilelist.Count - 1].Intialize(Tilelist.Count - 1, new Vector3(x, 0, -y));                
            }
        }        
    }

    public void CreateTower(TowerType tower, Transform tr)
    {        
        tr.GetComponent<Tile>()?.CreateTower(tower);
    }

    public void DestroyTower(Transform tr)
    {
        tr.GetComponent<Tile>()?.DestroyTower();
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

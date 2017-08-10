using UnityEngine;
using System.Collections;

public class CreateTiles : MonoBehaviour {

    
    public GameObject dTiles;
    public GameObject tContainer;

    public int tilesAcross = 5;

    GameObject tileCreate;

    void Start () {
        createGrid();

    }

    public void createGrid()
    {
        int minValue = (tilesAcross - 1) / 2 * -1;
        int maxValue = (tilesAcross - 1) / 2;

        for (int i = minValue; i <= maxValue; i++)
        {
            for (int j = minValue; j <= maxValue; j++)
            {
                for (int k = minValue; k <= maxValue; k++)
                {
                    tileCreate = Instantiate(dTiles,
                        new Vector3(i, j, k), Quaternion.identity) as GameObject;

                    tileCreate.transform.parent = GameObject.Find("TileHolder").transform;

                }
            }
        }

        
    }
}

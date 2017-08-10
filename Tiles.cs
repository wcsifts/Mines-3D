using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;

public class Tiles : MonoBehaviour {

    public bool isBomb;
    public GameObject dTiles;
    public GameObject sphereTile;
    public Material[] defaultMat;
    public bool isFlagged;

    GameObject createSphere;
    int sphereRot = 50;
    int allBombs;

    GameObject[] removeTags;
    GameObject[] bTiles;


    // Use this for initialization
    void Start() {

        isBomb = Random.value < .15;
        
        setTag();
        SetMaterial();
        bTiles = GameObject.FindGameObjectsWithTag("Bomb");
        allBombs = bTiles.Length;
    //    Debug.Log(allBombs + " all bombs in start funtion");
    }

    void Update()
    {
        removeTags = GameObject.FindGameObjectsWithTag("rTile");
        for (int i = 0; i < removeTags.Length; i++)
        {
            Destroy(removeTags[i]);
        }
    }

    public void setFlag()
    {
        isFlagged = true;
        Renderer rend = GetComponent<Renderer>();
    }

    public void setTag()
    {

        if (isBomb)
        {
            gameObject.tag = "Bomb";
        }
        else
        {
            gameObject.tag = "Player";
        }
    }

    public void SetMaterial()
    {
        Renderer rend = GetComponent<Renderer>();
        if (isBomb)
        {
            rend.material = defaultMat[0];
        }
        else 
        {
            rend.material = defaultMat[0];
        }
    }

    public void OnMouseDown()
    {
        if (Input.GetMouseButton(0))
        {
            if (isBomb)
            {
                if (isFlagged)
                {
                }
                else
                {
                    Debug.Log("Game Over");
                    Renderer rend = GetComponent<Renderer>();
                    rend.material = defaultMat[2];
                    Application.LoadLevel(Application.loadedLevel);
                    SceneManager.LoadScene("lvl 1");
                }
            }
            else
            {
                if (isFlagged)
                {
                }
                else
                {
                    createNumber();
                    Destroy(dTiles);
                }
            }
        }
    }

    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (isFlagged == true)
            {
                Renderer rend = GetComponent<Renderer>();
                isFlagged = false;
                rend.material = defaultMat[0];
            }
            else
            {
                Renderer rend = GetComponent<Renderer>();
                isFlagged = true;
                rend.material = defaultMat[1];
            }
        }
    }

    public void createNumber()
    {
        Renderer rend = GetComponent<Renderer>();

        createSphere = Instantiate(sphereTile, transform.position, 
            transform.rotation) as GameObject;

        createSphere.transform.parent = GameObject.Find("TileHolder").transform;
    }
}



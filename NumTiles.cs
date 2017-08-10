using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class NumTiles : MonoBehaviour
{
    public bool isNum;
    public GameObject numTile;
    public Material[] numberMat;

    int bombValue;

    GameObject[] removeable;

    public List<string> emptyTag = new List<string>();
    

    // Use this for initialization
    void Start()
    {
        SetMat(bombValue);
    }


    public void setTags()
    {
        if (isNum == true)
        {
            gameObject.tag = ("numTile");
        }

        if(isNum == false)
        {
            gameObject.tag = ("rTile");
        }
    }
    
    public void SetMat(int bombValue)
    {
        Renderer rend = GetComponent<Renderer>();

        if (numTile)
        {
            rend.material = numberMat[bombValue];
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        emptyTag.Add("Sphere");

        if (emptyTag.Contains("Sphere"))
        {
            if (collider.gameObject.tag == "Bomb")
            {
                bombValue++;
                SetMat(bombValue);
               
                isNum = true;
                
            }
            SetMat(bombValue);
            
        }

        setTags();
    }
}
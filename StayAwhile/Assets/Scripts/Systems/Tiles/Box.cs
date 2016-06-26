using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;
using System;

public class Box : MonoBehaviour
{

    public TileType tileType;

    public GameObject tilePulse;
    // public GameObject tileBeat;


    Color color;
    float alpha = 0;
    float maxScale;

    void Start()
    {
        tilePulse = Instantiate(Resources.Load<GameObject>("Prefabs/Tiles/TilePulse"));
        //tileBeat = Instantiate(Resources.Load<GameObject>("Prefabs/Tiles/TileBeat"));

        tilePulse.transform.parent = gameObject.transform;
      //  tileBeat.transform.parent = gameObject.transform;

        tilePulse.transform.localPosition = Vector3.zero;
        tilePulse.transform.localScale = Vector3.one;
      //  tileBeat.transform.localPosition = Vector3.zero;

        tilePulse.GetComponent<TilePulse>().tileType = tileType;
        //  tileBeat.GetComponent<TileBeat>().tileType = tileType;

        //   GetComponent<Renderer>().material.SetColor("_Color", TileFunc.toColor(tileType));

        maxScale = transform.localScale.y;
        transform.localScale = new Vector3(transform.localScale.x, maxScale * alpha, transform.localScale.z);
        

        color = TileFunc.toColor(tileType);
        color.a = 0;

    }

    public void OnDrawGizmos()
    {
        if (gameObject)
            if (GetComponent<Renderer>())
                if (GetComponent<Renderer>())
                {
                    //   GetComponent<Renderer>().material.SetColor("_Color", TileFunc.toColor(tileType));
                }
    }

    void Update()
    {
        Debug.Log(alpha);
        
        alpha += Time.deltaTime * 0.04f;
        if (alpha > 1.0f)
        {
            alpha = 1.0f;
        }

        transform.localScale = new Vector3(transform.localScale.x, maxScale * alpha, transform.localScale.z);


        color.a = alpha;

        GetComponent<Renderer>().material.SetColor("_Color", color);
    }
}

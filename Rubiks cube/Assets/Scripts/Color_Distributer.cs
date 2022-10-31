using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum ColorName
{
    Red,
    Green,
    Blue,
    Yellow,
    White
}


public class Color_Distributer : MonoBehaviour
{


    public ColorName colorName;
    public Color colorToImpact;
    public LayerMask layer;
   

    Vector3 scale = new Vector3(1.5f, 1, 1);

    [SerializeField]
    public RaycastHit[] hit_Info;
    public float m_MaxDistance =3;

    // Start is called before the first frame update
    void Start()
    {
        Change_Color();

    }

   
    void Change_Color()
    {
       

        hit_Info = Physics.BoxCastAll(transform.position, scale, transform.forward, Quaternion.identity, m_MaxDistance, layer);

        for (int i = 0; i < hit_Info.Length; i++)
        {
            hit_Info[i].collider.GetComponent<Renderer>().material.color = colorToImpact;

        }

    }

    private void Update()
    {

        //hit_Info = Physics.BoxCastAll(transform.position, scale, transform.forward, Quaternion.identity, m_MaxDistance, layer);

        //for (int i = 0; i < hit_Info.Length; i++)
        //{
        //    hit_Info[i].collider.GetComponent<Renderer>().material.color = colorToImpact;

        //}
    }
}

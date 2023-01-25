using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Hover : MonoBehaviour
{
    public GameObject HoverEffect;
    public void OnMouseEnter()
    {
        var trs = GetComponent<Transform>();
        Debug.Log(trs.position.x);
        Debug.Log(trs.position.y);
        Debug.Log(trs.position.z);

    }
    public void OnMouseExit()
    {


    }

}

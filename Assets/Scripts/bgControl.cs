using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgControl : MonoBehaviour
{
    public float width=27f;
    public float speed=8;

    public bool isHose;
    public float upPoint, downPoint;
    public List<Object> hostList = new List<Object>();

    private void Start()
    {
        if(isHose)
        {
            foreach(Transform trans in transform)
            {
                hostList.Add(trans);
            }
            HoseRefresh(hostList);
        }

    }
    void Update()
    {
        foreach (Transform trans in transform)
            {
                Vector3 v = trans.position;
                v.x -= speed * Time.deltaTime;

                if (isHose)
                {
                    if (v.x < (-width * 4))
                    {
                        v.x += width * 4;
                        float y;
                        y = Random.Range(downPoint, upPoint);
                        v.y = y;
                    }
                }
                else if (v.x < -width)
                {
                    v.x += width * 2;
                }
                trans.position = v;
            }
    }

    void HoseRefresh(List<Object> list)
    {
        foreach(Transform trans in transform)
        {
            trans.position = new Vector3(trans.position.x, Random.Range(downPoint, upPoint),trans.position.z);
        }
    }
}

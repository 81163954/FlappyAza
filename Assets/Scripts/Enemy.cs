using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed=8;
    public float updownSpeed=4;
    public float upPoint, downPoint;
    public float destroySelfSecond=15;
    bool fangxiangUp;
    public bool isItem;
    // Start is called before the first frame update
    void Start()
    {
        float y;
        y=Random.Range(0f, 2f);
        if (y>0&&y<1)
        {
            fangxiangUp = true;
        }

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
            if (fangxiangUp)
            {
                transform.Translate(Vector3.up * updownSpeed * Time.deltaTime);
                if (transform.position.y > upPoint)
                {
                    fangxiangUp = false;
                }
            }
            else
            {
                transform.Translate(Vector3.down * updownSpeed * Time.deltaTime);
                if (transform.position.y < downPoint)
                {
                    fangxiangUp = true;
                }
            }
            
    }
}

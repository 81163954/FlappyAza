using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetEnemySpeed : MonoBehaviour
{
    public void SetSpeed()
    {
        foreach (Transform trans in transform)
        {
            trans.GetComponent<Enemy>().speed = 0;
        }
    }
}

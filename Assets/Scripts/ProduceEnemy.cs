using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProduceEnemy : MonoBehaviour
{
    public GameObject producePoint;
    public GameObject enemyPrefab;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("hose"))
        {
            Instantiate(enemyPrefab, producePoint.transform.position, transform.rotation);
        }
    }
}

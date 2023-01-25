using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerExample : MonoBehaviour
{
    public static TimerExample _instance;
    private void Awake()
    {
        _instance = this;
    }
    //IEnumerator SaySomeThings()
    //{
    //    Debug.Log("The routine has started");
    //    yield return StartCoroutine(Wait(1.0f));
    //    Debug.Log("1 second has passed since the last message");
    //    yield return StartCoroutine(Wait(2.5f));
    //    Debug.Log("2.5 seconds have passed since the last message");
    //}
    IEnumerator Wait(float duration)
    {
        for (float timer = 0; timer < duration; timer += Time.deltaTime)
            yield return 0;
    }
}

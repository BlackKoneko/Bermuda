using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastKey : MonoBehaviour
{
    public int effectEnd;
    int time;
    IEnumerator Time()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            time++;
        }
        yield return null;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Time());

    }

    // Update is called once per frame
    void Update()
    {
        if (time > effectEnd)
        {
            Destroy(gameObject);
        }
    }
}

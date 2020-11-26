using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objects : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;

    public GameObject[] randomObject;
    public Vector3 spawnValues;
    public float spawnWait;
    public float spawnMostWait;
    public float spawnLeastWait;
    public int startWait;

    int objectsRandom;

    public GameObject[] randomItem;
    public Vector3 spawnValues2;
    public float spawnWait2;
    public float spawnMostWait2;
    public float spawnLeastWait2;
    public int startWait2;

    int objectsRandom2;
    public void Activate()
    {
        StartCoroutine(waitFirst());
        StartCoroutine(waitFirst2());
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        spawnWait = Random.Range(spawnLeastWait, spawnMostWait);
        spawnWait2 = Random.Range(spawnLeastWait2, spawnMostWait2);
    }

    IEnumerator waitFirst()
    {
        yield return new WaitForSeconds(startWait);

        while (true)
        {
            objectsRandom = Random.Range(0, 3);
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), Random.Range(-spawnValues.y, spawnValues.y), Random.Range(-spawnValues.z, spawnValues.z));

            Instantiate(randomObject[objectsRandom], spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);

            yield return new WaitForSeconds(spawnWait);
        }

    }

    IEnumerator waitFirst2()
    {
        yield return new WaitForSeconds(startWait2);

        while (true)
        {
            objectsRandom2 = Random.Range(0, 2);
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), Random.Range(-spawnValues.y, spawnValues.y), Random.Range(-spawnValues.z, spawnValues.z));

            Instantiate(randomItem[objectsRandom2], spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);

            yield return new WaitForSeconds(spawnWait2);
        }

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tunnel : MonoBehaviour
{
    public Camera mainCamera;

    public Transform startPoint;
    public Objects tunnelPrefab;
    public int tunnelPreSpawn = 5;
    public int tunnelNoObstacle = 3;

    public List<Objects> spawnedTunnels = new List<Objects>();
    public int NextTunnel = -1;

    public static Tunnel instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        Vector3 spawnPosition = startPoint.position;
        int tunnelNoObstacles = tunnelNoObstacle;
        for (int i = 0; i < tunnelPreSpawn; i++)
        {
            spawnPosition -= tunnelPrefab.startPoint.localPosition;
            Objects spawnedTunnel = Instantiate(tunnelPrefab, spawnPosition, Quaternion.identity) as Objects;
            if (tunnelNoObstacles > 0)
            {

                tunnelNoObstacles--;
            }
            else
            {
                spawnedTunnel.Activate();
            }

            spawnPosition = spawnedTunnel.endPoint.position;
            spawnedTunnel.transform.SetParent(transform);
            spawnedTunnels.Add(spawnedTunnel);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (mainCamera.WorldToViewportPoint(spawnedTunnels[0].endPoint.position).z < 0)
        {
            Objects tunnelOne = spawnedTunnels[0];
            spawnedTunnels.RemoveAt(0);
            tunnelOne.transform.position = spawnedTunnels[spawnedTunnels.Count - 1].endPoint.position -
                tunnelOne.startPoint.localPosition;
            tunnelOne.Activate();
            spawnedTunnels.Add(tunnelOne);
        }
    }
}

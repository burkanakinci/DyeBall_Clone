using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerate : MonoBehaviour
{
    private static MapGenerate instance = null;

    [SerializeField] private GameObject ball;
    [SerializeField] private List<GameObject> ballPool = new List<GameObject>();
    [SerializeField] private GameObject wall;
    [SerializeField] private List<GameObject> wallPool = new List<GameObject>();
    [SerializeField] private GameObject body;
    [SerializeField] private List<GameObject> bodyPool = new List<GameObject>();
    public static MapGenerate Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("MapGenerate").AddComponent<MapGenerate>();
            }
            return instance;
        }
    }
    void Start()
    {
        instance = this;

    }

    public void SpawnBall(Vector3 _spawnPos)
    {
        if (ballPool.Count == 0)
        {
            Instantiate(ball, _spawnPos, Quaternion.identity);
        }
        else
        {

        }
    }
}

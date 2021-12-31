using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public MeshRenderer ballMesh;
    [SerializeField] Color[] ballColors;

    private void Start()
    {
        ballMesh = GetComponent<MeshRenderer>();

        ballMesh.material.color = ballColors[Random.Range(0, ballColors.Length)];
    }
}

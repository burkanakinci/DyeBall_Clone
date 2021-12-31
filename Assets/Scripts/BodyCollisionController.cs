using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyCollisionController : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer bodyMesh;
    private bool isColored;
    private void Start()
    {
        isColored = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TakedBall") && !isColored)
        {
            bodyMesh.material.color = other.GetComponent<BallController>().ballMesh.material.color;
            isColored = true;
        }
    }
}

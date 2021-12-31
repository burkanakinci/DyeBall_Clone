using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollisionController : MonoBehaviour
{
    private BallMovement ballMovement;
    [SerializeField] private bool isThrow;
    private int takedIndex;
    [SerializeField] private Vector3 target;
    [SerializeField] private float throwLerp;
    private Rigidbody rbBall;
    private void Start()
    {
        ballMovement = FindObjectOfType<BallMovement>();
        rbBall = GetComponent<Rigidbody>();

        throwLerp = 5f;

        takedIndex = -1;

        isThrow = false;

        gameObject.tag = "TakeableBall";
    }
    private void Update()
    {
        if ((!isThrow || gameObject.tag == "TakeableBall") && rbBall.velocity != Vector3.zero)
        {
            rbBall.velocity = Vector3.zero;
        }
    }
    private void FixedUpdate()
    {
        if (isThrow)
        {
            transform.position = Vector3.Lerp(transform.position, target, throwLerp * Time.fixedDeltaTime);
            if (Vector3.Distance(transform.position, target) < 2f)
            {


                isThrow = false;
            }
        }

    }
    private void OnCollisionEnter(Collision other)
    {
        if ((other.collider.CompareTag("TakedBall") || other.collider.CompareTag("Player")) && gameObject.tag == "TakeableBall" && !isThrow)
        {
            gameObject.tag = "TakedBall";

            ballMovement.takedBalls.Add(this);
            takedIndex = ballMovement.takedBalls.Count - 1;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall") && gameObject.tag == "TakedBall")
        {
            ballMovement.BallBreak(takedIndex);
        }
    }

    public void ThrowByWall()
    {
        gameObject.tag = "TakeableBall";

        target = new Vector3(Random.Range(-7f, 7f), transform.position.y, transform.position.z + Random.Range(15f, 50f));

        isThrow = true;
    }
}

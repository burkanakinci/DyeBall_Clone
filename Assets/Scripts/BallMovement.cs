using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private Transform ballMoveParent;
    public List<BallCollisionController> takedBalls = new List<BallCollisionController>();
    public float ballMoveLerp = 7f;

    private void FixedUpdate()
    {
        BallMove();
    }
    private void BallMove()
    {
        if (takedBalls.Count > 0)
        {
            takedBalls[0].transform.position = Vector3.Lerp(takedBalls[0].transform.position, ballMoveParent.position, ballMoveLerp * Time.fixedDeltaTime);
            for (int i = 1; i < takedBalls.Count; i++)
            {
                takedBalls[i].transform.position = Vector3.Lerp(takedBalls[i].transform.position, new Vector3(takedBalls[i - 1].transform.position.x, takedBalls[i - 1].transform.position.y, takedBalls[i - 1].transform.position.z + 2.5f), ballMoveLerp * Time.fixedDeltaTime);
            }
        }
    }
    public void BallBreak(int _breakedİndex)
    {
        for (int j = _breakedİndex; j < takedBalls.Count; j++)
        {
            takedBalls[j].ThrowByWall();
            takedBalls.Remove(takedBalls[j]);
        }
    }
}

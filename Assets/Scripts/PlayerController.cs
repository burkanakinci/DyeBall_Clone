using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public enum GameState
    {
        PreRun,
        Run,
        Throw,
        Finish
    }
    public float moveSpeed = 4f;
    public float xMoveLerp = 2f;
    private float difXPos, firstXPos, newXPos, xClamp;
    [SerializeField] private Transform moveParent;
    private BallMovement ballMovement;
    private void Start()
    {
        ballMovement = GetComponent<BallMovement>();

        xClamp = 7f;
    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            firstXPos = Camera.main.ScreenToViewportPoint(Input.mousePosition).x;
        }
        if (Input.GetMouseButton(0))
        {
            Scrolling();
        }
    }
    private void FixedUpdate()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        if (moveParent.transform.position.z < 381f)
        {
            moveParent.position = new Vector3(moveParent.position.x, moveParent.position.y, moveParent.position.z + moveSpeed * Time.fixedDeltaTime);
        }
        if (transform.position.z > 350f ||
            (ballMovement.takedBalls.Count > 0 && ballMovement.takedBalls[ballMovement.takedBalls.Count - 1].transform.position.z > 350f))
        {
            xClamp = 0f;
        }
        transform.localPosition = Vector3.Lerp(transform.localPosition,
                                            new Vector3(Mathf.Clamp(newXPos, -1 * xClamp, xClamp),
                                                        transform.localPosition.y,
                                                        transform.localPosition.z),
                                                xMoveLerp * Time.fixedDeltaTime);
    }
    private void Scrolling()
    {

        difXPos = (Camera.main.ScreenToViewportPoint(Input.mousePosition).x - firstXPos) * 10f;
        newXPos += difXPos;
        difXPos = 0f;
        firstXPos = Camera.main.ScreenToViewportPoint(Input.mousePosition).x;

    }

}

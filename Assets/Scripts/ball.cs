using System.Diagnostics.Tracing;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;
public class ball : MonoBehaviour
{
    [SerializeField] private GameObject paddleGameObject;
    [SerializeField] private GameObject ballGameObject;
    [SerializeField] private GameObject leftSidePaddle;
    [SerializeField] private GameObject rightSidePaddle;
    [SerializeField] private GameObject ballPrefab;
    private Vector2 positionLeftGameObject;
    private Vector2 positionRightGameObject;
    private bool isBallStick = true;
    private bool isBallRun = false;
    private float angleY;
    private float angleX;

    private Rigidbody2D rb;
    public float speed = 50f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        positionLeftGameObject = Vector2.zero;
        positionRightGameObject = Vector2.zero;
    }

    void Update()
    {
        MoveBall();
        
    }

    private void MoveBall()
    {
        if (isBallStick)
        {
            Vector2 positionPaddle = paddleGameObject.transform.position;
            Vector2 positionBall = new Vector2(positionPaddle.x, positionPaddle.y + 0.30f);
            ballGameObject.transform.position = positionBall;
        }

        if (isBallStick && Input.GetKeyDown(KeyCode.Space))
        {
            float randomDirectionY = Random.Range(1f, 1f);
            float randomDirectionX = Random.Range(-1.25f, 1.25f);
            Vector2 startDirection = new Vector2(randomDirectionX, randomDirectionY);
            Debug.Log(startDirection);
            rb.linearVelocity = startDirection.normalized * speed;
            isBallStick = false;
            isBallRun = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collison2D)
    {
        if (collison2D.gameObject.CompareTag("Paddle")) {
            FixMovementBall();   
        }
    }
    private void FixMovementBall()
    {
        if (isBallRun)
        {
            Vector2 ballPosition = ballPrefab.transform.position;
            positionLeftGameObject = new Vector2(leftSidePaddle.transform.position.x, leftSidePaddle.transform.position.y);
            positionRightGameObject = new Vector2(rightSidePaddle.transform.position.x, rightSidePaddle.transform.position.y);
            Vector2 result = positionRightGameObject + positionLeftGameObject;
            angleY = Random.Range(1.25f, 2f);
            angleX = Random.Range(-1.25f, 1.25f);
            Vector2 direction = new Vector2(angleX, angleY);

            if (ballPosition.x > (result.x / 2))
            {
                rb.linearVelocity = direction.normalized * speed;
            }
            else
            {
                rb.linearVelocity = direction.normalized * speed;
            }
        }
        //isBallRun = false;
    }
}
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
    private float maxBounceAngle = 75f;
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
        PlayerMovement playerMovement = collison2D.gameObject.GetComponent<PlayerMovement>();
        if (playerMovement != null)
        {
            Debug.Log("Zdezenie z komponentem Paddle");
            Vector3 paddlePosition = this.transform.position;
            Vector2 concactPoint = collison2D.GetContact(0).point;
            float offset = paddlePosition.x - concactPoint.x;
            float width = collison2D.otherCollider.bounds.size.x / 2;
            float currentAngle = Vector2.SignedAngle(Vector2.up, rb.linearVelocity);
            float bounceAngle = (offset / width) * maxBounceAngle;
            float newAngle = Mathf.Clamp(currentAngle + bounceAngle, -maxBounceAngle, maxBounceAngle);

            Quaternion rotation = Quaternion.AngleAxis(newAngle, Vector3.forward);
            rb.linearVelocity = rotation * Vector2.up * rb.linearVelocity.magnitude;
        }
    }
}
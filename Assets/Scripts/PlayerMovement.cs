using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] AudioClip soundPaddle;
    public float speed = 10f;
    private Vector2 leftPaddle = Vector2.left;
    private Vector2 rightPaddle = Vector2.right;
    private float minX = -5.65f;
    private float maxX = 5.22f;
    void Update()
    {
        float moveX;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(leftPaddle * speed * Time.deltaTime);
            moveX = Mathf.Clamp(transform.position.x, minX, maxX);
            transform.position = new Vector2(moveX, transform.position.y);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(rightPaddle * speed * Time.deltaTime);
            moveX = Mathf.Clamp(transform.position.x, minX, maxX);
            transform.position = new Vector2(moveX, transform.position.y);
        }
    }
    public void OnCollisionEnter2D(Collision2D collison2D)
    {
        if (gameObject.tag == "Paddle")
        {
            PlaySoundWhenBallTouchPaddle();
        }
    }
    void PlaySoundWhenBallTouchPaddle()
    {
        SoundManager.instance.PlaySound(soundPaddle, transform, 1f);
    }
}

using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private bool isFacingRight = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Horizontal movement
        float moveX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);

        // Flip character
        if (moveX < 0 && isFacingRight)
        {
            Flip();
        }
        else if (moveX > 0 && !isFacingRight)
        {
            Flip();
        }

        // Vertical movement
        float moveY = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(rb.velocity.x, moveY * moveSpeed);
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}

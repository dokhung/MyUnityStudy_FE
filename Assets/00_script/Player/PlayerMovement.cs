using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("이동 설정")]
    [SerializeField] private float moveSpeed = 5f;

    [Header("점프 설정")]
    [SerializeField] private float jumpForce = 7f;

    private Rigidbody2D rb;
    private float horizontal;
    private bool jumpRequested;
    private bool isJump = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        // 점프 중이 아닐 때만 점프 가능
        if (Input.GetKeyDown(KeyCode.Space) && !isJump)
        {
            jumpRequested = true;
            isJump = true;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);

        if (jumpRequested)
        {
            rb.AddForce(
                Vector2.up * jumpForce,
                ForceMode2D.Impulse
            );

            jumpRequested = false;
        }
    }

    // 바닥에 착지하면 점프 상태 해제
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJump = false;
        }
    }
}
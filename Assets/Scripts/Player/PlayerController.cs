using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Variables

    [SerializeField] private InputReader inputReader;

    [SerializeField] private float speed = 5;
    [SerializeField] private float jumpSpeed = 5;

    private Vector2 moveDirection;

    private bool isJumping;

    #endregion


    #region Unity Event Functions

    private void Start()
    {
        inputReader.MoveEvent += HandleMove;

        inputReader.JumpEvent += HandleJump;
        inputReader.JumpCancelledEvent += HandleCancelledJump;
    }

    private void Update()
    {
        Move();
        Jump();
    }

    #endregion

    #region Handles

    #region Handle Move

    private void HandleMove(Vector2 direction)
    {
        moveDirection = direction;
    }

    #endregion

    #region Handle Jump

    private void HandleJump()
    {
        isJumping = true;
    }

    #endregion

    #region Handle Cancelled Jump

    private void HandleCancelledJump()
    {
        isJumping = false;
    }

    #endregion

    #endregion

    #region Move

    private void Move()
    {
        if (moveDirection == Vector2.zero) return;

        transform.position += new Vector3(moveDirection.x, 0, moveDirection.y) * (speed * Time.deltaTime);
    }

    #endregion

    #region Jump

    private void Jump()
    {
        if (isJumping) transform.position += Vector3.up * (jumpSpeed * Time.deltaTime);
    }

    #endregion
}

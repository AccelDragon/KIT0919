using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public float gravity = -9.81f;

    private Vector3 velocity; // 중력 적용을 위한 변수
    private CharacterController characterController;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        if (characterController == null)
        {
            Debug.LogError("CharacterController 컴포넌트가 없습니다.");
            this.enabled = false; // 스크립트 비활성화
            return;
        }
    }

    private void Update()
    {
        MoveCharacter();
    }

    void MoveCharacter()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(moveX, 0, moveZ);
        Vector3 moveDirection = move.normalized * speed;

        if (characterController.isGrounded && velocity.y < 0)
        {
            velocity.y = 0f;  // 지면에 있을 경우 Y의 속도를 0으로 초기화
        }

        // 중력 적용
        velocity.y += gravity * Time.deltaTime;

        characterController.Move(moveDirection * Time.deltaTime + velocity * Time.deltaTime);
    }
}

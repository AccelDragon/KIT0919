using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // 팔로우 대상 (예: 플레이어)
    public Vector3 offset; // 대상과 카메라 사이의 거리
    public float smoothSpeed = 0.125f; // 움직임을 부드럽게 하기 위한 변수

    private void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}

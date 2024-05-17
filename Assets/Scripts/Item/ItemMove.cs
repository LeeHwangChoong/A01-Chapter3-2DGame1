using UnityEngine;

public class ItemMove : MonoBehaviour
{
    //아이템이 처음 등장할때 랜덤한 방향으로 이동
    //벽과 부딪히면 튕겨져 나가게하기(당구처럼)
    private float itemSpeed = 3f;
    private Vector2 moveDirection;

    private void Start()
    {
        // 랜덤 이동 방향 설정
        float randomAngle = Random.Range(20f, 340f);
        moveDirection = Quaternion.Euler(0f, 0f, randomAngle) * Vector2.right;
    }

    private void Update()
    {
        // 아이템 이동
        transform.Translate(moveDirection * itemSpeed * Time.deltaTime, Space.World);

        CheckScreenBoundary();
    }

    private void CheckScreenBoundary()
    {
        Vector2 position = transform.position;
        //현재 위치
        Vector2 viewportPosition = Camera.main.WorldToViewportPoint(position); 
        // 월드좌표를 기준으로 뷰포트 좌표로 변환 

        if (viewportPosition.x <= 0 || viewportPosition.x >= 1)
        {
            // 화면 좌우 경계에 닿았을 때
            moveDirection.x *= -1; // x값 반전
        }

        if (viewportPosition.y <= 0 || viewportPosition.y >= 1)
        {
            // 화면 상하 경계에 닿았을 때
            moveDirection.y *= -1; // y값 반전
        }
    }
}
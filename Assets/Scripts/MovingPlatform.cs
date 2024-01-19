using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform[] movementPoints;
    public float movementSpeed = 2f;

    private int targetPointIndex = 0;

    void Update()
    {
        MovePlatform();
    }

    void MovePlatform()
    {
        if (movementPoints.Length == 0)
            return;

        Transform targetPoint = movementPoints[targetPointIndex];
        transform.position = Vector2.MoveTowards(transform.position, targetPoint.position, movementSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, targetPoint.position) < 0.1f)
        {
            targetPointIndex = (targetPointIndex + 1) % movementPoints.Length;
        }
    }
}
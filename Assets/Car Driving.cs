using UnityEngine;

public class MoveLeftRight : MonoBehaviour
{
    public float moveSpeed = 5f;          // Speed of the car
    public float moveDistance = 10f;      // Total distance the car moves before turning

    private Vector3 startPos;
    private bool movingForward = true;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // Move the car forward (local Z-axis)
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        float traveled = Vector3.Distance(startPos, transform.position);

        if (traveled >= moveDistance)
        {
            // Turn around 180 degrees
            transform.Rotate(0f, 180f, 0f);
            movingForward = !movingForward;

            // Reset starting point to measure the new segment
            startPos = transform.position;
        }
    }
}

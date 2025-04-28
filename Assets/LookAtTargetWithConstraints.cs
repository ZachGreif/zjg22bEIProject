using UnityEngine;

public class LookAtTargetWithConstraints : MonoBehaviour
{
    [SerializeField] private Transform target;

    // XZ movement constraint box
    public float minX = -58f;
    public float maxX = -2f;
    public float minZ = -60f;
    public float maxZ = 30f;

    // Z-axis dead zone range
    public float deadZoneMinZ = -8f;
    public float deadZoneMaxZ = 8f;

    void Update()
    {
        if (target == null) return;

        Vector3 targetPos = target.position;

        bool insideXZBox = targetPos.x >= minX && targetPos.x <= maxX &&
                           targetPos.z >= minZ && targetPos.z <= maxZ;

        bool outsideZDeadZone = targetPos.z <= deadZoneMinZ || targetPos.z >= deadZoneMaxZ;

        // Only rotate if both XZ constraint is satisfied AND Z isn't in dead zone
        if (insideXZBox && outsideZDeadZone)
        {
            Vector3 direction = targetPos - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 2f);
        }
    }
}

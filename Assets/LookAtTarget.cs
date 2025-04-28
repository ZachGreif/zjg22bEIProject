using UnityEngine;

public class LookAtTarget : MonoBehaviour
{
    [SerializeField] private Transform target; // Drag your target object here in the Inspector

    void Update()
    {
        if (target != null)
        {
            transform.LookAt(target);
        }
    }
}

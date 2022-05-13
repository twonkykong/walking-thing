using UnityEngine;

public class FeetFollowingOffsetSettings : MonoBehaviour
{
    [SerializeField] private FeetFollowing cameraFeetFollowing;

    [SerializeField] private float raycastDistance = 1f;
    [SerializeField] private float headOffsetValue = 0.3f;
    [SerializeField] private float cameraOffsetValue = 2f;
    [SerializeField] private float capsuleRaycastRadius = 1f;

    private FeetFollowing _thisObjectFeetFollowing = null;

    private Transform _thisObjectTransform = null;

    private int _layermask = 0;

    private void Awake()
    {
        _thisObjectFeetFollowing = GetComponent<FeetFollowing>();
        _thisObjectTransform = transform;

        _layermask = ~LayerMask.GetMask("ignore");
    }

    private bool RaycastCheck(Vector3 direction)
    {
        return Physics.Raycast(_thisObjectTransform.position, direction, raycastDistance, _layermask);
    }

    private Vector3 CalculateOffset()
    {
        Vector3 offset = Vector3.zero;

        //holy nightmare
        if (RaycastCheck(-_thisObjectTransform.right)) offset += Vector3.right;
        if (RaycastCheck(_thisObjectTransform.right)) offset -= Vector3.right;

        if (RaycastCheck(-_thisObjectTransform.forward)) offset += Vector3.forward;
        if (RaycastCheck(_thisObjectTransform.forward)) offset -= Vector3.forward;

        return offset;
    }

    private void Update()
    {
        Vector3 newOffset = CalculateOffset();

        _thisObjectFeetFollowing.SetOffset(newOffset * headOffsetValue);
        cameraFeetFollowing.SetOffset(newOffset * cameraOffsetValue);
    }
}

using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] private Transform receiverTeleport;

    private Transform _thisObjectTransform = null;

    private void Awake()
    {
        _thisObjectTransform = transform;
    }

    public void Work()
    {
        Vector3 previousPosition = _thisObjectTransform.position;
        Quaternion previousRotation = _thisObjectTransform.rotation;

        _thisObjectTransform.position = receiverTeleport.position;
        _thisObjectTransform.rotation = receiverTeleport.rotation;

        receiverTeleport.position = previousPosition;
        receiverTeleport.rotation = previousRotation;
    }
}

using UnityEngine;

public class FootFollowing : MonoBehaviour
{
    [SerializeField] private Transform firstLeg = null, secondLeg = null;
    [SerializeField] private float slerpTime = 0.7f;
    [SerializeField] private Vector3 offset = Vector3.zero;

    private Transform _thisObjectTransform;

    private void Awake()
    {
        _thisObjectTransform = transform;
    }

    private void Update()
    {
        Vector3 midPoint = (firstLeg.position + secondLeg.position) / 2;
        Vector3 finalPoint = midPoint + Vector3.up + offset;

        _thisObjectTransform.position = Vector3.Slerp(_thisObjectTransform.position, finalPoint, slerpTime);
    }
}

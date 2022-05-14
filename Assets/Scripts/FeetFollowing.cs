using UnityEngine;

public class FeetFollowing : MonoBehaviour
{
    [SerializeField] private Transform firstFoot;
    [SerializeField] private Transform secondFoot;

    [SerializeField] private Vector3 mainOffset;

    [SerializeField] private float slerpTime = 0.7f;

    private Transform _thisObjectTransform = null;
    
    private Vector3 _additionalOffset = Vector3.zero;

    private void Awake()
    {
        _thisObjectTransform = transform;
    }

    private void Update()
    {
        Vector3 midPoint = (firstFoot.position + secondFoot.position) / 2;
        Vector3 finalPoint = midPoint + mainOffset + _additionalOffset;

        _thisObjectTransform.localPosition = Vector3.Lerp(_thisObjectTransform.position, finalPoint, slerpTime);
    }

    public void SetOffset(Vector3 newOffset)
    {
        _additionalOffset = newOffset;
    }
}

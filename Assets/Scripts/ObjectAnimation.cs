using UnityEngine;
using DG.Tweening;

public class ObjectAnimation : MonoBehaviour
{
    [SerializeField] private Ease easeType;
    [SerializeField] private LoopType loopType;

    [SerializeField] private Vector3 rotationAxis;
    [SerializeField] private Vector3 motionAxis;

    [SerializeField] private float rotationDuration = 10f;
    [SerializeField] private float motionDuration = 10f;

    private void Awake()
    {
        if (rotationAxis != Vector3.zero) transform.DORotate(rotationAxis, rotationDuration, RotateMode.WorldAxisAdd).SetEase(easeType).SetLoops(-1, loopType);
        if (motionAxis != Vector3.zero) transform.DOMove(transform.position + motionAxis, motionDuration).SetEase(easeType).SetLoops(-1, loopType);
    }
}

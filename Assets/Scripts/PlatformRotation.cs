using UnityEngine;
using DG.Tweening;

public class PlatformRotation : MonoBehaviour
{
    [SerializeField] private Vector3 rotationAxis;
    [SerializeField] private float rotationDuration = 10f;

    private void Awake()
    {
        transform.DORotate(rotationAxis, rotationDuration, RotateMode.WorldAxisAdd).SetEase(Ease.Linear).SetLoops(-1, LoopType.Restart);
    }
}

using UnityEngine;
using DG.Tweening;

public class HeadAnimation : MonoBehaviour
{
    [SerializeField] private Transform ring;
    [SerializeField] private float rotationDuration = 0.1f;

    private void Start()
    {
        Vector3 rotation = Vector3.one * 360;
        ring.DORotate(rotation, rotationDuration, RotateMode.LocalAxisAdd).SetEase(Ease.Linear).SetLoops(-1, LoopType.Restart);
    }
}

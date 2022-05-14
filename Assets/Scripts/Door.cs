using UnityEngine;
using DG.Tweening;

public class Door : MonoBehaviour
{
    [SerializeField] private Vector3 rotationValues;
    [SerializeField] private Vector3 motionValues;

    [SerializeField] private float rotationDuration = 0.2f;
    [SerializeField] private float motionDuration = 0.2f;

    public void Open()
    {
        if (motionValues != Vector3.zero) transform.DOMove(transform.position + motionValues, motionDuration).SetEase(Ease.OutSine);
        if (rotationValues != Vector3.zero) transform.DORotate(rotationValues, rotationDuration, RotateMode.WorldAxisAdd).SetEase(Ease.OutSine);

        Destroy(this);
    }
}

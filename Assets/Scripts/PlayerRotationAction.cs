using UnityEngine;
using DG.Tweening;

public class PlayerRotationAction : MonoBehaviour
{
    [SerializeField] private Vector3 rotationValues = new Vector3(0f, 180f, 0f);
    [SerializeField] private float rotationDuration = 0.5f;

    private Transform _cameraHandler = null;

    private void Start() 
    { 
        _cameraHandler = Camera.main.transform.parent.parent; //damn
    }

    public void RotatePlayer()
    {
        _cameraHandler.DORotate(rotationValues, rotationDuration).SetEase(Ease.InOutSine);
    }
}

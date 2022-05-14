using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform _leftFoot;
    [SerializeField] private Transform _rightFoot;

    public Transform GetLeftFoot()
    {
        return _leftFoot;
    }

    public Transform GetRightFoot()
    {
        return _rightFoot;
    }
}

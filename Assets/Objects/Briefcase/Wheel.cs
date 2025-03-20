using System;
using System.Collections;
using UnityEngine;
using Varwin;
using Varwin.Public;

public class Wheel : MonoBehaviour, IUseStartInteractionAware
{
    public Action NumberStartChanging;
    public Action<int, int> NumberWasChanged;

    [Header("Properties")]
    [SerializeField] private int _position;
    [Space]
    [SerializeField] private float _rotationDuration = .3f;
    [SerializeField] private float _rotationAngle = 36f;

    private int _currentNumber = 0;
    private float currentRotationAngle = 0;
    private bool _blockInut;

    public void OnUseStart(UseInteractionContext context)
    {
        if (!_blockInut)
        {
            NumberStartChanging?.Invoke();
            _blockInut = true;

            float targetRotationAngle = (currentRotationAngle + _rotationAngle) % 360;

            transform.localEulerAngles = new(targetRotationAngle, 0, 180);
            currentRotationAngle = targetRotationAngle;

            _currentNumber = (_currentNumber + 1) % 10;
            _blockInut = false;
            NumberWasChanged?.Invoke(_position, _currentNumber);
        }
    }
}

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
    private float currentRotationAngle = -180f;
    private bool _blockInut;

    public void OnUseStart(UseInteractionContext context)
    {
        if (!_blockInut)
            StartCoroutine(Rotate());
    }

    private IEnumerator Rotate()
    {
        NumberStartChanging?.Invoke();
        _blockInut = true;

        // Убедимся, что вращение только в одну сторону  
        float targetRotationAngle = (currentRotationAngle + _rotationAngle) % 360;

        Vector3 targetEulerAngles = new(targetRotationAngle, 0, 180);

        yield return null;

        transform.eulerAngles = targetEulerAngles;
        currentRotationAngle = targetRotationAngle;

        _currentNumber++;
        _blockInut = false;
        NumberWasChanged?.Invoke(_position, _currentNumber);
    }
    private float AngleDifference(float a, float b) => (a - b + 540) % 360 - 180;
}

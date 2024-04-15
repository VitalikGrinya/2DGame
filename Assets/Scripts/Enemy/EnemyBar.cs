using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class EnemyBar : MonoBehaviour
{
    [SerializeField] private EnemyHealth _health;
    [SerializeField] private HealthChanger _valueChanger;
    [SerializeField] private float _value;
    [SerializeField] private float _interpolationValue;

    private Slider _bar;
    private Quaternion _startRotation;
    private Coroutine _coroutine;

    private void Awake()
    {
        _bar = GetComponent<Slider>();
        _startRotation = transform.rotation;
    }

    private void Start()
    {
        SetSliderValue();
    }

    private void LateUpdate()
    {
        transform.rotation = _startRotation;
    }

    private void OnEnable()
    {
        _valueChanger.Change += SetSliderValue;
    }

    private void OnDisable()
    {
        _valueChanger.Change -= SetSliderValue;
    }

    private float CurrentHealth => _health.CurrentHealth;
    private float MaxHealth => _health.MaxHealth;

    private void SetSliderValue()
    {
        _bar.maxValue = MaxHealth;

        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(Smoothly());
    }

    private IEnumerator Smoothly()
    {
        var wait = new WaitForSeconds(_value);

        while (_bar.value != CurrentHealth)
        {
            _bar.value = Mathf.MoveTowards(_bar.value, CurrentHealth, _interpolationValue);
            yield return wait;
        }
    }
}

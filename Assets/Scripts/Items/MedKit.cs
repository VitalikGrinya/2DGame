using System;
using UnityEngine;

public class MedKit : MonoBehaviour
{
    [SerializeField] private float _healingValue = 10;

    public float HealingValue => _healingValue;
}
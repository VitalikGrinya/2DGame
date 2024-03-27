using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetecter : MonoBehaviour
{
    public event Action<bool> IsGrounded;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent<Ground>(out Ground ground))
            IsGrounded?.Invoke(true);
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.TryGetComponent<Ground>(out Ground ground))
            IsGrounded?.Invoke(false);
    }
}

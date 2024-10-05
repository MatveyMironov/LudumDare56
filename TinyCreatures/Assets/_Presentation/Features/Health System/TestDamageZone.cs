using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class TestDamageZone : MonoBehaviour
{
    [SerializeField] private int damagePerSecond;

    private HealthController _healthController;
    private float _damageTimer;

    private void Update()
    {
        if (_healthController != null)
        {
            _damageTimer += Time.deltaTime;
            if (_damageTimer >= 1)
            {
                _healthController.SubtractHealth(damagePerSecond);
                _damageTimer -= 1;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.TryGetComponent(out HealthController healthController))
        {
            _healthController = healthController;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform.TryGetComponent(out HealthController healthController))
        {
            if (_healthController == healthController)
            {
                _healthController = null;
                _damageTimer = 0;
            }
        }
    }
}

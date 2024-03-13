using System;
using UnityEngine;

public class AlarmZone : MonoBehaviour
{
    [SerializeField] private Alarm[] _alarms;
    
    public Action<bool> Alerting;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Thief thief))
            Alerting?.Invoke(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Thief thief))
            Alerting?.Invoke(false);
    }
}
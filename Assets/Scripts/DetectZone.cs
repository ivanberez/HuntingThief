using System;
using UnityEngine;

public class DetectZone : MonoBehaviour
{
    public Action<bool> Detecting;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Thief thief))
            Detecting?.Invoke(true);        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Thief thief))
            Detecting?.Invoke(false);
    }
}
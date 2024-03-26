using System;
using System.Collections.Generic;
using UnityEngine;

public class DetectZone : MonoBehaviour
{    
    private List<Thief> _detectList;
    
    private bool _isDetected => _detectList.Count > 0;

    public Action Detecting;
    public Action Empting;

    private void Awake()
    {
        _detectList = new List<Thief>(); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {        
        if (collision.TryGetComponent(out Thief thief) && _isDetected == false)        
            Detecting?.Invoke();      
        
        _detectList.Add(thief);
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {       
        if (collision.TryGetComponent(out Thief thief))
            _detectList.Remove(thief);

        if(_isDetected == false)
            Empting?.Invoke();
    }    
}
using UnityEngine;

[RequireComponent(typeof(Sound))]
public class Singnaling : MonoBehaviour
{
    [SerializeField] private DetectZone _detectZone;
    [SerializeField] private WarningLight[] _warningLights;
    [SerializeField] private Sound _sound;

    private void OnValidate () => _sound = GetComponent<Sound>();    

    private void OnEnable() => _detectZone.Detecting += Switshing;

    private void OnDisable() => _detectZone.Detecting -= Switshing;    

    private void Switshing(bool isAlert)
    {
        if(isAlert) 
        {
            foreach (WarningLight light in _warningLights)
                light.TurnOn();

            _sound.Play();
        }
        else
        {
            foreach(WarningLight light in _warningLights)
                light.TurnOff();

            _sound.Stop();
        }
    }
}
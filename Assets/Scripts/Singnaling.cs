using UnityEngine;

[RequireComponent(typeof(Sound))]
public class Singnaling : MonoBehaviour
{
    [SerializeField] private DetectZone _detectZone;
    [SerializeField] private WarningLight[] _warningLights;
    [SerializeField] private Sound _sound;

    private void OnValidate() => _sound = GetComponent<Sound>();

    private void OnEnable()
    {
        _detectZone.Detecting += TurnOn;
        _detectZone.Empting += TurnOff;
    }

    private void OnDisable()
    {
        _detectZone.Detecting -= TurnOn;
        _detectZone.Empting -= TurnOff;
    }

    private void TurnOn()
    {
        foreach (WarningLight light in _warningLights)
            light.TurnOn();

        _sound.Play();
    }

    private void TurnOff()
    {
        foreach (WarningLight light in _warningLights)
            light.TurnOff();

        _sound.Stop();
    }
}
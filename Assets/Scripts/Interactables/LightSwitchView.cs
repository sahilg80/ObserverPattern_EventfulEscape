using System.Collections.Generic;
using UnityEngine;

public class LightSwitchView : MonoBehaviour, IInteractable
{
    [SerializeField] private List<Light> lightsources = new List<Light>();
    private SwitchState currentState;

    public delegate void LightToggledDelegate();
    public static LightToggledDelegate OnLightToggled;

    private void OnEnable()
    {
        OnLightToggled += HideInstruction;
        OnLightToggled += PlaySoundEffects;
        OnLightToggled += ToggleLights;
    }

    private void Start() => currentState = SwitchState.Off;

    public void Interact()
    {
        //Todo - Implement Interaction
        OnLightToggled?.Invoke();
    }
    private void ToggleLights()
    {
        bool lights = false;

        switch (currentState)
        {
            case SwitchState.On:
                currentState = SwitchState.Off;
                lights = false;
                break;
            case SwitchState.Off:
                currentState = SwitchState.On;
                lights = true;
                break;
            case SwitchState.Unresponsive:
                break;
        }
        foreach (Light lightSource in lightsources)
        {
            lightSource.enabled = lights;
        }
    }

    private void HideInstruction()
    {
        GameService.Instance.GetInstructionView().HideInstruction();
    }

    private void PlaySoundEffects()
    {
        GameService.Instance.GetSoundView().PlaySoundEffects(SoundType.SwitchSound);
    }

    private void OnDisable()
    {
        OnLightToggled -= HideInstruction;
        OnLightToggled -= PlaySoundEffects;
        OnLightToggled -= ToggleLights;
    }

}

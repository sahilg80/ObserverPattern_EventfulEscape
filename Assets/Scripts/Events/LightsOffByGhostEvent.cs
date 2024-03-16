using UnityEngine;

public class LightsOffByGhostEvent : MonoBehaviour
{
    [SerializeField]
    private int keysRequiredToTrigger;
    [SerializeField]
    private SoundType soundType;

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PlayerView>()!=null && 
            GameService.Instance.GetPlayerController().KeysEquipped == keysRequiredToTrigger)
        {
            GameService.Instance.GetSoundView().PlaySoundEffects(soundType);
            EventService.Instance.OnLightsOffByGhostEvent.InvokeEvent();
            this.gameObject.SetActive( false);
        }
    }
}
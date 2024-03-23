using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Events
{
    public class PaintingMoveEvent : MonoBehaviour
    {
        [SerializeField]
        private Collider colliderToDetect;
        [SerializeField]
        private SoundType soundToPlay;
        [SerializeField]
        private Transform paintingObject;
        [SerializeField]
        private Transform targetPosition;
        [SerializeField] private int keysRequiredToTrigger;
        private void Start()
        {
            
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<PlayerView>() != null && 
                GameService.Instance.GetPlayerController().KeysEquipped == keysRequiredToTrigger)
            {
                StartCoroutine(MoveTarget());
                GameService.Instance.GetSoundView().PlaySoundEffects(soundToPlay);
                EventService.Instance.OnPaintingMove.InvokeEvent();
                colliderToDetect.enabled = false;
            }
        }

        IEnumerator MoveTarget()
        {
            yield return null;
            float speed = 1.5f;
            // Check if we've reached the target position
            while (Vector3.Distance(paintingObject.position, targetPosition.position) > 0.03f)
            {
                paintingObject.position = Vector3.MoveTowards(paintingObject.position, targetPosition.position, speed * Time.deltaTime);

                yield return null;
            }
            // Optionally, you can perform any actions here after reaching the target
            this.gameObject.SetActive(false);
        }
    
    }
}

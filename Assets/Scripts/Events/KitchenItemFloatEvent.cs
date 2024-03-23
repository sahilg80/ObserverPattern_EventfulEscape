using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenItemFloatEvent : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField] 
    private float duration; 
    [SerializeField] 
    private SoundType soundToPlay;
    [SerializeField]
    private GameObject target;
    [SerializeField]
    private Transform pointA;
    [SerializeField]
    private Transform pointB;
    [SerializeField]
    private Collider colliderToDetect;

    private float startTime;
    private Vector3 originalPosition;

    private void Start()
    {
    }

    private void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerView>() != null)
        {
            startTime = Time.time;
            StartCoroutine(OscillateItems());
            GameService.Instance.GetSoundView().PlaySoundEffects(soundToPlay);
            EventService.Instance.OnKitchenItemFloatEvent.InvokeEvent();
            colliderToDetect.enabled = false;
        }
    }

    IEnumerator OscillateItems()
    {
        float elapsedTime = Time.time - startTime;
        originalPosition = target.transform.position;

        // Check if the oscillation duration has not elapsed
        while (elapsedTime < duration)
        {
            // Calculate the position along the oscillation path using a sine function
            float t = Mathf.Sin(elapsedTime * speed);

            // Calculate the new position between the two points
            Vector3 newPosition = Vector3.Lerp(pointA.position, pointB.position, (t + 1) / 2);

            // Apply the new position to the GameObject
            target.transform.position = newPosition;
            elapsedTime = Time.time - startTime;

            yield return null;
        }
        target.transform.position = originalPosition;
    }
}

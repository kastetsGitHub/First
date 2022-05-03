using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HouseGuard : MonoBehaviour
{
    public UnityEvent<AudioClip> InHouseEvent;
    public UnityEvent OutHouseEvent;

    [SerializeField] private AudioClip _signalinSound;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent<Player>(out Player player))
        {
            InHouseEvent?.Invoke(_signalinSound);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent<Player>(out Player player))
        {
            OutHouseEvent?.Invoke();
        }
    }
}

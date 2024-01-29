using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Trigger : MonoBehaviour
{
    public event Action TriggerTurnOn;
    public event Action TriggerTurnOff;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") TriggerTurnOn?.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player") TriggerTurnOff?.Invoke();
    }
}

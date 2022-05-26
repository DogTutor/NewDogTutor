using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableClock : MonoBehaviour, IInteractable
{
    public void OnClickAction()
    {
        Debug.Log("Has encontrado el reloj");
    }

    void OnEnable()
    {
        InteractablesManager.AddToInteractablesEvent.Invoke(transform);
    }

    void OnDisable()
    {
        InteractablesManager.RemoveFromInteractablesEvent.Invoke(transform);
    }
}

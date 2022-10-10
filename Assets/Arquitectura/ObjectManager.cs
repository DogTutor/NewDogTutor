using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ObjectManager : MonoBehaviour
{
  [SerializeField]
  private List<Transform> interactables;

  public List<Transform> Interactables
  {
    get => interactables;
  }

  private Camera mainCamera;

  public static Action<Transform> AddToInteractablesEvent;
  public static Action<Transform> RemoveFromInteractablesEvent;

  private void Awake()
  {
    AddToInteractablesEvent += AddToListOfInteractables;
    RemoveFromInteractablesEvent += RemoveFromListOfInteractables;
  }

  private void AddToListOfInteractables(Transform transformToAddToList)
  {
    interactables.Add(transformToAddToList);
  }

  private void RemoveFromListOfInteractables(Transform transformToRemoveFromList)
  {
    interactables.Remove(transformToRemoveFromList);
  }
  // Start is called before the first frame update
  void Start()
  {
    mainCamera = Camera.main;

    AllChildrenWorldToScreenPoint();
  }

  private void AllChildrenWorldToScreenPoint()
  {
    for (int i = 0; i < this.transform.childCount; i++)
    {
      transform.GetChild(i).position =
          mainCamera.WorldToScreenPoint(transform.GetChild(i).position);

      transform.GetChild(i).localScale = Vector3.one * 100;
    }
  }
}

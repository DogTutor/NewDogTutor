using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CursorController : MonoBehaviour
{
  private InteractiveLidiaCursorControls controls;

  [SerializeField]
  private InteractablesManager interactablesManager;

  [SerializeField]
  private Texture2D interactiveCursorTexture;

  private Cursor interactiveCursor;

  [SerializeField]
  private Transform newSelectionTransform;
  private Transform currentSelectionTransform;

  public static Action MakeCursorDefault;
  public static Action MakeCursorInteractive;
  private bool cursorIsInteractive = false;

  public float DistanceThreshold;

  void Awake()
  {
    controls = new InteractiveLidiaCursorControls();
    controls.Mouse.Click.started += _ => StartedClick();
    controls.Mouse.Click.performed += _ => EndedClick();
    MakeCursorDefault += DefaultCursorTexture;
    MakeCursorInteractive += InteractiveCursorTexture;
  }

  private void OnEnable()
  {
    controls.Enable();
  }

  private void OnDisable()
  {
    controls.Disable();
  }

  private void Update()
  {
    FindInteractableWithinDistanceThreshold();
  }

  private void FindInteractableWithinDistanceThreshold()
  {
    newSelectionTransform = null;

    for (int itemIndex = 0;
        itemIndex < interactablesManager.Interactables.Count;
        itemIndex++)
    {
      Vector3 fromMouseToInteractableOffset =
          interactablesManager.Interactables[itemIndex].position
          - new Vector3(
              controls.Mouse.Position.ReadValue<Vector2>().x,
              controls.Mouse.Position.ReadValue<Vector2>().y,
              0f);
      float sqrMag = fromMouseToInteractableOffset.sqrMagnitude;

      if (sqrMag < DistanceThreshold * DistanceThreshold)
      {
        //Debug.Log("Distance " +
        //Vector3.Distance
        //(controls.Mouse.Position.ReadValue<Vector2>(),
        //interactables[i].position));
        newSelectionTransform =
            interactablesManager.Interactables[itemIndex].transform;

        if (cursorIsInteractive == false)
        {
          InteractiveCursorTexture();
        }
        break;
      }
    }

    if (currentSelectionTransform != newSelectionTransform)
    {
      currentSelectionTransform = newSelectionTransform;
      DefaultCursorTexture();
    }
  }

  private void InteractiveCursorTexture()
  {
    cursorIsInteractive = true;
    Vector2 hotspot = new Vector2
        (interactiveCursorTexture.width / 2, 0);
    Cursor.SetCursor(interactiveCursorTexture, hotspot, CursorMode.Auto);
  }

  private void DefaultCursorTexture()
  {
    cursorIsInteractive = false;
    Cursor.SetCursor(default, default, default);
  }

  private void StartedClick()
  {

  }

  private void EndedClick()
  {
    OnClickInteractable();
  }

  private void OnClickInteractable()
  {
    if (newSelectionTransform != null)
    {
      IInteractable interactable =
          newSelectionTransform.gameObject.GetComponent<IInteractable>();
      if (interactable != null) { interactable.OnClickAction(); }
      newSelectionTransform = null;
    }
  }
}

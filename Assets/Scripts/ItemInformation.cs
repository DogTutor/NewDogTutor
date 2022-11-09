using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInformation : MonoBehaviour
{
  #region Singleton
  public static ItemInformation instance;
  void Awake()
  {
    instance = this;
  }
  #endregion

  public delegate void OnItemSelected();
  public OnItemSelected onItemSelectedCallback;
  public Item currentItem;

  public void Show(Item newItem)
  {
    currentItem = newItem;
    if (onItemSelectedCallback != null)
    {
      onItemSelectedCallback.Invoke();
    }
  }
}

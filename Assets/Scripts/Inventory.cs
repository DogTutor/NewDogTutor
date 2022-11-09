using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
  #region Singleton
  public static Inventory instance;
  void Awake()
  {
    if (instance != null)
    {
      Debug.LogWarning("Hay más de una instancia de Inventario!");
      return;
    }
    instance = this;
  }
  #endregion
  public delegate void OnItemChanged();
  public OnItemChanged onItemChangedCallback;
  public List<Item> items = new List<Item>();
  public void Add(Item item)
  {
    items.Add(item);

    if (onItemChangedCallback != null)
    {
        onItemChangedCallback.Invoke();
    }
    
  }

}

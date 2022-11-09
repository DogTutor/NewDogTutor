using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
  new public string name = "New Item";
  
  public string description = "New Description";
  public Sprite icon = null;
  public virtual void Select()
  {
    //Debug.Log("Selected " + name);
    ItemInformation.instance.Show(this);
  }
}


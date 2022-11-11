using UnityEngine;

public class InventoryUI : MonoBehaviour
{
  public Transform itemsParent, referenciaParent;
  public GameObject inventoryUI;
  Inventory inventory;
  ItemInformation information;
  InventorySlot[] slots;
  ReferenciaSlot referencia;
  // Start is called before the first frame update
  void Start()
  {
    inventory = Inventory.instance;
    inventory.onItemChangedCallback += UpdateUI;

    information = ItemInformation.instance;
    information.onItemSelectedCallback += UpdateDescription;

    slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    referencia = referenciaParent.GetComponentInChildren<ReferenciaSlot>();
  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetButtonDown("Inventory"))
    {
      ActivateInventory();
    }
  }

  public void ActivateInventory()
  {
    inventoryUI.SetActive(!inventoryUI.activeSelf);
  }

  void UpdateUI()
  {
    for (int i = 0; i < slots.Length; i++)
    {
      if (i < inventory.items.Count)
      {
        slots[i].AddItem(inventory.items[i]);
      }
    }
  }
  void UpdateDescription()
  {
    referencia.ReferenceItem(information.currentItem);
  }
  public void OnRemoveButton()
  {
    inventoryUI.SetActive(!inventoryUI.activeSelf);
  }
}

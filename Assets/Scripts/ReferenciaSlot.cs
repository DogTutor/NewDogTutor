using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ReferenciaSlot : MonoBehaviour
{
    public Image refImage;
    public TextMeshProUGUI title, description;
    public void ReferenceItem(Item newItem)
  {
    refImage.sprite = newItem.icon;
    refImage.enabled = true;
    title.text = newItem.name;
    description.text = newItem.description;
  }
}

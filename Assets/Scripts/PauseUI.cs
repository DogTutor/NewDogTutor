using UnityEngine;

public class PauseUI : MonoBehaviour
{
  public GameObject menuUI, inventoryUI;
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetButtonDown("Pause"))
    {
      ActivateMenu();
    }
  }
  public void ActivateMenu()
  {
    if (inventoryUI.activeSelf)
    {
      inventoryUI.SetActive(!inventoryUI.activeSelf);
    }
    menuUI.SetActive(!menuUI.activeSelf);
  }
}

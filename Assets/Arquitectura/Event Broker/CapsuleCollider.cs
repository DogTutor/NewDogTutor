using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleCollider : MonoBehaviour
{
  public delegate void ClickAction();
  // Update is called once per frame
  void Update()
  {
    if (Input.GetMouseButtonDown(0))
    {
      RaycastHit hitInfo = new RaycastHit();
      bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
      if (hit)
      {
        //ClickAction();
      }
    }
  }
}

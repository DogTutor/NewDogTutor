using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
  public GameObject bubbleUi;
  private GameObject bubbleUse;
  private Vector3 localPosition = new Vector3(-0.7f, 1.6f);
  private void bubble(Transform charTransform, string text)
  {
    bubbleUse = Instantiate(bubbleUi, FindObjectOfType<Canvas>().transform);
    bubbleUse.transform.position = Camera.main.WorldToScreenPoint(charTransform.position + localPosition);
    bubbleUse.GetComponent<ChatBubble>().Setup(text);
    Destroy(bubbleUse.gameObject, 6f);
  }
}

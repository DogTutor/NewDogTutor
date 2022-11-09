using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArdManager : MonoBehaviour
{
  public GameObject bubbleUi;
  private GameObject bubbleUse;

  [SerializeField] private Transform kikiTransform;
  private Vector3 localPosition = new Vector3(-0.7f, 1.6f);
  // Start is called before the first frame update
  void Start()
  {
    bubble(kikiTransform, "Una boleta para una pelicula, el sospechoso debe estar en el cine");
  }

  // Update is called once per frame
  void Update()
  {

  }

  private void bubble(Transform charTransform, string text)
  {
    bubbleUse = Instantiate(bubbleUi, FindObjectOfType<Canvas>().transform);
    bubbleUse.transform.position = Camera.main.WorldToScreenPoint(charTransform.position + localPosition);
    bubbleUse.transform.SetAsFirstSibling();
    bubbleUse.GetComponent<ChatBubble>().Setup(text);
    Destroy(bubbleUse.gameObject, 8f);
  }
}

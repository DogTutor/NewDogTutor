using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComisariaHandler : MonoBehaviour
{
    public GameObject bubbleUi;
    private GameObject bubbleUse;
    private string textLidia1 = "Inspector, ¡ayuda!";
    private Vector3 localPosition = new Vector3 (-0.7f,1.6f);
    [SerializeField] private Transform lidiaTransform;
    [SerializeField] private Transform inspectorTransform;
    [SerializeField] private Transform felixTransform;
    // Start is called before the first frame update
    void Start()
    {
        bubbleUse = Instantiate(bubbleUi, FindObjectOfType<Canvas>().transform);
        bubble();
        
    }

    void Update()
    {
        
    }

    private void bubble()
    {
        bubbleUse.transform.position = Camera.main.WorldToScreenPoint(lidiaTransform.position+localPosition);
        bubbleUse.GetComponent<ChatBubble>().Setup(textLidia1);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComisariaHandler : MonoBehaviour
{
    public GameObject bubbleUi;
    private GameObject bubbleUse;
    private string text = "Primer Texto";
    [SerializeField] private Transform lidiaTransform;
    [SerializeField] private Transform inspectorTransform;
    [SerializeField] private Transform felixTransform;
    // Start is called before the first frame update
    void Start()
    {
        bubbleUse = Instantiate(bubbleUi, FindObjectOfType<Canvas>().transform);
        
    }

    void Update()
    {
        bubbleUse.transform.position = Camera.main.WorldToScreenPoint(inspectorTransform.position);
        bubbleUse.GetComponent<ChatBubble>().Setup(text);
    }
}

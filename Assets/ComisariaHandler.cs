using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComisariaHandler : MonoBehaviour
{
    public GameObject bubbleUi;
    private GameObject bubbleUse;
    private Vector3 localPosition = new Vector3 (-0.7f,1.6f);
    [SerializeField] private Transform lidiaTransform;
    [SerializeField] private Transform inspectorTransform;
    [SerializeField] private Transform felixTransform;
    [SerializeField] private GameObject tutorial;
    
    // Start is called before the first frame update
    void Start()
    {
        bubble(lidiaTransform, "Inspector, ¡ayuda!");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Destroy(bubbleUse);
            Destroy(tutorial);
            bubble(inspectorTransform, "Es Lidia Acosta, ¿Qué ocurrió?");
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Destroy(bubbleUse);
                bubble(lidiaTransform, "Han entrado a mi casa y me han robado mis joyas");
            }
        }
    }

    private void bubble(Transform charTransform, string text)
    {
        bubbleUse = Instantiate(bubbleUi, FindObjectOfType<Canvas>().transform);
        bubbleUse.transform.position = Camera.main.WorldToScreenPoint(charTransform.position+localPosition);
        bubbleUse.GetComponent<ChatBubble>().Setup(text);
    }
}

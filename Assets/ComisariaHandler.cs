using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComisariaHandler : MonoBehaviour
{
    [SerializeField] private Transform lidiaTransform;
    [SerializeField] private Transform inspectorTransform;
    [SerializeField] private Transform felixTransform;
    // Start is called before the first frame update
    void Start()
    {
        ChatBubble.Create(lidiaTransform, new Vector3(3,3), "Ayuda inspector, me han robado");
    }
}

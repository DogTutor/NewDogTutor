using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChatBubble : MonoBehaviour
{
    
    public static void Create(string text)
    {
        Transform chatBubbleTransform = Instantiate(GameAssets.i.pfChatBubble, FindObjectOfType<Canvas>().transform);
        //chatBubbleTransform.localPosition = localPosition;

        chatBubbleTransform.GetComponent<ChatBubble>().Setup(text);
    }

    private Image backgroundImage;
    private TextMeshProUGUI textMeshPro;
    void Awake()
    {
        backgroundImage = transform.Find("BGBubble").GetComponent<Image>();
        textMeshPro = transform.Find("TextBubble").GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        Setup("Hello World! Hello World! Hello World!");
    }

    public void Setup(string text)
    {
        textMeshPro.text = text;
        textMeshPro.ForceMeshUpdate();
        Vector2 textSize = textMeshPro.GetRenderedValues(false);

        Vector2 padding = new Vector2(15f, 4f);
        backgroundImage.rectTransform.sizeDelta = textSize + padding;
        
        Vector2 offset = new Vector2(0f, -13f);
        backgroundImage.transform.localPosition = 
            new Vector2(backgroundImage.rectTransform.sizeDelta.x / -2f, 0f) + offset;
    }
}

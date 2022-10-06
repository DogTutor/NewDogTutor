using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TestCollider : MonoBehaviour
{
  [SerializeField]
  private PlayableDirector ardillaTime;
  [SerializeField]
  private StoryCinematicDirector director;
  // Variables Flag
  private float relojFlag = 0;
  private float saveFlag = 0;
  private float chocolateFlag = 0;
  private float brokeFlag = 0;
  private float windowFlag = 0;
  private float ardillaFlag = 0;
  private float periodicoFlag = 0;


  [SerializeField] private Transform lidiaTransform;
  [SerializeField] private Transform adelaTransform;
  [SerializeField] private Transform felixTransform;
  [SerializeField] private Transform rolloTransform;
  [SerializeField] private Transform kikiTransform;
  private Vector3 localPosition = new Vector3(-0.7f, 1.6f);

  public GameObject bubbleUi;
  private GameObject bubbleUse;
  public delegate void ClickAction();
  //public static event ClickAction OnClickedClock;

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetMouseButtonDown(0))
    {
      RaycastHit hitInfo = new RaycastHit();
      bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
      if (hit)
      {
        if (hitInfo.transform.gameObject.name == "InteractableClock" && relojFlag == 0)
        {
          Destroy(bubbleUse);
          bubble(adelaTransform, "Un reloj caído detenido 5 minutos después de media noche");
          relojFlag = 1;
        }
        if (hitInfo.transform.gameObject.name == "InteractableSafe" && saveFlag == 0)
        {
          Destroy(bubbleUse);
          bubble(kikiTransform, "La caja fuerte está intacta");
          saveFlag = 1;
        }
        if (hitInfo.transform.gameObject.name == "InteractableChocolate" && chocolateFlag == 0)
        {
          Destroy(bubbleUse);
          bubble(lidiaTransform, "Pueden comer de los bombones de chocolate \n como agradecimiento");
          chocolateFlag = 1;
        }
        if (hitInfo.transform.gameObject.name == "InteractableNews" && periodicoFlag == 0)
        {
          Destroy(bubbleUse);
          bubble(felixTransform, "Un periódico con la cartelera de cine, puede ser de ayuda");
          periodicoFlag = 1;
        }
        if (hitInfo.transform.gameObject.name == "InteractableBroke" && brokeFlag == 0)
        {
          Destroy(bubbleUse);
          bubble(rolloTransform, "El ladrón escapó por la ventana, pero, \n ¿Cómo lo alcanzamos?");
          brokeFlag = 1;
        }
        if (hitInfo.transform.gameObject.name == "InteractableWindow"
           && windowFlag == 0 && brokeFlag == 1)
        {
          Destroy(bubbleUse);
          bubble(kikiTransform, "¿Quién sería lo suficientemente pequeño para subir por ahí?");
          windowFlag = 1;
        }
        if (hitInfo.transform.gameObject.name == "InteractableArdilla" && ardillaFlag == 0
           && windowFlag == 1 && brokeFlag == 1 && periodicoFlag == 1)
        {
          Destroy(bubbleUse);
          bubble(kikiTransform, "¡Claro!, ardilla sube y mira que encuentras");
          ardillaFlag = 1;
          director.PlayCinematic(ardillaTime);
        }
      }
    }
  }

  private void bubble(Transform charTransform, string text)
  {
    bubbleUse = Instantiate(bubbleUi, FindObjectOfType<Canvas>().transform);
    bubbleUse.transform.position = Camera.main.WorldToScreenPoint(charTransform.position + localPosition);
    bubbleUse.GetComponent<ChatBubble>().Setup(text);
    Destroy(bubbleUse.gameObject, 6f);
  }
}

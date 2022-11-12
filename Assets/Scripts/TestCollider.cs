using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TestCollider : MonoBehaviour
{
  public Item reloj, periodico, roto, ventana, boleta;
  public GameObject inventario, confetti, menuUI;
  private AudioSource positivo, negativo;
  public AudioClip positivoClip, negativoClip;
  public Slider volumeSlider;

  [SerializeField]
  private PlayableDirector ardillaTime;
  [SerializeField]
  private StoryCinematicDirector director;
  // Variables Flag
  private float relojFlag = 0;
  private float brokeFlag = 0;
  private float windowFlag = 0;
  private float ardillaFlag = 0;
  private float periodicoFlag = 0;


  [SerializeField] private Transform lidiaTransform;
  [SerializeField] public Transform adelaTransform;
  [SerializeField] private Transform felixTransform;
  [SerializeField] private Transform rolloTransform;
  [SerializeField] private Transform kikiTransform;
  private Vector3 localPosition = new Vector3(-0.7f, 1.6f);

  public GameObject bubbleUi;
  private GameObject bubbleUse;

  string[] felixMensaje = new string[] {
    "Esto no es interesante.",
    "Concéntrate, esto no es una pista",
    "Esto no será de mucha ayuda.",
    "Mejor haz sonar la trompeta si no vas a buscar buenas pistas",
    "Deja ese objeto, no es de utilidad",
    "Te equivocas, esto no es interesante"
  };
  string[] adelaMensaje = new string[] {
    "Sé astuta, esto no será de ayuda","Dudo que esto sea importante",
    "No te engañes a ti misma, esto no es interesante",
    "Concéntrate en tu habilidad,\n piensa como el malhechor",
    "¡Es imposible que esto sea una pista!","¡Caramba, vaya desorden!"
  };
  string[] rolloMensaje = new string[] {
    "No es posible que esto sea una pista",
    "No hay nada más aburrido para un detective \n que no encontrar pistas",
    "¿Qué te hace pensar que será una pista interesante?",
    "Este tipo de objetos es lo que tenemos \n que evitar al investigar",
    "Mejor será que nos concentremos",
    "No hay ninguna huella aquí"
  };
  string[] kikiMensaje = new string[] {
    "Ardilla, ¿en serio crees que esto pueda ser de utilidad?",
    "concéntrate y ayúdame ardilla",
    "Me estás distrayendo ardilla, esto no es interesante",
    "La importancia de este objeto en el caso \n es tan pequeña como mi ardilla",
    "Esto es realmente insignificante para nosotros",
    "Será mejor que nos concentremos"
  };

  // Start is called before the first frame update
  void Start()
  {
    positivo = gameObject.AddComponent<AudioSource>();
    negativo = gameObject.AddComponent<AudioSource>();
    positivo.clip = positivoClip;
    negativo.clip = negativoClip;

    volumeSlider.onValueChanged.AddListener((v) =>
    {
      positivo.volume = v;
      negativo.volume = v;
    });
  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetMouseButtonDown(0) && !inventario.activeSelf && !menuUI.activeSelf)
    {
      RaycastHit hitInfo = new RaycastHit();
      bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
      if (hit)
      {
        // Pistas
        if (hitInfo.transform.gameObject.name == "InteractableClock" && relojFlag == 0)
        {
          positivo.Play();
          Instantiate(confetti, hitInfo.transform.position, Quaternion.identity);
          Destroy(bubbleUse);
          bubble(adelaTransform, "Un reloj caído detenido 5 minutos después de media noche");
          relojFlag = 1;
          //Debug.Log("Recogió " + reloj.name);
          Inventory.instance.Add(reloj);
        }
        if (hitInfo.transform.gameObject.name == "InteractableNews" && periodicoFlag == 0)
        {
          positivo.Play();
          Instantiate(confetti, hitInfo.transform.position, Quaternion.identity);
          Destroy(bubbleUse);
          bubble(felixTransform, "Un periódico con la cartelera de cine, puede ser de ayuda");
          periodicoFlag = 1;
          Inventory.instance.Add(periodico);
        }
        if (hitInfo.transform.gameObject.name == "InteractableBroke" && brokeFlag == 0)
        {
          positivo.Play();
          Instantiate(confetti, hitInfo.transform.position, Quaternion.identity);
          Destroy(bubbleUse);
          bubble(rolloTransform, "El ladrón entró por la ventana, pero, \n hay muchos vidrios rotos");
          brokeFlag = 1;
          Inventory.instance.Add(roto);
        }
        if (hitInfo.transform.gameObject.name == "InteractableWindow"
           && windowFlag == 0 && brokeFlag == 1)
        {
          positivo.Play();
          Instantiate(confetti, hitInfo.transform.position, Quaternion.identity);
          Destroy(bubbleUse);
          bubble(kikiTransform, "¿Quién sería lo suficientemente pequeño para subir por ahí?");
          windowFlag = 1;
          Inventory.instance.Add(ventana);
        }
        if (hitInfo.transform.gameObject.name == "InteractableArdilla" && ardillaFlag == 0
           && windowFlag == 1 && brokeFlag == 1 && periodicoFlag == 1)
        {
          positivo.Play();
          Instantiate(confetti, hitInfo.transform.position, Quaternion.identity);
          Destroy(bubbleUse);
          bubble(kikiTransform, "¡Claro!, ardilla sube y mira que encuentras");
          ardillaFlag = 1;
          Inventory.instance.Add(boleta);
          director.PlayCinematic(ardillaTime);
        }
        // Interactuables
        if (hitInfo.transform.gameObject.name == "InteractableSafe")
        {
          negativo.Play();
          Destroy(bubbleUse);
          bubble(kikiTransform, "La caja fuerte está intacta");
          Destroy(hitInfo.transform.gameObject);
        }
        if (hitInfo.transform.gameObject.name == "InteractableChocolate")
        {
          negativo.Play();
          Destroy(bubbleUse);
          bubble(lidiaTransform, "Pueden comer de los bombones de chocolate \n como agradecimiento");
          Destroy(hitInfo.transform.gameObject);
        }

        switch (hitInfo.transform.gameObject.tag)
        {
          case "InteractableFelix":
            randomMessagge(felixTransform, felixMensaje);
            negativo.Play();
            break;
          case "InteractableAdela":
            randomMessagge(adelaTransform, adelaMensaje);
            negativo.Play();
            break;
          case "InteractableRollo":
            randomMessagge(rolloTransform, rolloMensaje);
            negativo.Play();
            break;
          case "Interactablekiki":
            negativo.Play();
            randomMessagge(kikiTransform, kikiMensaje);
            break;
        }
      }
    }

    if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow))
    {
      Destroy(bubbleUse);
    }
  }

  private void bubble(Transform charTransform, string text)
  {
    bubbleUse = Instantiate(bubbleUi, FindObjectOfType<Canvas>().transform);
    bubbleUse.transform.position = Camera.main.WorldToScreenPoint(charTransform.position + localPosition);
    bubbleUse.transform.SetAsFirstSibling();
    bubbleUse.GetComponent<ChatBubble>().Setup(text);
    Destroy(bubbleUse.gameObject, 6f);
  }

  private void randomMessagge(Transform personaje, string[] mensaje)
  {
    Destroy(bubbleUse);
    string randomBubble = mensaje[Random.Range(0, mensaje.Length)];
    bubble(personaje, randomBubble);
  }
  public void muteFX()
  {
    positivo.mute = !positivo.mute;
    negativo.mute = !negativo.mute;
  }
}

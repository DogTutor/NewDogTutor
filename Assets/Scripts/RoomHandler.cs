using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomHandler : MonoBehaviour
{
  public new Transform camera;
  [SerializeField] private GameObject introScene;
  public AudioClip musicaLidia;

  // Start is called before the first frame update
  void Start()
  {
    AudioManager.instance.SwapTrack(musicaLidia);
  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Space))
    {
      camera.GetComponent<CameraMovement>().flagScene = 1;
      Destroy(introScene);
    }
  }
}

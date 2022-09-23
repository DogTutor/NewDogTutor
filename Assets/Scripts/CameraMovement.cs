using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
  private Vector3 endPosition;
  private Vector3 startPosition;
  private float desiredDuration = 1f;
  private float elapsedTime;

  [SerializeField]
  private AnimationCurve curve;
  public float flagScene = 0;

  // Start is called before the first frame update
  void Start()
  {
    startPosition = transform.position;
  }

  // Update is called once per frame
  void Update()
  {

    if (flagScene == 1)
    {
      elapsedTime += Time.deltaTime;
      float percentageComplete = elapsedTime / desiredDuration;

      transform.position = Vector3.Lerp(startPosition, endPosition, curve.Evaluate(percentageComplete));

      // Sala
      if (transform.position.z == 0 && Input.GetKeyDown(KeyCode.RightArrow))
      {
        startPosition = new Vector3(0, 0, 0);
        endPosition = new Vector3(0, 0, -30);

      }
      else if (transform.position.z == 0 && Input.GetKeyDown(KeyCode.LeftArrow))
      {
        startPosition = new Vector3(0, 0, 0);
        endPosition = new Vector3(0, 0, -90);
      }

      // Cocina
      if (transform.position.z == -30 && Input.GetKeyDown(KeyCode.RightArrow))
      {
        startPosition = new Vector3(0, 0, -30);
        endPosition = new Vector3(0, 0, -60);
      }
      else if (transform.position.z == -30 && Input.GetKeyDown(KeyCode.LeftArrow))
      {
        startPosition = new Vector3(0, 0, -30);
        endPosition = new Vector3(0, 0, 0);
      }

      // Cocina
      if (transform.position.z == -60 && Input.GetKeyDown(KeyCode.RightArrow))
      {
        startPosition = new Vector3(0, 0, -60);
        endPosition = new Vector3(0, 0, -90);
      }
      else if (transform.position.z == -60 && Input.GetKeyDown(KeyCode.LeftArrow))
      {
        startPosition = new Vector3(0, 0, -60);
        endPosition = new Vector3(0, 0, -30);
      }

      // Habitacion
      if (transform.position.z == -90 && Input.GetKeyDown(KeyCode.RightArrow))
      {
        startPosition = new Vector3(0, 0, -90);
        endPosition = new Vector3(0, 0, 0);
      }
      else if (transform.position.z == -90 && Input.GetKeyDown(KeyCode.LeftArrow))
      {
        startPosition = new Vector3(0, 0, -90);
        endPosition = new Vector3(0, 0, -60);
      }
    }
  }
}

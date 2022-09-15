using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicCameraMovement : MonoBehaviour
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
    //startPosition = transform.position;
  }

  // Update is called once per frame
  void Update()
  {
    elapsedTime += Time.deltaTime;
    float percentageComplete = elapsedTime / desiredDuration;
    transform.position = Vector3.Lerp(startPosition, endPosition, curve.Evaluate(percentageComplete));

    if (Input.GetKeyDown(KeyCode.RightArrow))
    {
      startPosition = transform.position;
      endPosition = startPosition + new Vector3(10, 0, 0);
    }
    if (Input.GetKeyDown(KeyCode.LeftArrow))
    {
      startPosition = transform.position;
      endPosition = startPosition + new Vector3(-10, 0, 0);
    }
  }
}

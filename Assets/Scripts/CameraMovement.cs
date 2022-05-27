using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject Canvas;
    private Vector3 endPosition;
    private Vector3 startPosition;
    private float desiredDuration = 2f;
    private float elapsedTime;

    [SerializeField]
    private AnimationCurve curve;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        elapsedTime += Time.deltaTime;
        float percentageComplete = elapsedTime / desiredDuration;

        transform.position = Vector3.Lerp(startPosition, endPosition, curve.Evaluate(percentageComplete));        
        
        // Sala
        if (transform.position.x == 0 && Input.GetKeyDown(KeyCode.RightArrow))
        {
            startPosition = new Vector3(0,0,0);
            endPosition = new Vector3(10,0,0);

        } else if (transform.position.x == 0 && Input.GetKeyDown(KeyCode.LeftArrow))
        {
            startPosition = new Vector3(0,0,0);
            endPosition = new Vector3(30,0,0);
        }

        // Estudio
        if (transform.position.x == 10 && Input.GetKeyDown(KeyCode.RightArrow))
        {
            startPosition = new Vector3(10,0,0);
            endPosition = new Vector3(20,0,0);
        } else if (transform.position.x == 10 && Input.GetKeyDown(KeyCode.LeftArrow))
        {
            startPosition = new Vector3(10,0,0);
            endPosition = new Vector3(0,0,0);
        }

        // Cocina
        if (transform.position.x == 20 && Input.GetKeyDown(KeyCode.RightArrow))
        {
            startPosition = new Vector3(20,0,0);
            endPosition = new Vector3(30,0,0);
        } else if (transform.position.x == 20 && Input.GetKeyDown(KeyCode.LeftArrow))
        {
            startPosition = new Vector3(20,0,0);
            endPosition = new Vector3(10,0,0);
        }

        // Habitacion
        if (transform.position.x == 30 && Input.GetKeyDown(KeyCode.RightArrow))
        {
            startPosition = new Vector3(30,0,0);
            endPosition = new Vector3(0,0,0);
        } else if (transform.position.x == 30 && Input.GetKeyDown(KeyCode.LeftArrow))
        {
            startPosition = new Vector3(30,0,0);
            endPosition = new Vector3(20,0,0);
        } 
        
    }
}

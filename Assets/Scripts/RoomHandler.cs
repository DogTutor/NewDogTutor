using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomHandler : MonoBehaviour
{
    public GameObject camera;
    [SerializeField] private GameObject introScene;
    // Start is called before the first frame update
    void Start()
    {
        
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Reset : MonoBehaviour
{
    [SerializeField]
    private PlayableDirector resetGame;
    [SerializeField]
    private StoryCinematicDirector director;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            director.PlayCinematic(resetGame);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class playerCollision : MonoBehaviour
{
    private GameObject maze;

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other) 
    {
        maze = other.gameObject.transform.parent.gameObject;
        if(maze.name == "Maze")
        {
            
            maze.GetComponent<mazeControl>().TouchHelp();
            maze.transform.position = Vector3.zero;
        }
    }
}

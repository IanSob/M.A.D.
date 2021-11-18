using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    public GameObject Maze;
    public GameObject WinScreen;
    private void OnCollisionEnter2D(Collision collision)
    {
        Maze.SetActive(false);
        WinScreen.SetActive(true);
    }
}

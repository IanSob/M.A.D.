using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Text = UnityEngine.UI.Text;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class mazeControl : MonoBehaviour
{
    private Vector2 setOffset;
    public GameObject maze;
    private float touchCount;
    private Vector2 startVec;
    private Vector3 mazeStartRotation;
    private bool helper;
    private float startScale;
    public int maxClones;
    public GameObject[] Spawnables;

    private void OnEnable() 
    {
        EnhancedTouchSupport.Enable();
        TouchSimulation.Enable();
        helper = true;
    }

    private void OnDisable()
    {
        EnhancedTouchSupport.Disable();
        maze.transform.position = Vector3.zero;
        TouchSimulation.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        if(Touch.activeFingers.Count > 1)
        {
            Vector2 touchOnePos = (Vector2)Camera.main.ScreenToWorldPoint(Touch.activeFingers[0].screenPosition);
            Vector2 touchTwoPos = (Vector2)Camera.main.ScreenToWorldPoint(Touch.activeFingers[1].screenPosition);
            Vector2 setPosition = (touchOnePos - touchTwoPos) / 2 + touchOnePos;
            RotationHandler(touchOnePos, touchTwoPos, touchCount);
            if(touchCount != Touch.activeFingers.Count || helper)
            {
                setOffset = setPosition - (Vector2)maze.transform.position;
                helper = false;
            }

            
            maze.transform.position = new Vector3(setPosition.x - setOffset.x, setPosition.y - setOffset.y, 10);
        }
        else
        {
            helper = true;
        }
        
        if(Touch.activeFingers.Count > 2 && touchCount != Touch.activeFingers.Count)
        {
            Vector3 newspawnposition = new Vector3(0, 0, 10) + Camera.main.ScreenToWorldPoint(Touch.activeFingers[Touch.activeFingers.Count - 1].screenPosition);
            GameObject[] clones = GameObject.FindGameObjectsWithTag("Clone");
            if(clones.Length > maxClones)
            {
                
            }
            else
            {
                int cloneThis = Random.Range(0, Spawnables.Length);
                Instantiate(Spawnables[cloneThis], newspawnposition, Quaternion.Euler(Vector3.zero));
            }
            
        }
        touchCount = Touch.activeFingers.Count;
    }
    
    void RotationHandler(Vector2  touchOnePos, Vector2 touchTwoPos, float touchcnt)
    {
        if(touchcnt != Touch.activeFingers.Count || helper)
        {
            startVec = touchOnePos - touchTwoPos;
            mazeStartRotation = maze.transform.rotation.eulerAngles;
        }
        float currentAngle = Vector2.SignedAngle(startVec, touchOnePos - touchTwoPos);
        maze.transform.rotation = Quaternion.Euler(0, 0, mazeStartRotation.z + currentAngle); 
    }

    public void TouchHelp()
    {
        StartCoroutine(TouchFinder());
    }

    IEnumerator TouchFinder()
    {
        if(Touch.activeFingers.Count < 1)
        {
            helper = true;
            StopCoroutine(TouchFinder());
            Debug.Log("ran");
            Debug.Log(Touch.activeFingers.Count);
        }
        else
        {
            Debug.Log("cor");
            yield return new WaitForSeconds(0.1f);
            StartCoroutine(TouchFinder());
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Camera camera;

    [SerializeField] private LayerMask navigableMask;

    [SerializeField] private NavMeshAgent agent;
    
    void Start()
    {
        
    }

    void Update()
    {
        //ToDo holding down mouse button to periodically set the new location
        if (Input.GetMouseButtonDown(0))
        {
            RaycastToMouse();
        }
    }

    /// <summary>
    /// Shoot raycast towards the mouse cursor
    /// if possible, set a new location to move towards
    /// </summary>
    void RaycastToMouse()
    {
        RaycastHit hit;
       
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(ray, out hit)) {
            if(CheckNavigableGround(hit)){
                SetNewLocation(hit.point);
            }
            else
            {
                Debug.Log(hit.transform.name + " was hit but is not navigable");
            }
        }
        else
        {
            Debug.Log("Nothing was hit");
        }
    }

    /// <summary>
    /// Check if the selected point is possible to navigate to
    /// </summary>
    /// <param name="hit"> The ray cast hit to compare layers with </param>
    /// <returns></returns>
    bool CheckNavigableGround(RaycastHit hit)
    {
        if (navigableMask == (navigableMask | (1 << hit.transform.gameObject.layer)))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
    /// <summary>
    /// Set the location for navigation
    /// If the point is close and the path to it is short move straight to the point
    /// if the path is long, select a point in a straight line closest to the location
    /// </summary>
    /// <param name="worldSpaceLocation"> Location to move to in worldspace </param>
    void SetNewLocation(Vector3 worldSpaceLocation)
    {
        //ToDo check distance to point for more simplistic close movement
        
        //sets the agents destination point
        agent.SetDestination(worldSpaceLocation);
    }
}

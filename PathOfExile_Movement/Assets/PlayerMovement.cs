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
        if (Input.GetMouseButtonDown(0))
        {
            RaycastToMouse();
        }
    }

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
                Debug.Log(" was hit but is not navigable");
            }
        }
        else
        {
            Debug.Log("Nothing was hit");
        }
    }

    bool CheckNavigableGround(RaycastHit hit)
    {
        if (hit.transform.gameObject.layer == navigableMask)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void SetNewLocation(Vector3 worldSpaceLocation)
    {
        agent.SetDestination(worldSpaceLocation);
    }
}

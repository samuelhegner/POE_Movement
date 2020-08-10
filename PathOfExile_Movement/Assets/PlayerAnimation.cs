using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;

    [SerializeField] private NavMeshAgent agent;

    [SerializeField] private string movingParameter;
    
    private int movingParameterID;

    private bool moving;


    // Start is called before the first frame update
    void Start()
    {
        //Get the id of the moving bool
        movingParameterID = Animator.StringToHash(movingParameter);
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.velocity.magnitude > 0.35f)
        {
            //the player is moving set animation bool to true
            if (!animator.GetBool(movingParameterID))
            {
                ChangeAnimationBool(movingParameterID, true);
            }
        }
        else
        {
            //the player is stopped set animation bool to false
            if (animator.GetBool(movingParameterID))
            {
                ChangeAnimationBool(movingParameterID, false);
            }
        }
    }

    void ChangeAnimationBool(int parameterId, bool value)
    {
        animator.SetBool(parameterId, value);
    }
}
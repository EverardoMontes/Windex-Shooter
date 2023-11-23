using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Used to make sure the GO is on the NavMesh.
/// </summary>
public class NavMeshGO : MonoBehaviour
{
    void Start()
    {
        GameObject go = new GameObject("Target");
        Vector3 sourcePostion = new Vector3(100, 20, 100);//The position you want to place your agent
        NavMeshHit closestHit;
        if (NavMesh.SamplePosition(sourcePostion, out closestHit, 500, 1))
        {
            go.transform.position = closestHit.position;
            go.AddComponent<NavMeshAgent>();
            //TODO
        }
        else
        {
            Debug.Log("...");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

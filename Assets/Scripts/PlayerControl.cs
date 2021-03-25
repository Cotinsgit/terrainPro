using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerControl : MonoBehaviour
{
    //用于寻路
    private NavMeshAgent navMeshAgent;

    //用于绘制路径
    private LineRenderer lineRenderer;

    // Use this for initialization
	void Start ()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        lineRenderer = GetComponent<LineRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 50))
            {
                if (hit.transform.tag == "Ground")
                {
                    navMeshAgent.SetDestination(hit.point);
                }
            }
        }
        if (navMeshAgent.path.corners.Length > 1)
        {
            lineRenderer.positionCount = navMeshAgent.path.corners.Length;
            lineRenderer.SetPositions(navMeshAgent.path.corners);
        }
    }
}

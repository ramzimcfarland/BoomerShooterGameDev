// This script was written based off of this Youtube tutorial: https://www.youtube.com/watch?v=Mcs7Ykxe6Ko

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;

public class ClickToMove : MonoBehaviour
{
    private NavMeshAgent navAgent;

    private void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, NavMesh.AllAreas))
            {
                navAgent.SetDestination(hit.point);
            }
        }
    }
}

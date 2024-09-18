using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateProjector : MonoBehaviour
{
    private GameObject particles;

    void Start()
    {
        particles = GameObject.Find("Particle System");
        particles.SetActive(!particles.activeSelf);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 0 is for the left mouse button
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 5f))  // Adjust ray distance as needed
            {
                Transform target = hit.transform;
                if (target.IsChildOf(transform) || target == transform)
                    ActivateParticlesProjector();
            }
        }
    }

    public void ActivateParticlesProjector()
    {
        particles.SetActive(!particles.activeSelf);
    }
}

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

/// <summary>
/// This example demonstrates how to toggle plane detection,
/// and also hide or show the existing planes.
/// </summary>
[RequireComponent(typeof(ARPlaneManager))]
public class ARPlaneSwitcher : MonoBehaviour
{
    public void ARPlaneVisToggle(bool value)
        {
            m_ARPlaneManager.enabled = value;
            SetAllPlanesActive(value);
        }

    void SetAllPlanesActive(bool value)
    {
        foreach (var plane in m_ARPlaneManager.trackables)
            plane.gameObject.SetActive(value);
    }

    void Awake()
    {
        m_ARPlaneManager = GetComponent<ARPlaneManager>();
    }

    ARPlaneManager m_ARPlaneManager;
}

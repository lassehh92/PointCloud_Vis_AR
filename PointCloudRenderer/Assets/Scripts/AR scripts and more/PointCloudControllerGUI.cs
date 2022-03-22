using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BAPointCloudRenderer.CloudController;

public class PointCloudControllerGUI : MonoBehaviour
{
    public GameObject my_PointCloudSet;
    public GameObject my_CloudLoader;

    public void HidePointCloudsButton()
    {
        my_PointCloudSet.GetComponent<DynamicPointCloudSet>().PointRenderer.Hide();
    }

    public void DisplayPointCloudsButton()
    {
        my_PointCloudSet.GetComponent<DynamicPointCloudSet>().PointRenderer.Display();
    }

    public void LoadPointCloudsButton()
    {
        my_CloudLoader.GetComponent<PointCloudLoader>().LoadPointCloud();
    }
}

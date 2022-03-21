using UnityEngine;
using UnityEngine.UI;


public class RotationRootController : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The slider used to control rotation.")]
    Slider m_Slider;

    /// <summary>
    /// The slider used to control rotation.
    /// </summary>
    public Slider slider
    {
        get { return m_Slider; }
        set { m_Slider = value; }
    }

    [SerializeField]
    [Tooltip("Minimum rotation angle in degrees.")]
    public float m_Min = 0f;

    /// <summary>
    /// Minimum angle in degrees.
    /// </summary>
    public float min
    {
        get { return m_Min; }
        set { m_Min = value; }
    }

    [SerializeField]
    [Tooltip("Maximum angle in degrees.")]
    public float m_Max = 360f;

    /// <summary>
    /// Maximum angle in degrees.
    /// </summary>
    public float max
    {
        get { return m_Max; }
        set { m_Max = value; }
    }

    /// <summary>
    /// Invoked when the slider's value changes
    /// </summary>
    public void OnSliderValueChanged()
    {
        if (slider != null)
            angle = slider.value * (max - min) + min;
    }

    float angle
    {
        get
        {
            return transform.eulerAngles.y;
        }
        set
        {
            transform.rotation = Quaternion.AngleAxis(value, Vector3.up);
        }
    }

    void OnEnable()
    {
        if (slider != null)
            slider.value = (angle - min) / (max - min);
    }
}
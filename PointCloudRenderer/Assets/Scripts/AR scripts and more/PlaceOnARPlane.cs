using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UnityEngine.XR.ARFoundation.Samples
{
    [RequireComponent(typeof(ARRaycastManager))]
    public class PlaceOnARPlane : MonoBehaviour
    {
        [SerializeField]
        Transform m_Content;

        public Transform content
        {
            get { return m_Content; }
            set { m_Content = value; }
        }

        void Awake()
        {
            m_RaycastManager = GetComponent<ARRaycastManager>();
        }

        //to not place AR content when pushing UI elements. Remember to include void Update()
        bool IsPointOverUIObject(Vector2 pos)
        {
            if (EventSystem.current.IsPointerOverGameObject())
                return false;

            PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
            eventDataCurrentPosition.position = new Vector2(pos.x, pos.y);
            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
            return results.Count > 0;
        }

        public Toggle uIRaycastToggle;

        private bool raycastToggle = false;

        public void ARPlacementToggle()
        {
            raycastToggle = !raycastToggle;
        }


        bool TryGetTouchPosition(out Vector2 touchPosition)
        {
#if UNITY_EDITOR
            if (Input.GetMouseButton(0))
            {
                var mousePosition = Input.mousePosition;
                touchPosition = new Vector2(mousePosition.x, mousePosition.y);
                return true;
            }
#else
            if (Input.touchCount > 0)
            {
                touchPosition = Input.GetTouch(0).position;
                return true;
            }
#endif

            touchPosition = default;
            return false;
        }

        void Update()
        {
            if (uIRaycastToggle.isOn == true)
            {
                if (!TryGetTouchPosition(out Vector2 touchPosition))
                    return;

                if (!IsPointOverUIObject(touchPosition) && m_RaycastManager.Raycast(touchPosition, s_Hits, TrackableType.PlaneWithinPolygon))
                {
                    // Raycast hits are sorted by distance, so the first one
                    // will be the closest hit.
                    var hitPose = s_Hits[0].pose;

                    content.position = hitPose.position;

                    uIRaycastToggle.isOn = false;
                }
            }
        }

        static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();

        ARRaycastManager m_RaycastManager;
    }
}
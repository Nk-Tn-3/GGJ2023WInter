using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;
namespace PlayerMovementNS
{
    public class CameraZoom : MonoBehaviour
    {
        [SerializeField] [Range(0, 20f)] private float defaultZoomDistance = 10f;
        [SerializeField] [Range(0, 20f)] private float minZoomDistance = 5f;
        [SerializeField] [Range(0, 20f)] private float maxZoomDistance = 20f;
        [SerializeField] [Range(0, 20f)] private float smoothing = 4f;
        [SerializeField] [Range(0, 20f)] private float zoomSensitivity = 1f;


        private CinemachineFramingTransposer framingTransposer;
        private CinemachineInputProvider inputProvider;

        private float currentTargetDistance;

        private void Awake()
        {
            framingTransposer = GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineFramingTransposer>();
            inputProvider = GetComponent<CinemachineInputProvider>();
            currentTargetDistance = defaultZoomDistance;
         
        }

        private void Update()
        {
            Zoom();
        }

        private void Zoom()
        {
            float zoomValue = inputProvider.GetAxisValue(2) * zoomSensitivity;


            currentTargetDistance = Mathf.Clamp(currentTargetDistance + zoomValue,minZoomDistance,maxZoomDistance);
            float currentDistance = framingTransposer.m_CameraDistance;


            if(currentDistance == currentTargetDistance)
            {
                return;

            }

            float lerpedZoomValue = Mathf.Lerp(currentDistance, currentTargetDistance, smoothing * Time.deltaTime);
            framingTransposer.m_CameraDistance = lerpedZoomValue;
            
        }
    }
}

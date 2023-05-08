using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

public class sCinemachineBrain : MonoBehaviour
{
    private CinemachineBrain brain;

    private CinemachineVirtualCamera actualCam;
    private CinemachineVirtualCamera lastCam;

    public Canvas dontAimCam;
    public Canvas aimCam;
    public Canvas dontAimCamc2;
    public Canvas aimCamc2;

    public GameObject dontAimCam1, dontAimCam2, aimCam1, aimCam2;

    public Image reticleAim, reticleDontAim, reticleAim2, reticleDontAim2;

    //public float yTrackCam = 1.5f;
    //public bool isKneel = false;

    public bool isInEnemy = false;

    private void Awake()
    {
        //DontDestroyOnLoad(this);
        brain = GetComponent<CinemachineBrain>();
    }

    private void Start()
    {
        lastCam = brain.ActiveVirtualCamera.VirtualCameraGameObject.GetComponent<CinemachineVirtualCamera>();
        //brain.ActiveVirtualCamera.VirtualCameraGameObject.GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineFramingTransposer>().m_TrackedObjectOffset.y = 1.5f;
        
    }

    private void Update()
    {
        //brain.ActiveVirtualCamera.VirtualCameraGameObject.GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineFramingTransposer>().m_TrackedObjectOffset.y = yTrackCam;
        if (isInEnemy == true)
        {
            reticleAim.color = Color.red;
            reticleDontAim.color = Color.red; 
            reticleAim2.color = Color.red;
            reticleDontAim2.color = Color.red;
        }
        else
        {
            reticleAim.color = Color.white;
            reticleDontAim.color = Color.white;
            reticleAim2.color = Color.white;
            reticleDontAim2.color = Color.white;
        }
        actualCam = brain.ActiveVirtualCamera.VirtualCameraGameObject.GetComponent<CinemachineVirtualCamera>();
    }

    public void OnAim(bool aim)
    {
        Debug.Log(actualCam.Name);
      
        if (aim == true)
        {
            dontAimCam.enabled = false;
            dontAimCamc2.enabled = false;
            aimCam.enabled = true;
            aimCamc2.enabled = true;
            lastCam = brain.ActiveVirtualCamera.VirtualCameraGameObject.GetComponent<CinemachineVirtualCamera>();
            actualCam.Priority = 8;
        }
        else if (aim == false)
        {
            dontAimCam.enabled = true;
            dontAimCamc2.enabled = true;
            aimCam.enabled = false;
            aimCamc2.enabled = false;
            lastCam.Priority = 10;
        }
    }
    public void kneel(bool isKneel)
    {
        if (isKneel == false)
        {
            dontAimCam1.SetActive(true);
            aimCam1.SetActive(true);
            dontAimCam2.SetActive(false);
            aimCam2.SetActive(false);
        }
        else
        {
            dontAimCam1.SetActive(false);
            aimCam1.SetActive(false);
            dontAimCam2.SetActive(true);
            aimCam2.SetActive(true);
        }
    }
    public void speed(float speed)
    {
        brain.ActiveVirtualCamera.VirtualCameraGameObject.GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachinePOV>().m_HorizontalAxis.m_MaxSpeed = speed;
        brain.ActiveVirtualCamera.VirtualCameraGameObject.GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.m_MaxSpeed = speed;

    }
}

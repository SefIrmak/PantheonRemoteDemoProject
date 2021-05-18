using UnityEngine;
using Cinemachine;

public class CinemachineSwitcher : MonoBehaviour
{
    private bool coreCamera = true; // The Boy Camera                          

    [SerializeField] private CinemachineVirtualCamera vcam1; // The Boy camera reference
    [SerializeField] private CinemachineVirtualCamera vcam2; // The Wall Camera reference

    public void SwitchPriority()
    {
        
        if (coreCamera)
        {
            vcam1.Priority = 0;
            vcam2.Priority = 1;
        }
        else
        {
            vcam1.Priority = 1;
            vcam2.Priority = 0;
        }
        coreCamera = !coreCamera;
    }
}

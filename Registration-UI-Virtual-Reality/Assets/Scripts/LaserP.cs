using UnityEngine;
using Valve.VR;


public class LaserP : MonoBehaviour
{
    public SteamVR_Input_Sources handType;
    public SteamVR_Behaviour_Pose controllerPose;
    public SteamVR_Action_Boolean teleportAction;
    public GameObject laserPrefab; // 1
    private GameObject laser; // 2
    private Transform laserTransform; // 3
    private Vector3 hitPoint; // 4
                              // 1
    public Transform cameraRigTransform;
    // 2
    public GameObject teleportReticlePrefab;
    // 3
    private GameObject reticle;
    // 4
    private Transform teleportReticleTransform;
    // 5
    public Transform headTransform;
    // 6
    public Vector3 teleportReticleOffset;
    // 7
    public LayerMask teleportMask;
    public LayerMask inspectMask;
    // 8
    private bool shouldTeleport;

    public GameObject testObject;



    // Start is called before the first frame update
    void Start()
    {
        // 1
        laser = Instantiate(laserPrefab);
        // 2
        laserTransform = laser.transform;

        // 1
        reticle = Instantiate(teleportReticlePrefab);
        reticle.transform.eulerAngles = new Vector3(
        0f,
        this.transform.eulerAngles.z,
        0f
        );
        // 2
        teleportReticleTransform = reticle.transform;


    }

    // Update is called once per frame
    void Update()
    {
        RotateEqually(ref reticle);
        Debug.Log("Controller (right) z rotation: " + this.transform.eulerAngles.z);
        Debug.Log("reticle y rotation: " + reticle.transform.eulerAngles.y);
        Debug.Log("camera rig y rotation : " + cameraRigTransform.eulerAngles.y);
        // 1
        if (teleportAction.GetState(handType))
        {
            RaycastHit hit;
            // 2
            if (Physics.Raycast(controllerPose.transform.position, transform.forward, out hit, 100, teleportMask))

            {
                hitPoint = hit.point;
                ShowLaser(hit);
                // 1
                reticle.SetActive(true);
                // 2
                teleportReticleTransform.position = hitPoint + teleportReticleOffset;
                // 3
                shouldTeleport = true;

            }
            if (Physics.Raycast(controllerPose.transform.position, transform.forward, out hit, 10, inspectMask))

            {
                hitPoint = hit.point;
                //ShowLaser(hit);
                // 1
                reticle.SetActive(false);
                // 2
                teleportReticleTransform.position = hitPoint + teleportReticleOffset;
                // 3
                shouldTeleport = false;

            }

        }
        else // 3
        {
            laser.SetActive(false);
            reticle.SetActive(false);
        }


        if (teleportAction.GetStateUp(handType) && shouldTeleport)
        {
            Teleport();
        }

       


    }
    private void ShowLaser(RaycastHit hit)
    {
        // 1
        laser.SetActive(true);
        // 2
        laserTransform.position = Vector3.Lerp(controllerPose.transform.position, hitPoint, .5f);
        // 3
        laserTransform.LookAt(hitPoint);
        // 4
        laserTransform.localScale = new Vector3(laserTransform.localScale.x,
                                                laserTransform.localScale.y,
                                                hit.distance);
    }

    private void Teleport()
    {
        // 1
        shouldTeleport = false;
        // 2
        reticle.SetActive(false);
        // 3
        Vector3 difference = cameraRigTransform.position - headTransform.position;
        // 4
        difference.y = 0;
        // 5
        cameraRigTransform.position = hitPoint + difference;
        //cameraRigTransform.eulerAngles = new Vector3(
        //   0f,
        //    reticle.transform.eulerAngles.z,
        //  0f
        //    );
    }

    private void RotateEqually(ref GameObject reticle)
    {
        reticle.transform.eulerAngles = new Vector3(
        90f,
        this.transform.eulerAngles.y,
        this.transform.eulerAngles.z
        );
    }


}

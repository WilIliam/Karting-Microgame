/*
* Create by William (c)
* https://github.com/Long18
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public struct GhostTransform
{
    public Vector3 position;
    public Quaternion rotation;

    public GhostTransform(Transform transform)
    {
        this.position = transform.position;
        this.rotation = transform.rotation;
    }
}

public class GhostManager : MonoBehaviour
{

    #region Variables

    public Transform kart;
    public Transform ghostKart;
    public Transform cameraPlaceholder;
    public CinemachineVirtualCamera cinemaCam;
    #endregion
    public bool recording;
    public bool playing;
    public bool isGhostEnd;
    private bool isRecordingStarted;

    private List<GhostTransform> recordedGhostTransforms = new List<GhostTransform>();
    private GhostTransform lastRecordedGhostTransform;


    #region Unity Mehods

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (recording && !isRecordingStarted)
        {
            isRecordingStarted = true;
            StartCoroutine(StartRecording());
        }

        if (playing == true)
        {
            Play();
        }
    }


    #endregion

    #region Class


    void Play()
    {
        ghostKart.gameObject.SetActive(true);
        StartCoroutine(StartGhost());

        cinemaCam.LookAt = cameraPlaceholder;
        cinemaCam.Follow = cameraPlaceholder;

        playing = false;
    }

    IEnumerator StartGhost()
    {
        for (int i = 0; i < recordedGhostTransforms.Count; i++)
        {
            ghostKart.position = recordedGhostTransforms[i].position;
            ghostKart.rotation = recordedGhostTransforms[i].rotation;
            yield return new WaitForSeconds(0.01F);
        }

        isGhostEnd = true;
    }

    IEnumerator StartRecording()
    {
        while (recording)
        {
            if (kart.position != lastRecordedGhostTransform.position || kart.rotation != lastRecordedGhostTransform.rotation)
            {
                var newGhostTransform = new GhostTransform(kart);
                recordedGhostTransforms.Add(newGhostTransform);

                lastRecordedGhostTransform = newGhostTransform;
            }
            yield return new WaitForSeconds(0.01F);
        }

        isRecordingStarted = false;
    }
    #endregion
}

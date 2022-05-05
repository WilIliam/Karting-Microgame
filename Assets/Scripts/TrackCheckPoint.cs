/*
* Create by William (c)
* https://github.com/Long18
*/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TrackCheckPoint : MonoBehaviour
{

    #region Variables

    public event EventHandler OnPlayerCorrectCP;
    public event EventHandler OnPlayerWrongCP;
    [SerializeField]
    private List<Transform> m_PlayerTransformList;
    private List<SingleCheckPoint> m_CheckPointList;
    private List<int> m_NextIndexList;
    [SerializeField]
    private GameObject m_Player;
    private Vector3 m_PlayerPosition;
    private Quaternion m_PlayerRotation;
    #endregion

    #region Unity Mehods

    // Start is called before the first frame update
    private void Awake()
    {
        Transform checkpointTransform = transform.Find("Trainning");
        m_CheckPointList = new List<SingleCheckPoint>();

        foreach (Transform child in checkpointTransform)
        {
            SingleCheckPoint singleCheckPoint = child.GetComponent<SingleCheckPoint>();
            singleCheckPoint.SetTrackCP(this);

            m_CheckPointList.Add(singleCheckPoint);
        }

        m_NextIndexList = new List<int>();
        foreach (Transform child in m_PlayerTransformList)
        {
            m_NextIndexList.Add(0);
        }
    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Click back");
            StartCoroutine(BackToTheRoadCoroutine());

        }
    }


    #endregion

    #region Class
    public void GoingThroughCheckPoint(SingleCheckPoint singleCheckPoint, Transform resetPointTransform)
    {
        int index = m_NextIndexList[m_PlayerTransformList.IndexOf(resetPointTransform)];
        // Debug.Log(checkPointsList.IndexOf(singleCheckPoint) + " " + singleCheckPoint.transform.position);
        // Debug.Log(m_PlayerTransformList.IndexOf(playerTransform));
        if (m_CheckPointList.IndexOf(singleCheckPoint) == index)
        {
            // nextIndexCP++;
            Debug.Log("Correct CheckPoint");

            m_PlayerPosition = resetPointTransform.position;
            m_PlayerRotation = resetPointTransform.rotation;

            SingleCheckPoint correctCPSingle = m_CheckPointList[index];
            correctCPSingle.Hide();

            m_NextIndexList[m_PlayerTransformList.IndexOf(resetPointTransform)]
                = (index + 1) % m_CheckPointList.Count;
            OnPlayerCorrectCP?.Invoke(this, EventArgs.Empty);
        }
        else
        {

            Debug.Log("Wrong CheckPoint");
            OnPlayerWrongCP?.Invoke(this, EventArgs.Empty);

            TurnBack();

            SingleCheckPoint correctCPSingle = m_CheckPointList[index];
            correctCPSingle.Show();
        }
    }

    IEnumerator BackToTheRoadCoroutine()
    {
        yield return new WaitForSeconds(.1f);
        TurnBack();
        Debug.Log("back to the road");
    }

    public void TurnBack()
    {
        m_Player.GetComponent<Rigidbody>().velocity = Vector3.zero;

        if (m_CheckPointList != null)
        {
            m_Player.transform.position = m_PlayerPosition;
            m_Player.transform.rotation = m_PlayerRotation;
        }
        else
        {
            m_Player.transform.position = new Vector3(14.22f, 0.91f, -65.93f);
            m_Player.transform.rotation = new Quaternion(0, -24.697f, 0, 0);
        }
    }
    #endregion
}

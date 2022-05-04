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


    #endregion

    #region Class
    public void GoingThroughCheckPoint(SingleCheckPoint singleCheckPoint, Transform playerTransform)
    {
        int index = m_NextIndexList[m_PlayerTransformList.IndexOf(playerTransform)];
        // Debug.Log(checkPointsList.IndexOf(singleCheckPoint) + " " + singleCheckPoint.transform.position);
        // Debug.Log(m_PlayerTransformList.IndexOf(playerTransform));
        if (m_CheckPointList.IndexOf(singleCheckPoint) == index)
        {
            // nextIndexCP++;
            Debug.Log("Correct CheckPoint");
            SingleCheckPoint correctCPSingle = m_CheckPointList[index];
            correctCPSingle.Hide();

            m_NextIndexList[m_PlayerTransformList.IndexOf(playerTransform)]
                = (index + 1) % m_CheckPointList.Count;
            OnPlayerCorrectCP?.Invoke(this, EventArgs.Empty);
        }
        else
        {
            Debug.Log("Wrong CheckPoint");
            OnPlayerWrongCP?.Invoke(this, EventArgs.Empty);

            SingleCheckPoint correctCPSingle = m_CheckPointList[index];
            correctCPSingle.Show();
        }
    }
    #endregion
}

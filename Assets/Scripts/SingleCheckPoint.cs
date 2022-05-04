/*
* Create by William (c)
* https://github.com/Long18
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SingleCheckPoint : MonoBehaviour
{

    #region Variables

    private TrackCheckPoint trackCheckPoint;
    private MeshRenderer meshRenderer;
    #endregion

    #region Unity Mehods

    private void Start()
    {
        // Hide();
    }

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    public void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            Debug.Log(this, other.transform);
            trackCheckPoint.GoingThroughCheckPoint(this,other.transform);
        }


    }


    #endregion

    #region Class

    public void SetTrackCP(TrackCheckPoint trackCheckPoint)
    {
        this.trackCheckPoint = trackCheckPoint;
    }

    public void Show()
    {
        meshRenderer.enabled = true;
    }

    public void Hide()
    {
        meshRenderer.enabled = false;
    }
    #endregion
}

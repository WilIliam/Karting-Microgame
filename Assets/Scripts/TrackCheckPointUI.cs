/*
* Create by William (c)
* https://github.com/Long18
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TrackCheckPointUI : MonoBehaviour
{

    #region Variables

    [SerializeField]
    private TrackCheckPoint checkpoint;

    #endregion

    #region Unity Mehods

    private void Start()
    {
        checkpoint.OnPlayerCorrectCP += TrackCheckPoint_OnPlayerCorrectCP;
        checkpoint.OnPlayerWrongCP += TrackCheckPoint_OnPlayerWrongCP;

        Hide();
    }
    #endregion

    #region Class

    private void TrackCheckPoint_OnPlayerCorrectCP(object sender, System.EventArgs e)
    {
        Hide();
    }

    private void TrackCheckPoint_OnPlayerWrongCP(object sender, System.EventArgs e)
    {
        Show();
    }

    private void Show()
    {
        gameObject.SetActive(true);
        StartCoroutine(WaitToTurnOff());
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
    IEnumerator WaitToTurnOff()
    {
        yield return new WaitForSeconds(1f);
        Hide();
    }
    #endregion
}

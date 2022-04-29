/*
* Create by William (c)
* https://github.com/Long18
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunRotate : MonoBehaviour
{

    #region Variables

    public GameObject sun;
    public Light sunLight;

    [Range(0, 6)]
    public float timeOfDay = 6;

    public float secondsPerMinute = 60;
    [HideInInspector]
    public float secondsPerHour;
    [HideInInspector]
    public float secondsPerDay;

    public float timeMultiplier = 1000;
    #endregion

    #region Unity Mehods

    // Start is called before the first frame update
    void Start()
    {
        sun = gameObject;
        sunLight = gameObject.GetComponent<Light>();

        secondsPerHour = secondsPerMinute * 60;
        secondsPerDay = secondsPerHour * 24;
    }

    // Update is called once per frame
    void Update()
    {
        SunUpdate();

        timeOfDay += ((Time.deltaTime + 2) / secondsPerDay) * timeMultiplier;

        if (timeOfDay >= 6)
        {
            timeOfDay = 0;
        }
    }


    #endregion

    #region Class
    public void SunUpdate()
    {
        sun.transform.localRotation = Quaternion.Euler(timeOfDay * 360 * timeMultiplier + 1, 0, 0);
    }
    #endregion
}

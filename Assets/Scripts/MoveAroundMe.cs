/*
* Create by William (c)
* https://github.com/Long18
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAroundMe : MonoBehaviour
{

    #region Variables

    float timeCount = 0;
    float timeRotate = 25;

    public GameObject birdOne;
    public GameObject birdTwo;
    public GameObject birdThree;
    public GameObject birdFour;
    public GameObject moutainLight;
    #endregion

    #region Unity Mehods

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timeCount += Time.deltaTime;

        float x = Mathf.Cos(timeCount) * 50f;
        float y = 22;
        float z = Mathf.Sin(timeCount);

        birdOne.transform.position = new Vector3(x * Random.Range(1, 3), y, z * Random.Range(1, 2));
        birdTwo.transform.position = new Vector3(x * Random.Range(1, 3), y, z * Random.Range(1, 2));
        birdThree.transform.position = new Vector3(x * Random.Range(1, 3), y, z * Random.Range(1, 2));
        birdFour.transform.position = new Vector3(x * Random.Range(1, 3), y, z * Random.Range(1, 2));

        moutainLight.transform.position = new Vector3(x * Random.Range(1, 3) * 20, y, z * Random.Range(1, 2));

        birdOne.transform.localRotation = Quaternion.Euler(0, timeCount * timeRotate, 0);
        birdTwo.transform.localRotation = Quaternion.Euler(0, timeCount * timeRotate, 0);
        birdThree.transform.localRotation = Quaternion.Euler(0, timeCount * timeRotate, 0);
        birdFour.transform.localRotation = Quaternion.Euler(0, timeCount * timeRotate, 0);

    }


    #endregion

    #region Class

    #endregion
}

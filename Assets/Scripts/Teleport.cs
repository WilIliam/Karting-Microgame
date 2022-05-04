/*
* Create by William (c)
* https://github.com/Long18
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{

    #region Variables

    public GameObject player;
    public ParticleSystem particalSpawn;
    public GameObject lightSpawn;

    bool isTouch = false;
    #endregion

    #region Unity Mehods

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Player" && isTouch == false) {
            lightSpawn.SetActive(true);
            particalSpawn.Play();
            player.transform.position = new Vector3(9.6f, 0.91f, -55.87f);
            player.transform.rotation = Quaternion.Euler(0, -44.4227f,0);
            isTouch = true;
            lightSpawn.SetActive(false);
        }
    }

    #endregion

    #region Class

    #endregion
}

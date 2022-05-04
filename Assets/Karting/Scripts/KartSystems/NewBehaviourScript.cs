/*
* Create by William (c)
* https://github.com/Long18
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    #region Variables

    #endregion
        
    #region Unity Mehods
    List<A> list = new List<A>();
    // Start is called before the first frame update
    void Start()
    {
        A a1 = new A(1,"1");
        A a2 = new A(2,"2");
        list.Add(a1);
        list.Add(a2);
        debugFunc(a2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void debugFunc( A input){
        Debug.Log("result: "+ list.IndexOf(input));

    }


    
    #endregion

    #region Class

    #endregion
}

class A{
        public int value;
        public string valueb;

        public A(int value, string valueb){
            this.value = value;
            this.valueb = valueb;
        }
}

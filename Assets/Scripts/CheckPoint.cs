using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{

    private bool taked = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool IsTaked() {
        return taked;
    }

    public void Take() {
        if (!taked) {
            taked = true;
            GetComponent<Animator>().SetTrigger("take");
        }
    }
}

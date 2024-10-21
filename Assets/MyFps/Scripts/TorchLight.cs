using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class TorchLight : MonoBehaviour

{
    public Animator animator;
    public Transform torchLight;
    public int lightMode = 0;
    public int getlightMode = 0;
    // Start is called before the first frame update

    void Start()
    {
        animator = torchLight.GetComponent<Animator>();
        InvokeRepeating("LightAnimation", 0f, 1f);
    }


    void Update()
    {
        //if (lightMode == 0)
        //{
        //    StartCoroutine(FlameAnimation());
        //    int num = animator.GetParameter(0).defaultInt;
        //    Debug.Log(num);

        //}

    }

    void LightAnimation()
    {
        lightMode = Random.Range(1, 4);
        getlightMode = animator.GetInteger("LightMode");
        //이전값이랑 동일하면 리턴

        animator.SetInteger("LightMode", lightMode);
        //Debug.Log($"lightMode={lightMode}");

        //Debug.Log($"defaultInt={animator.GetParameter(0).defaultInt}");
    }
    //IEnumerator FlameAnimation()
    //{

    //    lightMode = Random.Range(1, 4);

    //    animator.SetInteger("LightMode", lightMode);
    //    //Debug.Log(random);
    //    yield return new WaitForSeconds(1.0f);

    //    lightMode = 0;
    //}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unity_chan : MonoBehaviour
{
    //皮肤渲染
    private SkinnedMeshRenderer _mSkinnedMeshRenderer;

    // Start is called before the first frame update
    void Start()
    {
        //获取组件
        _mSkinnedMeshRenderer = GameObject.Find("hair_frontside").GetComponent<SkinnedMeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //改变颜色，这里使用了Color.Lerp()一个颜色的渐变
        _mSkinnedMeshRenderer.material.color = Color.blue;
            
        print(_mSkinnedMeshRenderer.material.color);
    }

}

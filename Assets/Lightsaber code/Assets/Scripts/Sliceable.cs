using System.Collections;
using System.Collections.Generic;
using System.Security.AccessControl;
using UnityEngine;

public class Sliceable : MonoBehaviour
{
    [SerializeField]
    private bool _isSolid = true;

    [SerializeField]
    private bool _reverseWindTriangles = false;

    [SerializeField]
    private bool _useGravity = false;

    [SerializeField]
    private bool _shareVertices = false;

    [SerializeField]
    private bool _smoothVertices = false;

    bool hasBeenCut = false;
    public bool beingCut = false;
    public bool cuttingDisabled = true;
    float timer = 0;

    public void cut()
    {
        if(!hasBeenCut && !cuttingDisabled)
        {
            beingCut = true;
        }
    }

    public void endCut()
    {
        beingCut = false;
    }
    
    void Start()
    {

    }

    void Update()
    {
        if (cuttingDisabled)
        {
            timer += Time.deltaTime;
            if (timer > 0.1)
            {
                cuttingDisabled = false;
            }
        }
    }

    public bool IsSolid
    {
        get
        {
            return _isSolid;
        }
        set
        {
            _isSolid = value;
        }
    }

    public bool ReverseWireTriangles
    {
        get
        {
            return _reverseWindTriangles;
        }
        set
        {
            _reverseWindTriangles = value;
        }
    }

    public bool UseGravity 
    {
        get
        {
            return _useGravity;
        }
        set
        {
            _useGravity = value;
        }
    }

    public bool ShareVertices 
    {
        get
        {
            return _shareVertices;
        }
        set
        {
            _shareVertices = value;
        }
    }

    public bool SmoothVertices 
    {
        get
        {
            return _smoothVertices;
        }
        set
        {
            _smoothVertices = value;
        }
    }

}

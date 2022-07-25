using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blade : MonoBehaviour
{
    int index;
    Transform parent;
    Transform root;
    Transform parentNextSibling;

    // Start is called before the first frame update
    void Start()
    {
        index = transform.parent.GetSiblingIndex();
        root = transform.root;
        parent = transform.parent;
        parentNextSibling = root.GetChild(index + 1);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 midpoint = new Vector3((parent.position.x + parentNextSibling.position.x) / 2, (parent.position.y + parentNextSibling.position.y) / 2, (parent.position.z + parentNextSibling.position.z) / 2);
        transform.position = midpoint;
        transform.localScale = new Vector3(0.01f, 0.01f, Vector3.Distance(parent.position, parentNextSibling.position) / 2);
        transform.LookAt(parent);
    }
}

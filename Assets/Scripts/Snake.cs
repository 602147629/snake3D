using UnityEngine;
using System.Collections.Generic;

public class Snake : MonoBehaviour {
    public List<SnakeNode> nodeList;
    public float moveSpeed;
    public float angularSpeed;

    private Vector3 oldPos;
    // Use this for initialization
    void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Vector3 hitPoint = Vector3.zero;
        if (Physics.Raycast(ray, out hit, 1000, 1 << LayerMask.NameToLayer("floor")))
        {
            hitPoint = hit.point;
            hitPoint.y = transform.position.y;
            transform.LookAt(hitPoint);
        }
        Debug.DrawLine(hitPoint, transform.position, Color.red);
        oldPos = transform.position;
        transform.Translate(transform.forward * moveSpeed * Time.deltaTime,Space.World);
        Vector3 deltaPos = transform.position - oldPos;
	}

    void LateUpdate()
    {
        Move(Time.deltaTime);
    }

    void Move(float deltaTime)
    {
        nodeList[1].Move(deltaTime,transform);
    }
}

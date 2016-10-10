using UnityEngine;
using System.Collections;

public class SnakeNode{
    public Transform self { get; set; }
    public SnakeNode nextNode { get; set; }

    private Vector3 oldPos;
    public SnakeNode(Transform target)
    {
        self = target;
    }
    private float deltaTime;
    private Transform target;
    public void Move(float deltaTime,Transform target)
    {
        this.deltaTime = deltaTime;
        this.target = target;
        if (Vector3.Distance(self.position, target.position) > 0.8f)
        {
            self.transform.Translate(self.transform.forward * Game.speed * Time.deltaTime, Space.World);
        }
        else
        {
            self.transform.Translate(self.transform.forward * Game.speed * Time.deltaTime *0.3f, Space.World);
        }
        //if(Vector3.Distance(self.position,target.position) < 0.4f)
        //{
        //    self.transform.Translate(-self.transform.forward * Game.speed * Time.deltaTime, Space.World);
        //}
        self.LookAt(target);
        if (null != nextNode)
        {
            nextNode.Move(deltaTime, self);
        }
    }
}

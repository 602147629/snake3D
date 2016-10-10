using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Game : MonoBehaviour {
    public static Game Instance = null;
    public const float speed = 7;

    void Awake()
    {
        Instance = this;
    }
	// Use this for initialization
	void Start () {
        Game.SpawnSnake(30);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private System.Action action;
    public void StartCoroutineByGame(System.Action action,float time)
    {
        this.action = action;
        StartCoroutine("Coroutine",time);
    }

    IEnumerator Coroutine(object time)
    {
        yield return new WaitForSeconds((float)time);
        action.Invoke();
    }

    public static void SpawnSnake(uint length)
    {
        List<SnakeNode> nodes = new List<SnakeNode>();
        Transform headRes = Resources.Load<Transform>("Head");
        Transform head = Instantiate<Transform>(headRes);
        head.position = Vector3.zero;
        head.rotation = Quaternion.identity;
        CameraController.Instance.InitCamPos(head);
        SnakeNode headNode = new SnakeNode(head);
        nodes.Add(headNode);
        SnakeNode curNode = headNode;
        for (int i = 0; i < length; i++)
        {
            Transform bodyRes = Resources.Load<Transform>("Body");
            Transform body = Instantiate<Transform>(bodyRes);
            SnakeNode node = new SnakeNode(body);
            nodes.Add(node);
            curNode.nextNode = node;
            node.self.position = curNode.self.position - new Vector3(0,0,0.5f);
            curNode = node;
        }
        Transform tailRes = Resources.Load<Transform>("Tail");
        Transform tail = Instantiate<Transform>(tailRes);
        SnakeNode tailNode = new SnakeNode(tail);
        nodes.Add(tailNode);
        curNode.nextNode = tailNode;
        tailNode.self.position = curNode.self.position - new Vector3(0, 0, 0.5f);
        curNode = null;
        Snake snake = head.gameObject.AddComponent<Snake>();
        snake.nodeList = nodes;
        snake.moveSpeed =speed + 0.01f;
    }
}

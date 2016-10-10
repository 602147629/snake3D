using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
    public enum ViewType
    {
        Top,
        Bie45
    }
    public static CameraController Instance = null;
    public Transform target;
    public ViewType viewType;
    public float distance;

    private Vector3 lastTgtPos;
    private bool inited;
    void Awake()
    {
        Instance = this;
    }
    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void LateUpdate () {
        if (!inited) return;
        Vector3 deltaPos = target.position - lastTgtPos;
        Camera.main.transform.position += deltaPos;
        lastTgtPos = target.position;
    }


    public void InitCamPos(Transform target)
    {
        this.target = target;
        lastTgtPos = target.position;
        Vector3 camPos = target.rotation * Vector3.up * distance + target.position;
        Camera.main.transform.position = camPos ;
        Camera.main.transform.LookAt(target);
        inited = true;
    }
}

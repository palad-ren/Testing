using UnityEngine;
using System.Collections.Generic;
using System;

public class CameraController : MonoBehaviour
{
    private List<GameObject> Cameras = new List<GameObject>();

    public GameObject target;
    public int mode;
    public float scrollSpeed = 10f;
    public float scrollLimit = 100f;
    void Start()
    {
        foreach (Transform child in transform)
        {
            Cameras.Add(child.gameObject);
        }
    }

    void Update()
    {
        
            
    }
    public void Zoom(float direction)
    {
        this.transform.Translate(0, 0, Time.deltaTime * scrollSpeed * direction);
        var zom = this.transform.position.z + 7.5f;
        var xoom = ((zom * 6) / 100);
        Debug.Log("Z = " + this.transform.position.z + "; z = " + xoom + ", " + xoom + " %");
    }
    public void ChangeMode(int mode)
    {
        if (mode == 1)
        {
            this.transform.LookAt(target.transform);
            this.transform.position = target.transform.position + new Vector3(0, 7.5f, -7.5f);
            this.transform.SetParent(target.transform);
        }
        if(mode == 2)
        {
            this.transform.SetParent(null);
        }
    }
    public void ChangeTarget(GameObject gameObject)
    {
        target = gameObject;
    }

    public void ChangeActiveCamera(int index)
    {
        foreach(var cam in Cameras)
        {
            if (Cameras[index] == cam)
                cam.SetActive(true);
            else
                cam.SetActive(false);
        }
    }
}

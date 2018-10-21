using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Visualization{

public class Link : MonoBehaviour {

    public string id;
    //public Node source;
    //public Node target;
    public GameObject source; 
    public GameObject target; 
    public string sourceId;
    public string targetId;
    public string status;
    public bool loaded = false;
    public float distance; 

    public LineRenderer lineRenderer;

	// Use this for initialization
    
	void Start () {
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        Debug.Log("lineRenderer: " + lineRenderer); 

        //draw line
        //lineRenderer.material = new Material(Shader.Find("Self-Illumin/Diffuse"));
        lineRenderer.material.color = Color.white;  
        lineRenderer.SetWidth(0.1f, 0.1f);
        //lineRenderer.SetVertexCount(2); //how would I change this for a bipartite graph?
        //lineRenderer.SetPosition(0, new Vector3(0, 0, 0));
        //lineRenderer.SetPosition(1, new Vector3(1, 0, 0));
        lineRenderer.SetPosition(0, source.transform.position); 
        lineRenderer.SetPosition(1, target.transform.position); 
        //distance = Vector3.Distance(source.position, target.position); 
		
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("update is being called"); 
        if(source && target && !loaded)
        {
            Debug.Log("inside if of update in Link.cs"); 
            //draw links as full duplex, half in each direction
            //Vector3 m = (target.transform.position - source.transform.position) / 2 + source.transform.position;
            Vector3 m = target.transform.position-source.transform.position;
            Debug.Log("printing m: " + m); 
            lineRenderer.SetPosition(0, source.transform.position);
            lineRenderer.SetPosition(1, m);
            loaded = true; 
        }
		
	}
    
}
}
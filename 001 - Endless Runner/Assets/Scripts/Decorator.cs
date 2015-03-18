using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Decorator : MonoBehaviour {

	public List<DecorationInfo> Ground = new List<DecorationInfo>();
	public List<DecorationInfo> Layer1 = new List<DecorationInfo>();
	public List<DecorationInfo> Layer2 = new List<DecorationInfo>();
	public List<DecorationInfo> Layer3 = new List<DecorationInfo>();
	public List<DecorationInfo> Obstacles = new List<DecorationInfo>();


	public GameObject BackgroundContainer;
	public int initilalSize=3;


	Camera mainCamera;
	float currentPosition;
	float groundTileWidth;

	void Start () {
		mainCamera = Camera.main;
		groundTileWidth = Ground [0].Prefab.GetComponent<Renderer>().bounds.size.x;


		InitLevel ();
	}

	void Update()
	{
		float cameraX = Camera.main.ScreenToWorldPoint (new Vector3 (Screen.width, 0, 0)).x;

		if (cameraX+groundTileWidth>currentPosition) 
		{
			CreateNewTile ();
		}
	}

	void InitLevel ()
	{
		currentPosition = 0;
		for (int i = 0; i < initilalSize; i++) {
			CreateNewTile ();
		}
	}

	void CreateNewTile ()
	{
		var obj = Instantiate (Ground [0].Prefab, new Vector3 (currentPosition, 0, 0), Quaternion.identity) as GameObject;
		obj.transform.parent = BackgroundContainer.transform;
		currentPosition += groundTileWidth - 0.1f;
		InstantiateLayerDecorations (Layer1);
		InstantiateLayerDecorations (Layer2);
		InstantiateLayerDecorations (Layer3);
		InstantiateLayerDecorations (Obstacles);
	}

	void InstantiateLayerDecorations (List<DecorationInfo> layer)
	{
		var position = currentPosition - groundTileWidth;
		
		for (int prefabIdx=0; prefabIdx<layer.Count; prefabIdx++) 
			for (int j=0;j<Random.Range(0,layer [prefabIdx].Frequency);j++)
			{
				float width = layer [prefabIdx].Prefab.GetComponent<Renderer>().bounds.size.x;	
				float minx = position+width/2;
				float maxx = currentPosition-width/2;
				var xPos = Random.Range(minx,maxx);
				var yPos = layer [prefabIdx].Offset.y;
				var obj = Instantiate (layer [prefabIdx].Prefab, new Vector3 (xPos, yPos, 0), Quaternion.identity) as GameObject;
				obj.transform.parent = BackgroundContainer.transform;
			}
	}

	public void ResetLevel()
	{
		foreach (Transform child in BackgroundContainer.transform) 
		{
			Destroy(child.gameObject);
		}

		InitLevel ();
	}
	
}

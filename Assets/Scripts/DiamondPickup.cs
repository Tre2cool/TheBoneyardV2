using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondPickup : MonoBehaviour
{
     public static DiamondPickup Instance = null;

	[SerializeField] GameObject diamondPrefab;

    [SerializeField] float xPosition;

    [SerializeField] float yPosition;

	void Awake()
	{
		if (Instance == null) 
			Instance = this;
		else if (Instance != this)
			Destroy (gameObject);
		
	}
	// Use this for initialization
	void Start () {
		
	}

    public void SpawnDiamond(){
        Instantiate (diamondPrefab, new Vector2 (xPosition, yPosition),diamondPrefab.transform.rotation);
    }


}

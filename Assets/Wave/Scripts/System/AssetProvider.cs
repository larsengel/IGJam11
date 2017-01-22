using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System;

public class AssetProvider : MonoBehaviour
{

	public event System.Action<GameObject> OnAssetLoaded = (rootObjectJustLoaded) => {};

	Dictionary<string, List<GameObject>> RegisteredAssets = new Dictionary<string, List<GameObject>> ();

	public void LoadAssetAsync (string assetId)
	{
		StartCoroutine (LoadAsset (assetId)); 
	}

	public IEnumerator LoadAsset (string assetId)
	{
		yield return SceneManager.LoadSceneAsync (assetId, LoadSceneMode.Additive); 
		var scene = SceneManager.GetSceneByName (assetId);

		// TODO check if isLoaded is really false for scenes we have had already loaded
		if (scene.IsValid ()) {

			// enforces the game convention to have a GO under a SceneContext with the same name as the scene

			if (scene.isLoaded) {
				var sceneObjects = scene.GetRootGameObjects ();

				var rootObject = sceneObjects [0];
				if (rootObject.name != assetId) {
					throw new Exception ("AssetProvider: Please name your scene rootObject and scene file the same: " + assetId);
				}

				RegisterAsset (rootObject);
			}

		}
	}

	public void RegisterAsset (GameObject rootObject)
	{
		if (!RegisteredAssets.ContainsKey (rootObject.name)) {
			RegisteredAssets.Add (rootObject.name, new List<GameObject> ()); 
		}
		RegisteredAssets [rootObject.name].Add (rootObject); 

		OnAssetLoaded (rootObject); 
	}

	public void UnloadAsset (string id)
	{
		StartCoroutine (Co_UnloadAssets (id)); 
	}

	IEnumerator Co_UnloadAssets (string id)
	{
		// we need to wait one frame since it could be that this unload was triggered 
		// by an physic event - and there is a bug in Unity that makes unity hang then 
		yield return new WaitForEndOfFrame (); 
       
		if (RegisteredAssets.ContainsKey (id)) {
			for (int i = 0, maxCount = this.RegisteredAssets [id].Count; i < maxCount; i++) {
				GameObject asset = this.RegisteredAssets [id] [i];
				SceneManager.UnloadSceneAsync (asset.name);
			}
			RegisteredAssets [id].Clear (); 
		}
	}

	public GameObject GetFirstAsset (string id)
	{
		if (!RegisteredAssets.ContainsKey (id)) {
			throw new Exception ("Asset " + id + " not registered in AssetProvider");
		}
		return RegisteredAssets [id] [0];
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ReloadCar : MonoBehaviour {
    public GameObject carPrefab;
    public GameObject tempCar;
    GameObject currentCar;
    
    // Use this for initialization
    void Start () {
	}

	public void reloadCar()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        //currentCar = GameObject.FindGameObjectWithTag("AnimatedCar");
        //Destroy(currentCar);
        //GameObject objInstance = Instantiate(tempCar);
        //currentCar = objInstance;

        //Instantiate(carPrefab, pos, Quaternion.identity);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class roomGen : MonoBehaviour
{
    public string currentScene;
    public string nextScene;
    public string pastScene;

    public string[] roomList; 

    private GameObject landingPad;
    private GameObject player;
    private GameObject teleporter;
    private GameObject placeHolder;

    public BoxCollider2D port;

    public float armTime = 2f;
    public float armTimer;

    // private AsyncOperation sceneAsync;

    private void Start() {
        // Have to get the first room for the player
        var nextSceneNum = Random.Range(0, roomList.Length);
        nextScene = roomList[nextSceneNum];
        armTimer = Time.time + armTime;
    }

    private void Update() {
        if (armTimer <= Time.time) {
            port.enabled = true;
        }
    }

    IEnumerator loadScene(Scene scene){
        SceneManager.LoadScene(nextScene, LoadSceneMode.Additive);
        var i = 0;
        while (!scene.isLoaded)
        {   
            yield return new WaitForSeconds(0.1f);
            Debug.Log(i);
            try{
                SceneManager.SetActiveScene(SceneManager.GetSceneByName(nextScene));
                landingPad = GameObject.FindGameObjectWithTag("landingPad");
                player = GameObject.FindGameObjectWithTag("Player");
                teleporter = GameObject.FindGameObjectWithTag("Teleporter");
                placeHolder = GameObject.FindGameObjectWithTag("TeleporterPlaceHolder");
                player.transform.position = landingPad.transform.position;
                teleporter.transform.position = placeHolder.transform.position;
                SceneManager.MoveGameObjectToScene(teleporter, SceneManager.GetSceneByName(nextScene));
                SceneManager.MoveGameObjectToScene(player, SceneManager.GetSceneByName(nextScene));
                Destroy(placeHolder);
                SceneManager.UnloadSceneAsync(currentScene);
                pastScene = currentScene;
                currentScene = SceneManager.GetActiveScene().name;
                var nextSceneNum = Random.Range(0, roomList.Length);
                nextScene = roomList[nextSceneNum];
                while(nextScene == pastScene && nextScene == currentScene){
                    nextSceneNum = Random.Range(0, roomList.Length);
                    nextScene = roomList[nextSceneNum];
                    Debug.Log(nextScene);
                }
            } catch{
                Debug.Log("error");
            }
            
            i++;
            Debug.Log("DOWQN");
        }
        
        Debug.Log("Out of loop");
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")){
            Debug.Log("Hitting the tp");
            StartCoroutine(loadScene(SceneManager.GetSceneByName(nextScene)));
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class roomGen : MonoBehaviour
{
    #pragma warning disable
    public string currentScene;
    public string nextScene;
    public string pastScene;

    public string[] roomList; 

    private GameObject landingPad;
    private GameObject player;
    private GameObject placeHolder;

    private void Start() {
        // Have to get the first room for the player
        var nextSceneNum = Random.Range(0, roomList.Length);
        nextScene = roomList[nextSceneNum];
        DontDestroyOnLoad(this.gameObject);
    }

    IEnumerator tryLoad(){
        while(currentScene != nextScene) {   
            yield return new WaitForSeconds(.01f);
            try{
                placeHolder = GameObject.FindGameObjectWithTag("TeleporterPlaceHolder");
                landingPad = GameObject.FindGameObjectWithTag("landingPad");
                player.transform.position = landingPad.transform.position;
                this.transform.position = placeHolder.transform.position;
                Destroy(placeHolder);
                SceneManager.SetActiveScene(SceneManager.GetSceneByName(nextScene));
                currentScene = nextScene;
                
            } catch {
                Debug.Log("Not done loading");
            }
        }
        var nextSceneNum = Random.Range(0, roomList.Length);
        nextScene = roomList[nextSceneNum];
        while(nextScene == currentScene){
            nextSceneNum = Random.Range(0, roomList.Length);
            nextScene = roomList[nextSceneNum];
        }  
    }


    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")){
            SceneManager.LoadScene(nextScene);
            player = GameObject.FindGameObjectWithTag("Player");
            StartCoroutine(tryLoad());     
        }
    }
}

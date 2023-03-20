using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TileScript : MonoBehaviour
{
    public GameObject Button1;
    public GameObject Button2;
    public GameObject Button3;
    public GameObject Button4;
    public GameObject Button5;
    public GameObject Button6;
    public GameObject Button7;
    public GameObject Button8;
    public GameObject Button9;
    public GameObject Button10;
    public GameObject Button11;
    public GameObject Button12;
    public GameObject Button13;
    public GameObject Button14;
    public GameObject Button15;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Button1.SetActive(true);
            Button2.SetActive(false);
            Button3.SetActive(false);
            Button4.SetActive(false);
            Button5.SetActive(false);
            Button6.SetActive(false);
            Button7.SetActive(false);
            Button8.SetActive(false);
            Button9.SetActive(false);
            Button10.SetActive(false);
            Button11.SetActive(false);
            Button12.SetActive(false);
            Button13.SetActive(false);
            Button14.SetActive(false);
            Button15.SetActive(false);
        }
        PlayerPrefs.SetString("Level 1", SceneManager.GetActiveScene().name);
    }
 
    public void OnHintButtonPress()
    {
        // Save the current scene and tile position
        PlayerPrefs.SetString("Level 1", SceneManager.GetActiveScene().name);
        PlayerPrefs.SetFloat("-0.06", transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", transform.position.y);
        PlayerPrefs.SetFloat("0.18", transform.position.z);

        // Load the hint scene
        SceneManager.LoadScene("Level 1 hint elephant");
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MuroController : MonoBehaviour
{
    

    public TextMeshProUGUI healthText;
    public GameObject destroyText;
    public GameObject particleSystemExplotion;
    public GameObject muro;
    public Material Wall2;
    public Material Wall3;
    public int health = 10;
    private int sethealth;
    public bool isPlaying = false;
    void Start()
    {
        //explotion = particleSystemExplotion.GetComponent<ParticleSystem>();
        //var emission = explotion.emission;
        //emission.enabled = true;
        sethealth = health;
        SetHealthText();
    }
    public void SetHealthText()
    {
        healthText.text = "Wall Health: " + health.ToString();
        if (health <= 0)
        {
            healthText.text = "";
            destroyText.SetActive(true);
            isPlaying = true;
            Destruction();
        }else if(health == sethealth / 2)
        {
            muro.GetComponent<MeshRenderer>().material = Wall2;
        }else if(health == (int)sethealth * 0.2)
        {
            muro.GetComponent<MeshRenderer>().material = Wall3;
        }

    }
    public void Destruction()
    {
        Debug.Log("Destruction!!!!!");
        Destroy(muro.gameObject);
        Instantiate(particleSystemExplotion, muro.transform.position, Quaternion.identity);
        ActiveEmission();
    }

    public void ActiveEmission()
    {

        //var emission = explotion.emission;
        //emission.enabled = false;
        //emission.SetBursts(new ParticleSystem.Burst[] { new ParticleSystem.Burst(0,5,5,0.010f)});
        ParticleSystem explotion = particleSystemExplotion.GetComponent<ParticleSystem>();
        if (isPlaying)
        {
            Debug.Log("Play");
            explotion.Play();
            //explotion.Pause();
            isPlaying = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PukkiHPController : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float offset;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private TMP_Text healthText;
    [SerializeField] private float pukkiMaxHP = 100;
    [SerializeField] private Image glowHealthbar;
    private float pukkiHP;
    private GameObject playerObj;

    private AudioSource audioSource;
    public AudioClip hit;
    public AudioClip death;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        playerObj = GameObject.FindGameObjectWithTag("Player");
        pukkiHP = pukkiMaxHP;
        healthText.text = "Health " + pukkiHP + " / "+ pukkiMaxHP;
    }
    private void Update()
    {
        transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y + offset, transform.position.z);
    }

    private void UpdateHP()
    {
        glowHealthbar.color = new Color32(0, 0, 0, 0);
        Invoke("changeColorBack", .1f);
        healthText.text = "Health " + pukkiHP + " / " + pukkiMaxHP;
        healthSlider.value = pukkiHP;
        if (pukkiHP <= 0) {
            PlayDeathSound(); // Ei toimi t�ll� tavoin
            Destroy(playerObj);
            Destroy(gameObject);
            
        }
    }
    public void TakeDamage(float damageTaken)
    {
        pukkiHP -= damageTaken;
        UpdateHP();
    }

    public void PlayDeathSound()
    {
        audioSource.clip = death;
        audioSource.Play();
    }

    public void PlayHitSound()
    {
        audioSource.clip = hit;
        audioSource.Play();
    private void changeColorBack()
    {
        glowHealthbar.color = new Color32(13, 128, 0, 255);
    }
}

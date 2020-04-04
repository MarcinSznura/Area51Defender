using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform barrel;
    [SerializeField] float barrelSpeed = 10f;
    [SerializeField] float fireRate = 5f;
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 1000f;
    [SerializeField] GameObject hitEffect;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] Transform explosion;
    [SerializeField] Image reticle;

    [SerializeField] AudioSource spining;
    [SerializeField] AudioSource Loop;
    //[SerializeField] AudioSource gun;
    //[SerializeField] AudioSource gunTail;

    [SerializeField] AudioClip shootFirst;
    [SerializeField] AudioClip shootSound;
    [SerializeField] AudioClip shootTail;
    [SerializeField] AudioClip spinStart;
   // [SerializeField] AudioClip spin;
    [SerializeField] AudioClip spinEnd;

    enum BarelSpining {notSpining,start,mid,end};
    //enum GunSound { none,fireing,end };

    BarelSpining state = BarelSpining.notSpining;
    //GunSound gunSound = GunSound.none;

    int howManyGuns;
    float shootSoundDelay;
    bool canShot = true;
    //AudioSource audioSource;
    Upgrademenu upgrademenu;
    float barellSpiningSpeed;
    bool isExploding = false;
    private float soundVolume;
    bool canPlayGunShot = true;

    float recoilReduction = 0;

    float recoil; //recoil ammount

    private Dictionary<string, KeyCode> keys;

    private void Start()
    {
        keys = FindObjectOfType<MainMenu>().keys;
        upgrademenu = FindObjectOfType<Upgrademenu>();
        //audioSource = GetComponent<AudioSource>();
        howManyGuns = upgrademenu.GetplayerMultishot();
        SetTowerFireRate();
        if (upgrademenu.GetammoExplosive() > 0) isExploding = true;
        soundVolume = FindObjectOfType<MainMenu>().soundsValue;
    }

    int randomizeRecoilPath()
    {
        int value = UnityEngine.Random.Range(0, 2);
        if (value == 1) return 1;
        else return -1;
    }

    private void ProccesRaycast()
    {
        RaycastHit hit;

        Vector2 withRecoilHit = UnityEngine.Random.insideUnitCircle * 2*recoil;

        Vector3 fixedOrigin = new Vector3(FPCamera.transform.position.x+ withRecoilHit.x, FPCamera.transform.position.y, FPCamera.transform.position.z+ withRecoilHit.y);
        //Debug.Log(withRecoilHit.x + " " + withRecoilHit.y);
        if (Physics.Raycast(fixedOrigin, FPCamera.transform.forward, out hit, range))
        {
            CreateHitImpact(hit);
            EnemyDamage target = hit.transform.GetComponent<EnemyDamage>();
            if (target == null) return;
            target.ProcessDamageRecivedFromPlayer();
            if (isExploding) Instantiate(explosion, hit.transform.position, Quaternion.identity);
        }
        else
        {
            return;
        }
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
    }

    public float SetTowerFireRate()
    {
        return 1f / upgrademenu.GetplayerFireRate();
    }

    public void SetTowerRecoilReduction()
    {
        recoilReduction = upgrademenu.GetplayerRecoilReduction();
    }

    public void SetMultishot()
    {
        howManyGuns = upgrademenu.GetplayerMultishot();
    }

    void Update()
    {
        reticle.rectTransform.sizeDelta = new Vector2(20*(1+recoil), 20 *(1 + recoil));
        ProcessRotation();
        ProcessFire();
        Cheats();
       
    } 

    private void Cheats()
    {
        if (Input.GetKeyDown(KeyCode.Keypad8))
            FindObjectOfType<Upgrademenu>().IncreasePlayerExpierience(500);
        if (Input.GetKeyDown(KeyCode.Keypad9))
            FindObjectOfType<TimeMaster>().wave += 3;
        if (Input.GetKeyDown(KeyCode.Keypad5))
            FindObjectOfType<TimeMaster>().wave += 3;
    }

    private void ProcessRotation()
    {
        float zRotationRestriction = (barrel.transform.localEulerAngles.z + 11) % 360;
        float yRotationRestriction = (barrel.transform.localEulerAngles.y + 21) % 360;
        Debug.Log((barrel.transform.localEulerAngles.y + 21) % 360);
        if (Input.GetKey(keys["up"]))
        {
            if (zRotationRestriction > 1)
            {
                barrel.transform.Rotate(0, 0, -barrelSpeed * Time.deltaTime);
                SetXrotatioToZero();
            }
        }

        if (Input.GetKey(keys["down"]))
        {
            if (zRotationRestriction < 40)
            {
                barrel.transform.Rotate(0, 0, barrelSpeed * Time.deltaTime);
                SetXrotatioToZero();
            }
        }

        if (Input.GetKey(keys["right"]))
        {
            if (yRotationRestriction < 41)
            {
                barrel.transform.Rotate(0, barrelSpeed * Time.deltaTime, 0);
                SetXrotatioToZero();
            }
        }

        if (Input.GetKey(keys["left"]))
        {
            if (yRotationRestriction > 1)
            {
                barrel.transform.Rotate(0, -barrelSpeed * Time.deltaTime, 0);
                SetXrotatioToZero();
            }
        }

    }

    private void SetXrotatioToZero()
    {
        Quaternion q = barrel.transform.rotation;
        q.eulerAngles = new Vector3(0, q.eulerAngles.y, q.eulerAngles.z);
        barrel.transform.rotation = q;
    }

    private void ProcessFire()
    {
            BarellAnimation();
            if (recoil > 8) recoil = 8;
            if (Input.GetKey(keys["fire"]))
            {

                if (barellSpiningSpeed < 1) barellSpiningSpeed += Time.deltaTime;

                if (barellSpiningSpeed < 1 && recoil > 0)
                    recoil -= 6 * Time.deltaTime;

                if (barellSpiningSpeed > 1)
                {
                    if (canShot)
                    {
                        StartCoroutine(Shoot());
                        recoil += (4 - (recoilReduction * .5f)) * Time.deltaTime;
                    }
                }

            }
            else
            {
                if (barellSpiningSpeed > 0) barellSpiningSpeed -= Time.deltaTime;
                if (barellSpiningSpeed < 1 && recoil > 0) recoil -= 6 * Time.deltaTime;
                if (barellSpiningSpeed <= 0) recoil = 0;
            //gunSound = GunSound.none;
            }
            if (recoil < 0) recoil = 0;
    }

    private void BarellAnimation()
    {
        if (!FindObjectOfType<TimeMaster>().TimeStopeed())
        {
            if (barellSpiningSpeed > 0)
            {
                GetComponentInChildren<Animator>().speed = upgrademenu.GetplayerFireRate() * barellSpiningSpeed;
                GetComponentInChildren<Animator>().SetBool("shouldSpinn", true);

                switch (state)
                {
                    case BarelSpining.notSpining:
                        if (barellSpiningSpeed > 0)
                        {
                            Loop.PlayOneShot(spinStart, soundVolume * 0.6f);
                            state = BarelSpining.start;
                        }
                        break;

                    case BarelSpining.start:
                        if (barellSpiningSpeed >= 1)
                        {
                            state = BarelSpining.mid;
                            spining.volume = soundVolume * .15f;
                            spining.Play();
                        }
                        break;

                    case BarelSpining.mid:
                        if (!spining.isPlaying)
                        {
                            spining.volume = soundVolume * .15f;
                            spining.Play();
                        }
                        if (barellSpiningSpeed < 1)
                        {
                            spining.Stop();
                            Loop.PlayOneShot(spinEnd, soundVolume * 0.6f);
                            state = BarelSpining.end;
                        }
                        break;

                    case BarelSpining.end:
                        if (barellSpiningSpeed<= 0)
                        {
                            state = BarelSpining.notSpining;
                        }
                        if (Input.GetKey(keys["fire"]))
                        {
                            state = BarelSpining.start;
                            Loop.PlayOneShot(spinStart, soundVolume * 0.6f);
                        }
                        break;

                }
            }
            else
            {
                GetComponentInChildren<Animator>().SetBool("shouldSpinn", false);
                GetComponentInChildren<Animator>().speed = 0;
            }
            Debug.Log(barellSpiningSpeed);
        }
    }

  
    IEnumerator Shoot()
    {
        canShot = false;
        PlayMuzzleFlash();
        ProccesRaycast();
        PlayShootSound();
        StartCoroutine(ApplyRecoil());
        yield return new WaitForSeconds(SetTowerFireRate() / howManyGuns);
        canShot = true;
    }

    IEnumerator ApplyRecoil()
    {
        //barrel.transform.Rotate(recoil * Time.deltaTime * 2, 0, randomizeRecoilPath() * recoil* Time.deltaTime);
        barrel.transform.position = new Vector3(barrel.transform.position.x+1, barrel.transform.position.y, barrel.transform.position.z);
        SetXrotatioToZero();
        yield return new WaitForSeconds(0.05f);
        barrel.transform.position = new Vector3(barrel.transform.position.x-1, barrel.transform.position.y, barrel.transform.position.z);
    }

    private void PlayShootSound()
    {
        if (canPlayGunShot)
        {
                Loop.PlayOneShot(shootSound, soundVolume * 0.6f);
                Loop.PlayOneShot(shootTail, soundVolume * 0.6f);
                StartCoroutine(SoundBreak());
        }
    }

    IEnumerator SoundBreak()
    {
        canPlayGunShot = false;
        yield return new WaitForSeconds(0.1f);
        canPlayGunShot = true;
    }

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    public void BarellSound()
    {
        spining.Stop();
    }

}

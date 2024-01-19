using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;


public class Player : MonoBehaviour
{
    
    public AudioSource audioSource;
    public AudioClip[] audioClips;
    public SoundSettingManager soundSetting;

    public PlayerData plData;

    public int hp;
    public int shield;
    public bool potion;
    public bool check;

    public bool atkCool;


    public GameObject weapon;
    public GameObject player;
    Rigidbody plRb;
    Camera plCamera;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.None;
        soundSetting = FindObjectOfType<SoundSettingManager>();
        animator = GetComponentInChildren<Animator>();
        plData = FindObjectOfType<PlayerData>();
        plRb = GetComponent<Rigidbody>();
        plCamera = GetComponentInChildren<Camera>();
        hp = plData.hp;
        shield = plData.shield;
        potion = plData.potion;
        atkCool = true;
        plData.cool = false;
        audioClips = GetComponent<PlSound>().audioClips;
        audioSource = GetComponent<AudioSource>();
    }
    IEnumerator DashCool()
    {
        plData.dash = false;
        yield return new WaitForSeconds(plData.dashCool);
        plData.dash = true;
    }
    IEnumerator Dash()
    {
        plData.cool = true;
        yield return new WaitForSeconds(0.2f);
        plData.cool = false;
    }
    IEnumerator AtkCool()
    {
        atkCool = false;
        yield return new WaitForSeconds(0.5f);
        atkCool = true;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 move = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            move.z = 1;          
        }
        else if (Input.GetKey(KeyCode.S))
        {
            move.z = -1;          
        }
        if (Input.GetKey(KeyCode.D))
        {
            move.x = 1;        
        }
        if (Input.GetKey(KeyCode.A))
        {
            move.x = -1;           
        }

        if(Input.GetMouseButton(0))
        {
            animator.SetInteger("animation", 3);
        }
        else if (move != Vector3.zero)
        {
            animator.SetInteger("animation", 20);
        }
        else
        {
            animator.SetInteger("animation", 15);
        }

        move = move.normalized * plData.speed * 100 * Time.deltaTime;
        move.y = plRb.velocity.y;
        if (Input.GetKey(KeyCode.Space) && plData.dash)
        {

            //  transform.position = new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z);
            
            audioSource.clip = audioClips[2];
            audioSource.Play();
            plRb.AddForce(move * 5, ForceMode.Impulse);
            StartCoroutine(DashCool());
            StartCoroutine(Dash());
        }
        if(!plData.cool)
        {
            plRb.velocity = move;
        }
        if(Input.GetKey(KeyCode.LeftControl) && potion)
        {
            audioSource.clip = audioClips[0];
            audioSource.Play();
            hp = plData.hp;
            potion = false;
        }
        if(Input.GetKey(KeyCode.Mouse0) && atkCool)
        {
            animator.SetTrigger("Atk");
            StartCoroutine(AtkCool());
            audioSource.clip = audioClips[1];
            audioSource.Play();
            weapon.GetComponent<Collider>().enabled = true;
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            
            weapon.GetComponent<Collider>().enabled = false;
        }

        LookMouse();
        audioSource.volume = soundSetting.effectVolume;
    }
    public void LookMouse()
    {
        Ray ray = plCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, 1<<LayerMask.NameToLayer("Floor")))
        {
            Debug.DrawLine(ray.origin, hit.point, Color.red);
            Debug.Log(hit.point.x);
            Debug.Log(hit.point.z);

            Vector3 plFor = new Vector3(hit.point.x, player.transform.position.y, hit.point.z) - player.transform.position;
            player.transform.forward = plFor;
        }
    }

}

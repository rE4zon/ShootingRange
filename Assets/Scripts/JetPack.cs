using UnityEngine;
using UnityEngine.UI;

public class JetPack : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private int jetPackForce = 2;
    [SerializeField] private float jetPackFuel = 10f;
    private bool isUsing;
    [SerializeField] private GameObject ParticleLeft, ParticleRight;
    [SerializeField] Image UIBar;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        if (jetPackFuel >= 10f)
        {
            jetPackFuel = 10f;
        }
        UIBar.fillAmount = jetPackFuel / 10f;
        if (Input.GetKey(KeyCode.Space) && (jetPackFuel > 0))
         {
            
                StartJetPack();
            
        }
        else
        {
            StopJetPack();
        }
        if (jetPackFuel <= 0 && isUsing == false)
        {
            StopJetPack();
        }
    }
    void StartJetPack()
    {
        rb.AddForce(Vector3.up * jetPackForce);
        jetPackFuel -= Time.deltaTime;
        isUsing = true;
        ParticleLeft.GetComponent<ParticleSystem>().Play();
        ParticleRight.GetComponent<ParticleSystem>().Play();
    }
    void StopJetPack()
    {
        jetPackFuel += Time.deltaTime;
        isUsing = false;
        ParticleLeft.GetComponent<ParticleSystem>().Stop();
        ParticleRight.GetComponent<ParticleSystem>().Stop();
    }
}
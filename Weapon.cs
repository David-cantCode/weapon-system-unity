using UnityEngine;

public class Weapon : MonoBehaviour
{
    //stats
    public string gun_name; //ak , pistol etc
    public const float reloadTime = 1f;


    //settings 
    private float timeBetweenAttacks = .12f;


    //general
    private bool alreadyAttacked;
    private GameObject guntip;
    [SerializeField] private LayerMask hitLayers;
    public bool is_selected; 
    public bool shooting = false;
    [SerializeField] private Camera playerCamera;
     [SerializeField] private GameObject self;


    public int reserve_ammo;
    public int mag_size;
    public int mag;
    private bool alreadyreload;



    void Start()
    {
            
    }

    void ResetAttack()
    {
        alreadyAttacked = false;
    }

//************************************************************************
//**********************************RELOAD********************************
//*************************************************************************
    private void reloading()
    {

        if (!alreadyreload)
        {
            alreadyreload = true;
            Invoke(nameof(reloadFinished), reloadTime);
        }
    }

    private void reloadFinished()
    {
        //transfer bullets from resv tp mag
        int bulletsToReload = Mathf.Min(mag_size - mag, reserve_ammo);
        mag += bulletsToReload;
        reserve_ammo -= bulletsToReload;

        
        alreadyreload = false;

    }

//************************************************************************
//**************************aww shoot - addy ********************************
//*************************************************************************
    private void shoot()
    {
        if (!alreadyAttacked)
        {
            mag--;

         
            shoot_ray();

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }


    private void shoot_ray() {
            Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
            RaycastHit hit;
        
            Debug.DrawRay(ray.origin, ray.direction * 800f, Color.red, 5f);



        if (Physics.Raycast(ray, out hit, 800f, hitLayers))
        {

            

            if (hit.collider.CompareTag("enemy"))
            {

                //ar enemyHealth = hit.collider.GetComponent<self_health>();
               // if (enemyHealth != null)
                //{
                  //  enemyHealth.Hit(35);
                //}


            }


            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }




    void Update()
    {
    //sorry for all the ifs but im stupid

        if (is_selected)
        {
            self.SetActive(true);
            //follow_camera();

            if (reserve_ammo > 0 || mag > 0){
                //if theres ammo left

                    //if not reloading
                if (!alreadyreload){
                    if (mag > 0)
                    {
                        if (Input.GetMouseButton(0)) { shoot(); }
                        }
                        else
                        {
                        //auto reload if no ammo in mag
                            reloading();
                        }

                        //or reload when r
                        if (Input.GetKeyDown(KeyCode.R)) reloading();
                    }}

            }

        else
        {
            self.SetActive(false);}
}                                   




}

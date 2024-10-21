using MyFps;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngineInternal;

namespace MySample
{

    public class ShootingTest : MonoBehaviour
    {
        #region Variables
        private Animator animator;

        //
        public ParticleSystem muzzle;
        public AudioSource pistolShotSound;

        //
        //public Transform camera;
        public Transform firePoint;

        //연사 딜레이
        [SerializeField] private float fireDelay = 0.5f;
        private bool isFire = false;

        //총알 데미지
        [SerializeField] private float attackDamage = 5f;

        //탄착 임팩트 효과
        public GameObject hitImpactPrefab;
        [SerializeField] private float impactForce = 10f;
        #endregion
        // Start is called before the first frame update
        void Start()
        {
            animator = GetComponent<Animator>();

        }

        // Update is called once per frame
        void Update()
        {
            //Fire
            if (Input.GetButtonDown("Fire") && !isFire)
            {
                StartCoroutine(Shoot());

            }
        }


        IEnumerator Shoot()
        {
            isFire = true;
            //내앞에 100 안에 적이 있으면 적에게 데미지 준다
            float maxDistance = 100f;

            RaycastHit hit;
            if (Physics.Raycast(firePoint.position, firePoint.TransformDirection(Vector3.forward), out hit, maxDistance))
            {
                //적에게 데미지를 준다
                Debug.Log($"{hit.transform.name}적에게 데미지를 준다");

                //임팩트 효과
                GameObject eff = Instantiate(hitImpactPrefab, hit.point, Quaternion.identity);
                Destroy(eff, 2f);

                if (hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(-hit.normal * impactForce , ForceMode.Impulse);
                }
              
               

                IDamageable damageable = hit.transform.GetComponent<IDamageable>();
                if (damageable != null)
                {
                    damageable.TakeDamage(attackDamage);
                }


                /*RobotController robot = hit.transform.GetComponent<RobotController>();
                if (robot != null)
                {
                    robot.TakeDamage(attackDamage);
                }

                EnemyTest enemy = hit.transform.GetComponent<EnemyTest>();
                if (enemy != null)
                {
                    enemy.TakeDamage(attackDamage);
                }*/
            }

            //슛 효과 - VFX,SFX
            animator.SetTrigger("ShootTrigger");
            pistolShotSound.Play();

            muzzle.gameObject.SetActive(true);
            //pistolShotSound.gameObject.SetActive(true);

            muzzle.Play();

            yield return new WaitForSeconds(fireDelay);
            muzzle.Stop();
            muzzle.gameObject.SetActive(false);

            isFire = false;
        }

        //Gizmo 그리기 : 총 위치에서 앞에 충돌체 까지 레이저 쏘는 선 그리기
        private void OnDrawGizmosSelected()
        {
            float maxDistance = 100f;

            RaycastHit hit;
            bool isHit = Physics.Raycast(firePoint.position, firePoint.TransformDirection(Vector3.forward), out hit, maxDistance);

            Gizmos.color = Color.red;
            //충돌체가 거리안에 있으면
            if (isHit)
            {
                Gizmos.DrawRay(firePoint.position, firePoint.forward * hit.distance);
            }
            else
            {
                Gizmos.DrawRay(firePoint.position, firePoint.forward * maxDistance);
            }
        }
    }

}
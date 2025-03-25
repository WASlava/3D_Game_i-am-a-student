using UnityEngine;

[RequireComponent(typeof(Animator))]
public class SpiderMonoBehaviour : MonoBehaviour
{
    [SerializeField] private float speed = 5.0F;
    private Animator _animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!(_animator.GetBool("IsDie") || _animator.GetBool("IsDie2")))
        {
            transform.Translate(0, 0, -speed * Time.deltaTime);
        }
        
        if (Input.GetKeyDown(KeyCode.K))
        {
            speed = 0.0F;
            if (Random.Range(0, 2) == 0) 
                { _animator.SetBool("IsDie", true); }
            else
                { _animator.SetBool("IsDie2", true); }
     
        }

        else if (Input.GetKeyDown(KeyCode.J))
            {
            Debug.Log("Jamping");
            _animator.SetBool("Jamping", true);
                speed = 20.0F;
            }
            else
            {
                _animator.SetBool("Jamping", false);
                speed = 5.0F;
            }

            //if (Input.GetKey(KeyCode.W))
            //{
            //    transform.Translate(0, 0, speed * Time.deltaTime);
            //}
 
        //}
    }
}

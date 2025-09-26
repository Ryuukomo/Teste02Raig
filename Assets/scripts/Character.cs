using UnityEngine;

public class Character : MonoBehaviour
{
    public float velocidade = 5;
    float velocidadeRotacao = 10;
    float movimentoX;
    float movimentoZ;

    bool atirando;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Rigidbody rigidbody;
    Animator animator;
    
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
      
    }

    // Update is called once per frame
    void Update()
    {
        movimentoX = Input.GetAxis("Horizontal");
        movimentoZ = Input.GetAxis("Vertical");  
        atirando = Input.GetKey(KeyCode.Space);

        animator.SetBool("estaatirando", atirando);    
    }

    private void FixedUpdate()
    {
        Vector3 movimento = new Vector3(movimentoX, 0, movimentoZ); 
     
        if(movimento.magnitude > 0) { movimento = movimento.normalized;}

        Vector3 moveComVelocidade = movimento * velocidade;
        rigidbody.MovePosition(transform.position + moveComVelocidade * Time.deltaTime);

        animator.SetFloat("velocidade", (movimento * velocidade).magnitude);

        if(movimento.magnitude > 0)
        {
        Quaternion rotacao = Quaternion.LookRotation(movimento);
        rigidbody.rotation = Quaternion.Slerp(rigidbody.rotation, rotacao, velocidadeRotacao * Time.deltaTime);
        }
      
    }

}

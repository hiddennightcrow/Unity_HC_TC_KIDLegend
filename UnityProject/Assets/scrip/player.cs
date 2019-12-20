
using UnityEngine;

public class player : MonoBehaviour
{
    public Joystick joystick;
    public Rigidbody rig;
    private Animator ani;
    private Transform target;

    public float speed = 10;
    private void Start()
    {
        rig=GetComponent<Rigidbody>();
        ani = GetComponent<Animator>();
        joystick =GameObject.Find("虛擬搖桿").GetComponent<Joystick>();
        target = GameObject.Find("目標").transform;
    }
    private void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        float v = joystick.Vertical;
        float h = joystick.Horizontal;

        rig.AddForce(-h*speed, 0, -v*speed);
        ani.SetBool("跑步開關",v != 0 || h != 0);

        Vector3 posPlaer =transform.position;
        Vector3 posTarget = new Vector3(posPlaer.x - h, 0.279f, posPlaer.z - v);
        target.position = posTarget;

        posTarget.y = posPlaer.y;
        transform.LookAt(posTarget);
    }
}

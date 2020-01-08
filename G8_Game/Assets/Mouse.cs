using UnityEngine;

public class Mouse: MonoBehaviour
{
    #region 欄位區域
    [Header("移動速度")]
    [Range(1, 1000)]
    public int speed = 10;
    [Header("旋轉速度")]
    public float turn = 20.5f;
    [Header("任務狀態")]
    public bool mission;
    [Header("玩家名稱")]
    public string _name = "mouse";
    #endregion

    [Header("撿物品位置")]
    public Rigidbody rigCatch;

    public Transform tran;
    public Rigidbody rig;
    public Animator ani;

    private void Update()
    {
        Turn();
        Run();
        Catch();

    }

    //觸發碰撞時持續執行 (每秒60次) 碰撞物件資訊
    private void OnTriggerStay(Collider other)
    {
        print(other.name);

        //如果 碰撞物件的名稱 為 Chicken 並且 動畫為撿東西
        if (other.name == "起司" && ani.GetCurrentAnimatorStateInfo(0).IsName("攻擊"))
        {
            //物理.忽略碰撞(A碰撞，B碰撞)
            Physics.IgnoreCollision(other,GetComponent<Collider>());
            //碰撞物件.取得元件<泛型>().連接身體 = 檢物品位置
            other.GetComponent<HingeJoint>().connectedBody = rigCatch;
        }

        if (other.name == "沙子" && ani.GetCurrentAnimatorStateInfo(0).IsName("攻擊"))
        {
            GameObject.Find("起司").GetComponent<HingeJoint>().connectedBody = null;
        }
    }

    #region 方法區域

    /// <summary>
    /// 跑步
    /// </summary>
    private void Run()
    {
        //如果 動畫 為 撿東西 就 跳出
        if (ani.GetCurrentAnimatorStateInfo(0).IsName("攻擊")) return;

        float v = Input.GetAxis("Vertical");   //W 上 1、S 下 -1 沒按 0
        //rig.AddForce(0, 0, speed * v);           //世界座標
        //tran.forward 區域座標 Z 軸
        //tran.right   區域座標 X 軸
        //tran.up      區域座標 Y 軸
        rig.AddForce(tran.forward * speed * v * Time.deltaTime);   //區域座標

        ani.SetBool("走路開關", v != 0);
    }
    /// <summary>
    /// 旋轉
    /// </summary>
    private void Turn()
    {
        float h = Input.GetAxis("Horizontal");   //A 左 -1、D 右 1 沒按 0
        tran.Rotate(0, turn * h * Time.deltaTime, 0);
    }


    /// <summary>
    /// 拾取
    /// </summary>
    private void Catch()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //按下左鍵撿東西
            ani.SetTrigger("攻擊開關");
        }
    }
}

    #endregion


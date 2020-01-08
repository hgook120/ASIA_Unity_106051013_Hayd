using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearnMethod : MonoBehaviour
{
    // Start is called before the first frame update
    private void Drive(int speed)
    {
        print("音效");

        print("開車，時速：" + speed);

    }

    private void Shoot(int count, float speed, string prop = "無", string direction = "前方")
    {
        print("弓箭數量：" + count);
        print("弓箭速度：" + speed);
        print("弓箭屬性：" + prop);
        print("弓箭方向：" + direction);
    }

    private int Square(int number = 2)
    {
        return number * number;
    }

    private void Start()
    {
        print("哈囉，沃德~");
        Drive(200);
        Drive(300);
        Drive(400);

        Shoot(1, 1.5f);
        Shoot(10, 10.5f, "火屬性");
        Shoot(3, 2, direction: "前後方");

        print(Square()); //作為傳回類型使用

        int result = Square();//存放在區域欄位
        print(result);
    }
}

using UnityEngine;

public class LearnIf : MonoBehaviour
{
    
    public bool openDoor;
    public int score = 100;
    public int combo;

    private void Start()
    {
        //語法：if (布林值) { 陳述式與演算法 }
        // () 內的布林值為 true 執行 { }
        if (true)
        {
            print("測試");
        }
    }
    private void Update()
    {
        /**
        if (openDoor)
        {
            //if () 內的布林值為 true 執行 if { }
            print("開門");
        }
        else
        {
            //if () 內的布林值為 false 執行 else { }
            print("關門");
        }
        if (score >= 60)
        {
            print("及格");
        }
        else if (score >= 50)
        {
            print("補考");
        }
        else if (score >= 40)
        {
            print("付錢補考");
        }
        else
        {
            print("被當掉");
        }
        */

        if (combo >= 150)
        {
            print("攻擊 10 倍");
        }
        else if (combo >= 100)
        {
            print("攻擊 5 倍");
        }
        else if (combo >= 50)
        {
            print("攻擊 2 倍");
        }

    }
}

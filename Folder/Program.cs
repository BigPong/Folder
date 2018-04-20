using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Folder
{
    class Program
    {
        // 宣告Random
        static Random next = new Random();

        static void Main(string[] args)
        {
            // 說明
            Console.WriteLine("程式說明：\r\n當你打開此程式後可以命名你的第一個資料夾\r\n他會在專案的bin\\Debug資料夾中作為你的目錄\r\n接下來你每輸入一次數字都會在最新一層中產生對應數量的資料夾\r\n意思就是說你輸入兩次10的話就會產生10*10\r\n100個資料夾~\r\n\r\n數量過大會很可怕\r\n方便的話對自己的電腦(還有我)好一點\r\n");

            // 最初的輸入
            Console.WriteLine("\r\n請輸入你的目錄資料夾名稱");
            string path = Console.ReadLine();

            // 看有沒有人長一樣
            try
            {
                if (Directory.Exists(path))
                {
                    Console.WriteLine("已經有同樣的資料夾名稱了");
                    Console.Read();
                    return;
                }
                DirectoryInfo di = Directory.CreateDirectory(path);
            }
            catch
            {
                Console.WriteLine("失敗");
            }

            // 宣告儲存路徑的陣列
            List<string> allPath = new List<string>();
            List<string> usePath = new List<string>();
            usePath.Add(path);

            while (true)
            {
                // 看使用者這層要幾個
                Console.WriteLine("輸入你該層欲創建的數量");
                int num;
                Int32.TryParse(Console.ReadLine(), out num);

                // 0就跳
                if(num == 0)
                {
                    break;
                }

                // 創建囉
                for (int j = 0; j < usePath.Count; j++)
                {
                    for (int i = 0; i < num; i++)
                    {
                        // 有"極"低的機率名稱相同
                        string UnderPath = usePath[j] + "\\" + Name();
                        try
                        {
                            DirectoryInfo di = Directory.CreateDirectory(UnderPath);
                            allPath.Add(UnderPath);
                        }
                        catch
                        {
                            Console.WriteLine("失敗");
                        }
                    }
                }

                // 刷新路徑
                usePath = new List<string>(allPath);
                allPath.Clear();
            }
        }

        // 隨機命名函式  不重要
        static string Name()
        {
            string rStr = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            string n = "";

            for(int i = 0; i < next.Next(10, 20); i++)
            {
                n += rStr[next.Next(0, rStr.Length)];
            }

            return n;
        }
    }
}

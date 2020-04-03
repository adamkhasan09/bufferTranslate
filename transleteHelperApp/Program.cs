using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace transleteHelperApp
{
    class Program
    {
        [STAThread] //атрибут однопоточного прилжения Single Thread Apartment
        static void Main(string[] args)
        {
            string querySTR = "";
            string urlMT = "https://www.multitran.com/m.exe?l1=1&l2=2&s="; //посковая строка мультитрана
            string urlGl = "https://translate.google.com/?hl=ru#view=home&op=translate&sl=auto&tl=ru&text="; //посковая строка гугла
            string query = Clipboard.GetText();
            string outApp = readCFG("browser"); 
            string sourse = readCFG("source");
            if(sourse == "gt")
            {
                query = query.Replace("\n", "%0A");
                query = query.Replace(" ", "%20");
                querySTR = urlGl + query;
            }else if(sourse == "mt")
            {
                querySTR = urlMT + query.Replace(" ", "+");
            }
            System.Diagnostics.Process.Start(outApp, querySTR);
        }
        static string readCFG( string paramName)
        {
            int idx;
            string[] agrs = File.ReadAllLines("cfg.txt"); //считываем файл конфигурации 
            idx = paramName == "browser" ? 0 : 0;
            idx = paramName == "source" ? 1 : 0;
            string[] res = agrs[idx].Split('='); //преобрауют строку в массив (browser=chrome.exe)
            return res[1]; //возвращаем первый элемент где храниться значение (chrome.exe)
        }
    }
}

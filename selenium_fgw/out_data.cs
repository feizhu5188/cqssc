using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using static System.Net.Mime.MediaTypeNames;

namespace selenium_fgw
{
   public class out_data
    {

       public static void load_page(string url, IWebDriver mydr)
        {
            
                mydr.Navigate().GoToUrl(url);
           
           
        }
        //第三个变量 如果采集期号 true;开奖号是 false
        public static string load_kaijianghao(string xpa, IWebDriver mydr,bool str)
        {

            if (str)
            {
                string text_zhi = mydr.FindElement(By.XPath(xpa)).Text;
                if (text_zhi.Length==2)
                {
                    text_zhi = "0" + text_zhi;
                    return text_zhi;
                }

                else
                {
                    return text_zhi;
                }
               
            }
            else
            {
                string text_zhi = mydr.FindElement(By.XPath(xpa)).Text;

                    return text_zhi;

            }


        }






       
    }
}

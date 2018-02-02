using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Selenium;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using static System.Net.Mime.MediaTypeNames;
using System.Data.SqlClient;
using tessnet2;
using System.Threading;
using System.Data;


namespace selenium_fgw
{
    class Program
    {
        private static string current_iussie()
        {
            string current_iussie = "";
            //计算理论期数
            //定义当前时间
            DateTime G_datetime = DateTime.Now;
            //早晨10点开始
            string ssc_satrt_time = string.Format("{0}/{1}/{2}/{3}/{4}/{5}", DateTime.Now.ToString("yyyy"), DateTime.Now.ToString("MM"), DateTime.Now.ToString("dd"), "10", "00", "00");
            DateTime G_ssc_start_time = DateTime.ParseExact(ssc_satrt_time, "yyyy/MM/dd/HH/mm/ss", null);
            //晚上12点结束
            string ssc_end1_time = string.Format("{0}/{1}/{2}/{3}/{4}/{5}", DateTime.Now.ToString("yyyy"), DateTime.Now.ToString("MM"), DateTime.Now.ToString("dd"), "23", "59", "59");
            DateTime G_ssc_end_time = DateTime.ParseExact(ssc_end1_time, "yyyy/MM/dd/HH/mm/ss", null);
            //调取线程
            Thread system_time_run = new Thread(
               () =>
               {
                   while (true)
                   {
                       TimeSpan time_jiange = DateTime.Now - G_datetime;
                       TimeSpan time_ssc_jainge = new TimeSpan();

                       if (DateTime.Now > G_ssc_start_time)
                       {
                           time_ssc_jainge = (DateTime.Now - G_ssc_start_time);
                       }
                       else
                       {
                           return;
                       }


                       string ssc_fenzhong = ((Convert.ToInt32(time_ssc_jainge.Hours) * 60 + Convert.ToInt32(time_ssc_jainge.Minutes)) / 10 + 25).ToString("000");


                       Invoke(
                            ((MethodInvoker)(() =>
                            {
                                label_runtime.Text = string.Format("系统已经运行 {0}天{1}小时{2}分{3}秒", time_jiange.Days, time_jiange.Hours, time_jiange.Minutes, time_jiange.Seconds);

                                if (DateTime.Now > G_ssc_start_time && DateTime.Now < G_ssc_end_time)
                                {
                                    Application.DoEvents();
                                    label_qishu_ssc.Text = "理论投注期号：" + " " + DateTime.Now.ToString("yyyyMMdd") + ssc_fenzhong;
                                    label_riying_touzhuqishu.Text = "4X当前投注期号：" + " " + cunzhi.touzhu_qishu_riying;//实际投注期数
                                    label_fivexing_touzhu_qihao.Text = "5X当前投注期号：" + " " + cunzhi.fivexing_touzhu_qishu;//实际投注期数
                                    dateTimePicker2.Value = DateTime.Now;

                                    if (cunzhi.data_rows > 0)
                                    {
                                        Application.DoEvents();
                                        label_shijiqishu.Text = "数据库实际期号：" + " " + cunzhi.qihao;//数据库的实际期数
                                        label_current_touzhu_qihao_fourxing.Text = cunzhi.fourxing_touzhu_qihao;
                                        label_main_4X_lr_total.Text = cunzhi.fourxing_lre_total;
                                        label_main_4X_touzhu_total.Text = cunzhi.fourxing_touzhu_total;
                                        label_main_4X_max_total.Text = cunzhi.fourxing_max_amount;
                                        label_plan_4x_N.Text = "当前计划个数： " + cunzhi.fourxing_plan_N.ToString();
                                        textBox_boshu_4X.Text = cunzhi.boshu_4X.ToString();

                                        label_current_touzhu_qihao_fivexing.Text = cunzhi.fivexing_touzhu_qihao;
                                        label_main_5X_lr_total.Text = cunzhi.fivexing_lre_total;
                                        labe_main_5X_touzhu_total.Text = cunzhi.fivexing_touzhu_total;
                                        label_main_5X_max_total.Text = cunzhi.fivexing_max_amount;
                                        label_plan_5x_N.Text = "当前计划个数: " + cunzhi.fivexing_plan_N.ToString();
                                        textBox_boshu_5X.Text = cunzhi.boshu_5X.ToString();
                                    }

                                    if (button_sound_shezhi.BackColor == Color.Red)
                                    {
                                        kaijianghao_caiji_tixing();

                                    }


                                }
                                else
                                {

                                    MessageBox.Show("现在不是计划时间");
                                }
                                label_now.Text = "当前时间是:" + " " + DateTime.Now.ToString();


                            })));
                       Thread.Sleep(6000);
                   }

               });




            return current_iussie;
        }



        static void Main(string[] args)
        {
            
           




            IWebDriver mydr = new ChromeDriver();
            out_data.load_page("https://www.1399p.com/shishicai/?utp=topbar", mydr);
       
            string path_kaijianghao = "//*[@id='ssc_peroid']";
            string path_n1 = "//*[@id='ssc_result']/span[1]";
            string path_n2 = "//*[@id='ssc_result']/span[2]";
            string path_n3 = "//*[@id='ssc_result']/span[3]";
            string path_n4 = "//*[@id='ssc_result']/span[4]";
            string path_n5 = "//*[@id='ssc_result']/span[5]";
            string kj_n1;
            string kj_n2;
            string kj_n3;
            string kj_n4;
            string kj_n5;
            string qihao_last_yuan;
            string qihao_last;
            string qihao_current_yuan;
            string qihao_current;
            string kaijianghao;
            qihao_last_yuan= out_data.load_kaijianghao(path_kaijianghao,mydr,true);
            qihao_last = DateTime.Now.ToString("yyyyMMdd")+ qihao_last_yuan;
            
            kj_n1= out_data.load_kaijianghao(path_n1, mydr,false);
            kj_n2 = out_data.load_kaijianghao(path_n2, mydr,false);
            kj_n3 = out_data.load_kaijianghao(path_n3, mydr,false);
            kj_n4 = out_data.load_kaijianghao(path_n4, mydr,false);
            kj_n5= out_data.load_kaijianghao(path_n5,mydr ,false);
            kaijianghao = kj_n1 + kj_n2 + kj_n3 + kj_n4 + kj_n5;
            //databases_sender.kaijianghao_sender_mssql(qihao_last,kaijianghao, kj_n1, kj_n2, kj_n3, kj_n4,kj_n5);
            // databases_sender.kaijianghao_sender_npgsql(qihao_last, kj_n1, kj_n2, kj_n3, kj_n4);
            Console.WriteLine("期号是：{0};开奖号是：{1} ;前5的开奖号码是：{2} {3} {4} {5} {6}",qihao_last,kaijianghao,kj_n1,kj_n2,kj_n3,kj_n4,kj_n5);
         
                int i = 1;
                while (i < 5000)
                    {
                qihao_current_yuan = out_data.load_kaijianghao(path_kaijianghao, mydr,true);
                 qihao_current = DateTime.Now.ToString("yyyyMMdd") + qihao_current_yuan;
                
                    if (qihao_current == qihao_last)
                    {
                        qihao_last = qihao_current;
                        i = i + 1;
                        System.Threading.Thread.Sleep(10 * 1000);
                        
                        continue;
                       
                    }
                    else
                    {
                    kj_n1 = out_data.load_kaijianghao(path_n1, mydr, false);
                    kj_n2 = out_data.load_kaijianghao(path_n2, mydr, false);
                    kj_n3 = out_data.load_kaijianghao(path_n3, mydr, false);
                    kj_n4 = out_data.load_kaijianghao(path_n4, mydr, false);
                    kj_n5 = out_data.load_kaijianghao(path_n5, mydr, false);
                    kaijianghao = kj_n1 + kj_n2 + kj_n3 + kj_n4 + kj_n5;
                    qihao_last = qihao_current;
                    Console.WriteLine("期号是：{0};开奖号是：{1};前5的开奖号码是：{2} {3} {4} {5} {6}", qihao_current,kaijianghao, kj_n1, kj_n2, kj_n3, kj_n4,kj_n5);
                    //databases_sender.kaijianghao_sender_mssql(qihao_last, kaijianghao, kj_n1, kj_n2, kj_n3, kj_n4, kj_n5);
                    //databases_sender.kaijianghao_sender_npgsql(qihao_current,kj_n1,kj_n2,kj_n3,kj_n4);
                    }
                    System.Threading.Thread.Sleep(10 * 1000);

                    i = i + 1;
                }
                Console.Read();

          
          
            Console.WriteLine();
            Console.Read();


        }

      
    }
}

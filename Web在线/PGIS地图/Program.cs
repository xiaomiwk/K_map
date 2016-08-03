using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Demo
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new F桌面与WEB交互());
            Application.Run(new FPGIS());

            //addressMatchQuery("http://10.118.2.229:7001/PGIS_S_Address/Ajax_UTF8",
            //                  "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
            //                  "<地址查询><地址列表><地址分类=\"杭州市\">杭州市</地址></地址列表></地址查询>");
        }

        /** 
        * 下面一段代码是作为客户端发给服务器段的代码和返回结果获取代码 
        * 
        * @param vServerURLPath 地址编码服务器的查询路径，一般是http://127.0.0.1:9000/Xml，如果启动的服务器使用默认配置 
        * @param vRequestXML_NotEncoded 
        *  要查询的XML数据，是没有经过URL编码的，将在这个函数中进行编码发送给服务器
        *  这个请求XML就是地址编码服务器的输入XML，具体格式，另待说明 
        */
        public static String addressMatchQuery(String vServerURLPath, String vRequestXML_NotEncoded)
        {
            try
            {
                // 进行URL编码 
                String vRequestXML_Encoded = System.Web.HttpUtility.UrlEncode(vRequestXML_NotEncoded,System.Text.Encoding.UTF8);
                // 与服务器交换数据 
                //String vResponseXML_Encoded = new System.Web.HttpRequest(vServerURLPath,vRequestXML_Encoded);
                var temp = System.Net.HttpWebRequest.Create(string.Format("{0}?{1}", vServerURLPath, vRequestXML_Encoded)).GetResponse() as System.Net.HttpWebResponse;
                //// 进行URL反编码 
                //String vResponseXML_NotEncoded = System.Web.HttpUtility.UrlDecode(temp.GetResponseStream(), System.Text.Encoding.UTF8);
                ////返回数据 
                //return vResponseXML_NotEncoded;
                return null;
            }
            catch (Exception e)
            {
                throw new Exception("地址编码数据交换失败", e);
            }
        }//addressMatchQuery

    }
}

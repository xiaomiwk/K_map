using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace 显示地图
{
    /// <summary>
    /// 需要网络支持
    /// </summary>
    public static class H信息查询
    {
        private static string _ak = "30c7e3648290e3782342130ed5200a30";

        public static M经纬度 地址编码(string __位置, string __城市 = null)
        {
            string __url = "";
            string __返回值 = "";
            if (string.IsNullOrEmpty(__城市))
            {
                __url = "http://api.map.baidu.com/geocoder/v2/?ak={0}&output=json&address={1}";
                __返回值 = Web服务请求(string.Format(__url, _ak, HttpUtility.UrlEncode(__位置)));
            }
            else
            {
                __url = "http://api.map.baidu.com/geocoder/v2/?ak={0}&output=json&address={1}&city={2}";
                __返回值 = Web服务请求(string.Format(__url, _ak, HttpUtility.UrlEncode(__位置), __城市));
            }
            var __JS序列化器 = new JavaScriptSerializer();
            var __结果 = __JS序列化器.Deserialize<M地址编码结果>(__返回值);
            if (__结果.status != 0)
            {
                return null;
            }
            var __百度坐标 = new M经纬度(__结果.result.location.lng, __结果.result.location.lat) { 类型 = E坐标类型.百度 };
            return HGPS坐标转换.百度坐标转谷歌坐标(__百度坐标);
        }

        public static string 逆地址编码(M经纬度 __位置)
        {
            var __url = "http://api.map.baidu.com/geocoder/v2/?ak={0}&output=json&location={1},{2}&pois=0&coordtype={3}";
            var __坐标 = 转换成百度坐标(__位置);
            //目前支持的坐标类型包括：bd09ll（百度经纬度坐标）、gcj02ll（国测局经纬度坐标）、wgs84ll（ GPS经纬度） 
            var __返回值 = Web服务请求(string.Format(__url, _ak, __坐标.纬度, __坐标.经度, __位置.类型 == E坐标类型.百度 ? "bd09ll" : "wgs84ll"));
            var __JS序列化器 = new JavaScriptSerializer();
            var __结果 = __JS序列化器.Deserialize<M逆地址编码结果>(__返回值);
            if (__结果.status != 0)
            {
                return null;
            }
            return __结果.result.formatted_address;
        }

        public static List<Tuple<M经纬度, string>> 区域检索(string __关键字, string __城市 = null)
        {
            if (string.IsNullOrEmpty(__城市))
            {
                __城市 = "全国";
            }
            __关键字 = __关键字.Replace(" ", "$");
            string __url = "http://api.map.baidu.com/place/v2/search?&output=json&ak={0}&q={1}&region={2}";
            string __返回值 = Web服务请求(string.Format(__url, _ak, HttpUtility.UrlEncode(__关键字), HttpUtility.UrlEncode(__城市)));
            var __JS序列化器 = new JavaScriptSerializer();
            var __结果 = __JS序列化器.Deserialize<M区域检索结果>(__返回值);
            if (__结果.status != 0)
            {
                throw new Exception(__结果.message);
            }
            return __结果.results.Select(q => new Tuple<M经纬度, string>(转换成谷歌坐标(new M经纬度(q.location.lng, q.location.lat) { 类型 = E坐标类型.百度 }),
                string.Format("{0}\n\r{1}\n\r{2}", q.name, q.address, q.telephone))).ToList();
        }

        /// <param name="__半径">单位:mi</param>
        /// <returns></returns>
        public static List<Tuple<M经纬度, string>> 区域检索(string __关键字, M经纬度 __圆心, int __半径)
        {
            __圆心 = 转换成百度坐标(__圆心);
            __关键字 = __关键字.Replace(" ", "$");
            string __url = "http://api.map.baidu.com/place/v2/search?&output=json&ak={0}&q={1}&location={2},{3}&radius={4}";
            string __返回值 = Web服务请求(string.Format(__url, _ak, HttpUtility.UrlEncode(__关键字), __圆心.纬度, __圆心.经度, __半径));
            var __JS序列化器 = new JavaScriptSerializer();
            var __结果 = __JS序列化器.Deserialize<M区域检索结果>(__返回值);
            if (__结果.status != 0)
            {
                throw new Exception(__结果.message);
            }
            return __结果.results.Select(q => new Tuple<M经纬度, string>(转换成谷歌坐标(new M经纬度(q.location.lng, q.location.lat) { 类型 = E坐标类型.百度 }),
                string.Format("{0}\n\r{1}\n\r{2}", q.name, q.address, q.telephone))).ToList();
        }

        public static List<Tuple<M经纬度, string>> 区域检索(string __关键字, M经纬度 __矩形左上坐标, M经纬度 __矩形右下坐标)
        {
            __矩形左上坐标 = 转换成百度坐标(__矩形左上坐标);
            __矩形右下坐标 = 转换成百度坐标(__矩形右下坐标);
            var __矩形左下坐标 = new M经纬度(__矩形左上坐标.经度, __矩形右下坐标.纬度);
            var __矩形右上坐标 = new M经纬度(__矩形右下坐标.经度, __矩形左上坐标.纬度);
            __关键字 = __关键字.Replace(" ", "$");
            string __url = "http://api.map.baidu.com/place/v2/search?&output=json&ak={0}&q={1}&bounds={2},{3},{4},{5}";
            string __返回值 = Web服务请求(string.Format(__url, _ak, HttpUtility.UrlEncode(__关键字), __矩形左下坐标.纬度, __矩形左下坐标.经度, __矩形右上坐标.纬度, __矩形右上坐标.经度));
            var __JS序列化器 = new JavaScriptSerializer();
            var __结果 = __JS序列化器.Deserialize<M区域检索结果>(__返回值);
            if (__结果.status != 0)
            {
                throw new Exception(__结果.message);
            }
            return __结果.results.Select(q => new Tuple<M经纬度, string>(转换成谷歌坐标(new M经纬度(q.location.lng, q.location.lat) { 类型 = E坐标类型.百度 }),
                string.Format("{0}\n\r{1}\n\r{2}", q.name, q.address, q.telephone))).ToList();
        }

        public static M线路 查询驾车线路(string __起点, string __终点, string __起点城市, string __终点城市, E驾车路线选择策略 __策略, out List<M地址> __可能起点, out List<M地址> __可能终点)
        {
            string __url = "http://api.map.baidu.com/direction/v1?mode=driving&output=xml&ak={0}&origin={1}&destination={2}&origin_region={3}&destination_region={4}&tactics={5}";
            string __返回值 = "";
            __返回值 = Web服务请求(string.Format(__url, _ak, HttpUtility.UrlEncode(__起点), HttpUtility.UrlEncode(__终点), HttpUtility.UrlEncode(__起点城市), HttpUtility.UrlEncode(__终点城市), (int)__策略));

            var __XML文档 = XDocument.Load(new StringReader(__返回值));
            var __根节点 = __XML文档.Root;
            var __status = __根节点.XPathSelectElement("./status").Value;
            if (__status != "0")
            {
                throw new Exception(__根节点.XPathSelectElement("./message").Value);
            }
            var __type = __根节点.XPathSelectElement("./type").Value;
            if (__type == "1")
            {
                __可能起点 = new List<M地址>();
                __可能终点 = new List<M地址>();
                foreach (XElement __节点 in __根节点.XPathSelectElements("./result/origin/content"))
                {
                    var __name = __节点.Element("name").Value;
                    var __address = __节点.Element("address").Value;
                    var __telephone = __节点.Element("telephone").Value;
                    var __lng = double.Parse(__节点.Element("location").Element("lng").Value);
                    var __lat = double.Parse(__节点.Element("location").Element("lat").Value);
                    __可能起点.Add(new M地址 { 备注 = __telephone, 名称 = __name, 详细地址 = __address, 坐标 = 转换成谷歌坐标(new M经纬度(__lng, __lat) { 类型 = E坐标类型.百度 }) });
                }
                foreach (XElement __节点 in __根节点.XPathSelectElements("./result/destination/content"))
                {
                    var __name = __节点.Element("name").Value;
                    var __address = __节点.Element("address").Value;
                    var __telephone = __节点.Element("telephone").Value;
                    var __lng = double.Parse(__节点.Element("location").Element("lng").Value);
                    var __lat = double.Parse(__节点.Element("location").Element("lat").Value);
                    __可能终点.Add(new M地址 { 备注 = __telephone, 名称 = __name, 详细地址 = __address, 坐标 = 转换成谷歌坐标(new M经纬度(__lng, __lat) { 类型 = E坐标类型.百度 }) });
                }
                return null;
            }
            if (__type == "2")
            {
                var __结果 = new M线路(string.Format("{0}->{1}", __起点, __终点));
                foreach (XElement __节点 in __根节点.XPathSelectElements("./result/routes/steps/content"))
                {
                    var __点 = __节点.Element("path").Value;
                    var __说明 = __节点.Element("instructions").Value;
                    __结果.点集合.Add(转换成谷歌坐标(new M经纬度(double.Parse(__点.Split(',')[0]), double.Parse(__点.Split(',')[1])) { 类型 = E坐标类型.百度 }));
                    __结果.步骤说明.Add(过滤字符串(__说明));
                }
                __结果.距离 = int.Parse(__根节点.XPathSelectElement("./result/routes/distance").Value);
                var __备注 = new StringBuilder();
                __备注.AppendFormat("耗时: {0}分钟", (int.Parse(__根节点.XPathSelectElement("./result/routes/duration").Value)) / 60).AppendLine();
                __备注.AppendFormat("白天打车费用: {0}元", __根节点.XPathSelectElements("./result/taxi/detail/total_price").First().Value).AppendLine();
                __备注.AppendFormat("夜间打车费用: {0}元", __根节点.XPathSelectElements("./result/taxi/detail/total_price").Last().Value).AppendLine();
                __结果.备注 = __备注.ToString();
                __可能起点 = null;
                __可能终点 = null;
                return __结果;
            }
            throw new NotImplementedException();
        }

        public static M线路 查询驾车线路(M经纬度 __起点, M经纬度 __终点, string __起点城市, string __终点城市, E驾车路线选择策略 __策略, out List<M地址> __可能起点, out List<M地址> __可能终点)
        {
            __起点 = 转换成百度坐标(__起点);
            __终点 = 转换成百度坐标(__终点);
            string __url = "http://api.map.baidu.com/direction/v1?mode=driving&output=xml&ak={0}&origin={1}&destination={2}&origin_region={3}&destination_region={4}&tactics={5}";
            string __返回值 = "";
            __返回值 = Web服务请求(string.Format(__url, _ak, HttpUtility.UrlEncode(string.Format("{1},{0}", __起点.经度, __起点.纬度)), HttpUtility.UrlEncode(string.Format("{1},{0}", __终点.经度, __终点.纬度)), HttpUtility.UrlEncode(__起点城市), HttpUtility.UrlEncode(__终点城市), (int)__策略));

            var __XML文档 = XDocument.Load(new StringReader(__返回值));
            var __根节点 = __XML文档.Root;
            var __status = __根节点.XPathSelectElement("./status").Value;
            if (__status != "0")
            {
                throw new Exception(__根节点.XPathSelectElement("./message").Value);
            }
            var __type = __根节点.XPathSelectElement("./type").Value;
            if (__type == "2")
            {
                var __结果 = new M线路(string.Format("{0}->{1}", __起点, __终点));
                foreach (XElement __节点 in __根节点.XPathSelectElements("./result/routes/steps/content"))
                {
                    var __点 = __节点.Element("path").Value;
                    var __说明 = __节点.Element("instructions").Value;
                    __结果.点集合.Add(转换成谷歌坐标(new M经纬度(double.Parse(__点.Split(',')[0]), double.Parse(__点.Split(',')[1])) { 类型 = E坐标类型.百度 }));
                    __结果.步骤说明.Add(过滤字符串(__说明));
                }
                __结果.距离 = int.Parse(__根节点.XPathSelectElement("./result/routes/distance").Value);
                var __备注 = new StringBuilder();
                __备注.AppendFormat("耗时: {0}分钟", (int.Parse(__根节点.XPathSelectElement("./result/routes/duration").Value)) / 60).AppendLine();
                __备注.AppendFormat("白天打车费用: {0}元", __根节点.XPathSelectElements("./result/taxi/detail/total_price").First().Value).AppendLine();
                __备注.AppendFormat("夜间打车费用: {0}元", __根节点.XPathSelectElements("./result/taxi/detail/total_price").Last().Value).AppendLine();
                __结果.备注 = __备注.ToString();
                __可能起点 = null;
                __可能终点 = null;
                return __结果;
            }
            throw new NotImplementedException();
        }

        public static List<M线路> 查询公交线路(string __起点, string __终点, string __城市, E驾车路线选择策略 __策略, out List<M地址> __可能起点, out List<M地址> __可能终点)
        {
            string __url = "http://api.map.baidu.com/direction/v1?mode=transit&output=xml&ak={0}&origin={1}&destination={2}&region={3}&tactics={4}";
            string __返回值 = "";
            __返回值 = Web服务请求(string.Format(__url, _ak, HttpUtility.UrlEncode(__起点), HttpUtility.UrlEncode(__终点), HttpUtility.UrlEncode(__城市), (int)__策略));

            var __XML文档 = XDocument.Load(new StringReader(__返回值));
            var __根节点 = __XML文档.Root;
            var __status = __根节点.XPathSelectElement("./status").Value;
            if (__status != "0")
            {
                throw new Exception(__根节点.XPathSelectElement("./message").Value);
            }
            var __type = __根节点.XPathSelectElement("./type").Value;
            var __结果 = new List<M线路>();
            if (__type == "1")
            {
                __可能起点 = new List<M地址>();
                __可能终点 = new List<M地址>();
                foreach (XElement __节点 in __根节点.XPathSelectElements("./result/origin/content"))
                {
                    var __name = __节点.Element("name").Value;
                    var __address = __节点.Element("address").Value;
                    var __lng = double.Parse(__节点.Element("location").Element("lng").Value);
                    var __lat = double.Parse(__节点.Element("location").Element("lat").Value);
                    __可能起点.Add(new M地址 { 名称 = __name, 详细地址 = __address, 坐标 = 转换成谷歌坐标(new M经纬度(__lng, __lat) { 类型 = E坐标类型.百度 }) });
                }
                foreach (XElement __节点 in __根节点.XPathSelectElements("./result/destination/content"))
                {
                    var __name = __节点.Element("name").Value;
                    var __address = __节点.Element("address").Value;
                    var __lng = double.Parse(__节点.Element("location").Element("lng").Value);
                    var __lat = double.Parse(__节点.Element("location").Element("lat").Value);
                    __可能终点.Add(new M地址 { 名称 = __name, 详细地址 = __address, 坐标 = 转换成谷歌坐标(new M经纬度(__lng, __lat) { 类型 = E坐标类型.百度 }) });
                }
                return null;
            }
            if (__type == "2")
            {
                foreach (XElement __节点 in __根节点.XPathSelectElements("./result/routes/scheme"))
                {
                    var __距离 = int.Parse(__节点.XPathSelectElement("./distance").Value);
                    var __时间 = int.Parse(__节点.XPathSelectElement("./duration").Value) / 60;
                    var __线路 = new M线路(string.Format("距离: {0}, 耗时: {1}", __距离, __时间));
                    __线路.距离 = __距离;
                    foreach (XElement __二级节点 in __节点.XPathSelectElements("./steps/info"))
                    {
                        var __起点经度 = double.Parse(__二级节点.XPathSelectElement("./stepOriginLocation/lng").Value);
                        var __起点纬度 = double.Parse(__二级节点.XPathSelectElement("./stepOriginLocation/lat").Value);
                        var __说明 = __二级节点.XPathSelectElement("./stepInstruction").Value;
                        __线路.点集合.Add(转换成谷歌坐标(new M经纬度(__起点经度, __起点纬度) { 类型 = E坐标类型.百度 }));
                        __线路.步骤说明.Add(过滤字符串(__说明));
                    }
                    var __最后一个节点 = __节点.XPathSelectElements("./steps/info").Last();
                    var __终点经度 = double.Parse(__最后一个节点.XPathSelectElement("./stepDestinationLocation/lng").Value);
                    var __终点纬度 = double.Parse(__最后一个节点.XPathSelectElement("./stepDestinationLocation/lat").Value);
                    __线路.点集合.Add(转换成谷歌坐标(new M经纬度(__终点经度, __终点纬度) { 类型 = E坐标类型.百度 }));
                    __结果.Add(__线路);
                }
                __可能起点 = null;
                __可能终点 = null;
                return __结果;
            }
            throw new NotImplementedException();
        }

        public static List<M线路> 查询公交线路(M经纬度 __起点, M经纬度 __终点, string __城市, E驾车路线选择策略 __策略, out List<M地址> __可能起点, out List<M地址> __可能终点)
        {
            __起点 = 转换成百度坐标(__起点);
            __终点 = 转换成百度坐标(__终点);
            string __url = "http://api.map.baidu.com/direction/v1?mode=transit&output=xml&ak={0}&origin={1}&destination={2}&region={3}&tactics={4}";
            string __返回值 = "";
            __返回值 = Web服务请求(string.Format(__url, _ak, HttpUtility.UrlEncode(string.Format("{1},{0}", __起点.经度, __起点.纬度)), HttpUtility.UrlEncode(string.Format("{1},{0}", __终点.经度, __终点.纬度)), HttpUtility.UrlEncode(__城市), (int)__策略));

            var __XML文档 = XDocument.Load(new StringReader(__返回值));
            var __根节点 = __XML文档.Root;
            var __status = __根节点.XPathSelectElement("./status").Value;
            if (__status != "0")
            {
                throw new Exception(__根节点.XPathSelectElement("./message").Value);
            }
            var __type = __根节点.XPathSelectElement("./type").Value;
            var __结果 = new List<M线路>();
            if (__type == "2")
            {
                foreach (XElement __节点 in __根节点.XPathSelectElements("./result/routes/scheme"))
                {
                    var __距离 = int.Parse(__节点.XPathSelectElement("./distance").Value);
                    var __时间 = int.Parse(__节点.XPathSelectElement("./duration").Value) / 60;
                    var __线路 = new M线路(string.Format("距离: {0}, 耗时: {1}", __距离, __时间));
                    __线路.距离 = __距离;
                    foreach (XElement __二级节点 in __节点.XPathSelectElements("./steps/info"))
                    {
                        var __起点经度 = double.Parse(__二级节点.XPathSelectElement("./stepOriginLocation/lng").Value);
                        var __起点纬度 = double.Parse(__二级节点.XPathSelectElement("./stepOriginLocation/lat").Value);
                        var __说明 = __二级节点.XPathSelectElement("./stepInstruction").Value;
                        __线路.点集合.Add(转换成谷歌坐标(new M经纬度(__起点经度, __起点纬度) { 类型 = E坐标类型.百度 }));
                        __线路.步骤说明.Add(过滤字符串(__说明));
                    }
                    var __最后一个节点 = __节点.XPathSelectElements("./steps/info").Last();
                    var __终点经度 = double.Parse(__最后一个节点.XPathSelectElement("./stepDestinationLocation/lng").Value);
                    var __终点纬度 = double.Parse(__最后一个节点.XPathSelectElement("./stepDestinationLocation/lat").Value);
                    __线路.点集合.Add(转换成谷歌坐标(new M经纬度(__终点经度, __终点纬度) { 类型 = E坐标类型.百度 }));
                    __结果.Add(__线路);
                }
                __可能起点 = null;
                __可能终点 = null;
                return __结果;
            }
            throw new NotImplementedException();
        }

        static string Web服务请求(string url)
        {
            var request = WebRequest.Create(url);
            request.Credentials = CredentialCache.DefaultCredentials;
            using (var response = (HttpWebResponse)request.GetResponse())
            {
                Console.WriteLine(response.StatusDescription);
                using (var dataStream = response.GetResponseStream())
                {
                    if (dataStream == null)
                    {
                        throw new Exception("百度服务器无响应");
                    }
                    using (var reader = new StreamReader(dataStream))
                    {
                        string responseFromServer = reader.ReadToEnd();
                        return responseFromServer;
                    }
                }
            }
        }

        private static M经纬度 转换成百度坐标(M经纬度 __原经纬度)
        {
            M经纬度 __结果 = __原经纬度;
            if (__原经纬度.类型 == E坐标类型.谷歌)
            {
                __结果 = HGPS坐标转换.谷歌坐标转百度坐标(__原经纬度);
            }
            else if (__原经纬度.类型 == E坐标类型.设备)
            {
                __结果 = HGPS坐标转换.谷歌坐标转百度坐标(HGPS坐标转换.原始坐标转谷歌坐标(__原经纬度));
            }
            return __结果;
        }

        private static M经纬度 转换成谷歌坐标(M经纬度 __原经纬度)
        {
            M经纬度 __结果 = __原经纬度;
            if (__原经纬度.类型 == E坐标类型.百度)
            {
                __结果 = HGPS坐标转换.百度坐标转谷歌坐标(__原经纬度);
            }
            else if (__原经纬度.类型 == E坐标类型.设备)
            {
                __结果 = HGPS坐标转换.原始坐标转谷歌坐标(__原经纬度);
            }
            return __结果;
        }

        struct M地址编码结果
        {
            /*
	{
		status: 0,
		result: 
		{
		    location: 
			    {
			    lng: 116.30814954222,
			    lat: 40.056885091681
			    },
		    precise: 1,
		    confidence: 80,
		    level: "商务大厦"
		}
	}             
             */
            public int status { get; set; }
            public M地址编码明细 result { get; set; }
        }

        struct M地址编码明细
        {
            public M坐标 location { get; set; }
            public int precise { get; set; }
            public int confidence { get; set; }
            public string level { get; set; }
        }

        struct M坐标
        {
            public float lng { get; set; }
            public float lat { get; set; }
        }

        struct M逆地址编码结果
        {
            /*
status  constant  返回结果状态值， 成功返回0，其他值请查看附录。  
location  
    lat  纬度坐标  
    lng  经度坐标  
formatted_address  结构化地址信息  
business  所在商圈信息，如 "人民大学,中关村,苏州街"  
addressComponent  
    city  城市名  
    district  区县名  
    province  省名  
    street  街道名  
    street_number  街道门牌号               
             */
            public int status { get; set; }
            public M逆地址编码明细 result { get; set; }
        }

        struct M逆地址编码明细
        {
            public M坐标 location { get; set; }

            public string formatted_address { get; set; }

            public string business { get; set; }

            public M详细地址 addressComponent { get; set; }
        }

        struct M详细地址
        {
            public string province { get; set; }
            public string city { get; set; }
            public string district { get; set; }
            public string street { get; set; }
            public string street_number { get; set; }
        }

        struct M区域检索结果
        {
            /*
{
    "status":0,
    "message":"ok",
    "results":[
        {
            "name":"威尼斯水城",
            "location":{
                "lat":32.143804,
                "lng":118.753023
            },
            "address":"浦珠北路北外滩1号(柳州东路198号)",
            "street_id":"5211d219b9c408267dc876c6",
            "telephone":"(025)58579999",
            "uid":"5211d219b9c408267dc876c6"
        },
        {
            "name":"威尼斯水城第六街区",
            "location":{
                "lat":32.150423,
                "lng":118.757557
            },
            "address":"柳洲东路199号",
            "street_id":"c21db9e59620b7fd00ff2d07",
            "uid":"c21db9e59620b7fd00ff2d07"
        }
    ]
}             
             */
            public int status { get; set; }
            public string message { get; set; }

            public M区域检索明细[] results { get; set; }
        }

        struct M区域检索明细
        {
            public string name { get; set; }
            public M坐标 location { get; set; }
            public string address { get; set; }
            public string telephone { get; set; }
            public string street_id { get; set; }
            public string uid { get; set; }
        }

        static string 过滤字符串(string __源字符串)
        {
            __源字符串 = __源字符串.Replace("<b>", "").Replace("</b>", "").Replace("</font>","").Replace("<br/>",Environment.NewLine);
            do
            {
                var __开始位置 = __源字符串.LastIndexOf("<font");
                var __结束位置 = __源字符串.LastIndexOf(">");
                if (__开始位置 >= 0 && __结束位置 > 0)
                {
                    __源字符串 = __源字符串.Remove(__开始位置, __结束位置 - __开始位置 + 1);
                }
                else
                {
                    break;
                }

            } while (true);
            return __源字符串;
        }
    }
}

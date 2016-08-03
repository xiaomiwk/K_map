using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace 显示地图
{
    public static class H图标
    {
        private static Dictionary<E常用图标, Bitmap> _所有图标 = new Dictionary<E常用图标, Bitmap>();

        static H图标()
        {
            _所有图标[E常用图标.默认图标_蓝色] = (Bitmap)System.Windows.Forms.Properties.Resources.ResourceManager.GetObject("blue");
            _所有图标[E常用图标.默认图标_蓝色_小] = (Bitmap)System.Windows.Forms.Properties.Resources.ResourceManager.GetObject("blue_small");
            _所有图标[E常用图标.图钉_蓝色] = (Bitmap)System.Windows.Forms.Properties.Resources.ResourceManager.GetObject("blue_pushpin");
            _所有图标[E常用图标.默认图标_淡蓝色] = (Bitmap)System.Windows.Forms.Properties.Resources.ResourceManager.GetObject("lightblue");
            _所有图标[E常用图标.图钉_淡蓝色] = (Bitmap)System.Windows.Forms.Properties.Resources.ResourceManager.GetObject("lightblue_pushpin");
            _所有图标[E常用图标.默认图标_紫色] = (Bitmap)System.Windows.Forms.Properties.Resources.ResourceManager.GetObject("purple");
            _所有图标[E常用图标.图钉_紫色] = (Bitmap)System.Windows.Forms.Properties.Resources.ResourceManager.GetObject("purple_pushpin");
            _所有图标[E常用图标.默认图标_绿色] = (Bitmap)System.Windows.Forms.Properties.Resources.ResourceManager.GetObject("green");
            _所有图标[E常用图标.默认图标_绿色_小] = (Bitmap)System.Windows.Forms.Properties.Resources.ResourceManager.GetObject("green_small");
            _所有图标[E常用图标.图钉_绿色] = (Bitmap)System.Windows.Forms.Properties.Resources.ResourceManager.GetObject("green_pushpin");
            _所有图标[E常用图标.默认图标_红色] = (Bitmap)System.Windows.Forms.Properties.Resources.ResourceManager.GetObject("red");
            _所有图标[E常用图标.默认图标_红色_小] = (Bitmap)System.Windows.Forms.Properties.Resources.ResourceManager.GetObject("red_small");
            _所有图标[E常用图标.图钉_红色] = (Bitmap)System.Windows.Forms.Properties.Resources.ResourceManager.GetObject("red_pushpin");
            _所有图标[E常用图标.默认图标_橙色] = (Bitmap)System.Windows.Forms.Properties.Resources.ResourceManager.GetObject("orange");
            _所有图标[E常用图标.默认图标_橙色_小] = (Bitmap)System.Windows.Forms.Properties.Resources.ResourceManager.GetObject("orange_small");
            _所有图标[E常用图标.默认图标_黄色] = (Bitmap)System.Windows.Forms.Properties.Resources.ResourceManager.GetObject("yellow");
            _所有图标[E常用图标.默认图标_黄色_小] = (Bitmap)System.Windows.Forms.Properties.Resources.ResourceManager.GetObject("yellow_small");
            _所有图标[E常用图标.图钉_黄色] = (Bitmap)System.Windows.Forms.Properties.Resources.ResourceManager.GetObject("yellow_pushpin");
            _所有图标[E常用图标.默认图标_粉红色] = (Bitmap)System.Windows.Forms.Properties.Resources.ResourceManager.GetObject("pink");
            _所有图标[E常用图标.默认图标_粉红色_小] = (Bitmap)System.Windows.Forms.Properties.Resources.ResourceManager.GetObject("purple_small");
            _所有图标[E常用图标.图钉_粉红色] = (Bitmap)System.Windows.Forms.Properties.Resources.ResourceManager.GetObject("pink_pushpin");
            _所有图标[E常用图标.默认图标_黑色_小] = (Bitmap)System.Windows.Forms.Properties.Resources.ResourceManager.GetObject("black_small");
            _所有图标[E常用图标.默认图标_灰色_小] = (Bitmap)System.Windows.Forms.Properties.Resources.ResourceManager.GetObject("gray_small");
            _所有图标[E常用图标.默认图标_白色_小] = (Bitmap)System.Windows.Forms.Properties.Resources.ResourceManager.GetObject("white_small");
            _所有图标[E常用图标.默认图标_棕色_小] = (Bitmap)System.Windows.Forms.Properties.Resources.ResourceManager.GetObject("brown_small");
            _所有图标[E常用图标.开始] = (Bitmap)System.Windows.Forms.Properties.Resources.ResourceManager.GetObject("go");
            _所有图标[E常用图标.暂停] = (Bitmap)System.Windows.Forms.Properties.Resources.ResourceManager.GetObject("pause");
            _所有图标[E常用图标.停止] = (Bitmap)System.Windows.Forms.Properties.Resources.ResourceManager.GetObject("stop");
        }

        public static Bitmap 获取图标(E常用图标 图标)
        {
            if (!_所有图标.ContainsKey(图标))
            {
                return _所有图标[E常用图标.默认图标_红色];
            }
            return _所有图标[图标];
        }
    }
}

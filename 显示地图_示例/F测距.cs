using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 显示地图;

namespace 显示地图_示例
{
    public class F测距
    {
        F地图 _F地图;

        private M经纬度 _上一个点;

        private ulong? _测距线索引;
        private ulong? _测距点索引;

        private List<M测距> _所有测距 = new List<M测距>();

        private M测距 _当前测距;

        public void 开始()
        {
            this._F地图.MouseClick += out地图_MouseClick;
            this._F地图.MouseDoubleClick += out地图_MouseDoubleClick;
            this._F地图.MouseMove += out地图_MouseMove;
        }

        public void 结束()
        {
            if (_测距点索引.HasValue)
            {
                _F地图.删除点(_测距点索引.Value);
            }
            _测距点索引 = null;

            this._F地图.MouseClick -= out地图_MouseClick;
            this._F地图.MouseDoubleClick -= out地图_MouseDoubleClick;
            this._F地图.MouseMove -= out地图_MouseMove;
        }

        public event Action<int> 测距结果;

        public void 清除所有()
        {
            _所有测距.ForEach(q =>
            {
                q.点集合.ForEach(k => _F地图.删除点(k));
                q.线集合.ForEach(k => _F地图.删除线(k));
            });
        }

        public F测距(F地图 __F地图)
        {
            this._F地图 = __F地图;
            this._F地图.单击点 += _F地图_单击点;

        }

        void _F地图_单击点(object arg1, MouseEventArgs arg2)
        {
            var __测距 = arg1 as M测距;
            if (__测距 != null)
            {
                __测距.点集合.ForEach(q => _F地图.删除点(q));
                __测距.线集合.ForEach(q => _F地图.删除线(q));
                _所有测距.Remove(__测距);
            }
        }

        void out地图_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
            {
                return;
            }

            var __当前位置 = _F地图.屏幕坐标转经纬度(e.Location);
            if (_上一个点 == null)
            {
                //起点
                _当前测距 = new M测距();
                _当前测距.点集合.Add(_F地图.添加点(__当前位置, Properties.Resources.测距起点, "起点", null, null, E标题显示方式.Always));
                _上一个点 = __当前位置;
                return;
            }
            var __距离 = H地图算法.测量两点间间距(_上一个点, __当前位置);
            _当前测距.线集合.Add(_F地图.添加线(new List<M经纬度> { _上一个点, __当前位置 }, 2, Color.FromArgb(252, 135, 78)));
            _当前测距.点集合.Add(_F地图.添加点(__当前位置, Properties.Resources.测距起点, 获取距离描述(__距离 + _当前测距.距离), null, null, E标题显示方式.Always));
            _当前测距.距离 = __距离 + _当前测距.距离;
            _上一个点 = __当前位置;
        }

        void out地图_MouseMove(object sender, MouseEventArgs e)
        {
            var __当前位置 = _F地图.屏幕坐标转经纬度(e.Location);
            if (_上一个点 == null)
            {
                //提示
                if (_测距点索引.HasValue)
                {
                    _F地图.删除点(_测距点索引.Value);
                }
                _测距点索引 = _F地图.添加点(__当前位置, Properties.Resources.测距起点, "右键单击确定起点", null, null, E标题显示方式.Always);
                return;
            }
            if (_测距线索引.HasValue)
            {
                _F地图.删除线(_测距线索引.Value);
            }
            if (_测距点索引.HasValue)
            {
                _F地图.删除点(_测距点索引.Value);
            }
            var __距离 = H地图算法.测量两点间间距(_上一个点, __当前位置);
            _测距点索引 = _F地图.添加点(__当前位置, Properties.Resources.测距起点, string.Format("总长:{0}\n右键单击确定, 右键双击结束", 获取距离描述(__距离 + _当前测距.距离)), null, null, E标题显示方式.Always);
            _测距线索引 = _F地图.添加线(new List<M经纬度> { _上一个点, __当前位置 }, 1, Color.FromArgb(252, 135, 78));
        }

        void out地图_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right || _上一个点 == null)
            {
                return;
            }
            _F地图.删除点(_当前测距.点集合.Last());
            //_F地图.删除线(_当前测距.线集合.Last());
            _当前测距.点集合.RemoveAt(_当前测距.点集合.Count - 1);

            var __当前位置 = _F地图.屏幕坐标转经纬度(e.Location);
            var __距离 = H地图算法.测量两点间间距(_上一个点, __当前位置);
            //_当前测距.线集合.Add(_F地图.添加线(new List<M经纬度> { _上一个点, __当前位置 }, 1, Color.FromArgb(252, 135, 78)));
            _当前测距.点集合.Add(_F地图.添加点(__当前位置, Properties.Resources.测距终点, string.Format("终点:{0}", 获取距离描述(__距离 + _当前测距.距离)), _当前测距, null, E标题显示方式.Always));
            _当前测距.距离 = __距离 + _当前测距.距离;
            _所有测距.Add(_当前测距);
            On测距结果(_当前测距.距离);
            _上一个点 = null;
            if (_测距线索引.HasValue)
            {
                _F地图.删除线(_测距线索引.Value);
            }
            if (_测距点索引.HasValue)
            {
                _F地图.删除点(_测距点索引.Value);
            }
            _测距点索引 = null;
            _测距线索引 = null;
        }

        string 获取距离描述(int __距离)
        {
            if (__距离 > 1000)
            {
                return string.Format("{0:f2}公里", __距离 / 1000.0);
            }
            else
            {
                return string.Format("{0}米", __距离);
            }
        }

        private class M测距
        {
            public List<ulong> 点集合 { get; set; }
            public List<ulong> 线集合 { get; set; }

            public int 距离 { get; set; }

            public M测距()
            {
                点集合 = new List<ulong>();
                线集合 = new List<ulong>();
            }
        }

        protected virtual void On测距结果(int obj)
        {
            var handler = 测距结果;
            if (handler != null) handler(obj);
        }
    }
}

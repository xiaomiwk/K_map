using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;

namespace 下载地图
{

    /// <summary>
    /// form helping to prefetch tiles on local db
    /// </summary>
    public partial class F下载 : Form
    {
        BackgroundWorker worker = new BackgroundWorker();
        List<GPoint> list;
        int zoom;
        GMapProvider provider;
        int sleep;
        int all;
        public bool ShowCompleteMessage = false;
        RectLatLng area;
        GSize maxOfTiles;
        public GMapOverlay Overlay;
        int retry;
        public bool Shuffle = true;
        private const int _线程数 = 8;

        //public readonly Queue<GPoint> CachedTiles = new Queue<GPoint>();

        private DSQLITE db;

        public int failure { get; set; }

        public F下载(string __完整路径)
        {
            InitializeComponent();
            db = new DSQLITE(__完整路径);
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;
            worker.ProgressChanged += worker_ProgressChanged;
            worker.DoWork += worker_DoWork1;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            this.do取消.Click += do取消_Click;

        }

        void do取消_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要取消?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                DialogResult.Yes)
            {
                this.Close();
            }
        }

        readonly AutoResetEvent done = new AutoResetEvent(true);


        public void Start(RectLatLng __area, int __zoom, GMapProvider __provider, int __sleep, int __retry)
        {
            if (!worker.IsBusy)
            {
                this.label1.Text = "...";
                this.progressBarDownload.Value = 0;

                this.area = __area;
                this.zoom = __zoom;
                this.provider = __provider;
                this.sleep = __sleep;
                this.retry = __retry;

                GMaps.Instance.UseMemoryCache = false;
                GMaps.Instance.CacheOnIdleRead = false;
                GMaps.Instance.BoostCacheEngine = true;

                if (Overlay != null)
                {
                    Overlay.Markers.Clear();
                }

                db.打开数据库();

                worker.RunWorkerAsync();

                this.ShowDialog();
            }
        }

        public void Stop()
        {
            done.Set();

            if (worker.IsBusy)
            {
                worker.CancelAsync();
            }

            done.Close();
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (ShowCompleteMessage)
            {
                if (!e.Cancelled)
                {
                    MessageBox.Show(this, "下载完成! => " + ((int)e.Result).ToString() + " / " + all);
                }
                else
                {
                    MessageBox.Show(this, "取消下载! => " + ((int)e.Result).ToString() + " / " + all);
                }
            }

            list.Clear();

            GMaps.Instance.UseMemoryCache = true;
            GMaps.Instance.CacheOnIdleRead = true;
            GMaps.Instance.BoostCacheEngine = false;

            worker.Dispose();

            this.Close();

            db.关闭数据库();
        }

        bool CacheTiles(int __zoom, GPoint p)
        {
            foreach (var pr in provider.Overlays)
            {
                Exception ex;
                PureImage img;

                // tile number inversion(BottomLeft -> TopLeft)
                if (pr.InvertedAxisY)
                {
                    img = GMaps.Instance.GetImageFrom(pr, new GPoint(p.X, maxOfTiles.Height - p.Y), __zoom, out ex);
                }
                else // ok
                {
                    img = GMaps.Instance.GetImageFrom(pr, p, __zoom, out ex);
                }

                if (img != null)
                {
                    db.保存(img.Data.GetBuffer(), p, zoom);
                    img.Dispose();
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (list != null)
            {
                list.Clear();
                list = null;
            }
            list = provider.Projection.GetAreaTileList(area, zoom, 0);
            maxOfTiles = provider.Projection.GetTileMatrixMaxXY(zoom);
            all = list.Count;

            int countOk = 0;
            int retryCount = 0;

            if (Shuffle)
            {
                Shuffle1(list);
            }

            //lock (this)
            //{
            //    CachedTiles.Clear();
            //}

            for (int i = 0; i < all; i++)
            {
                if (worker.CancellationPending)
                    break;

                GPoint p = list[i];
                {
                    if (CacheTiles(zoom, p))
                    {
                        //if (Overlay != null)
                        //{
                        //    lock (this)
                        //    {
                        //        CachedTiles.Enqueue(p);
                        //    }
                        //}
                        countOk++;
                        retryCount = 0;
                    }
                    else
                    {
                        if (++retryCount <= retry) // retry only one
                        {
                            i--;
                            Thread.Sleep(1111);
                            continue;
                        }
                        failure++;
                        MethodInvoker m = delegate
                        {
                            label2.Text = string.Format("下载失败数量: {0}", failure);
                        };
                        Invoke(m);
                        retryCount = 0;
                    }
                }

                worker.ReportProgress((i + 1) * 100 / all, i + 1);

                if (sleep > 0)
                {
                    Thread.Sleep(sleep);
                }
            }

            e.Result = countOk;

            if (!IsDisposed)
            {
                done.WaitOne();
            }
        }

        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.label1.Text = "正在下载层级 (" + zoom + "): " + ((int)e.UserState).ToString() + " / " + all + ", 进度: " + e.ProgressPercentage.ToString() + "%";
            this.progressBarDownload.Value = e.ProgressPercentage;

            //if (Overlay != null)
            //{
            //    //GPoint? l = null;

            //    //lock (this)
            //    //{
            //    //    if (CachedTiles.Count > 0)
            //    //    {
            //    //        l = CachedTiles.Dequeue();
            //    //    }
            //    //}

            //    //if (l.HasValue)
            //    //{
            //    //    var px = Overlay.Control.MapProvider.Projection.FromTileXYToPixel(l.Value);
            //    //    var p = Overlay.Control.MapProvider.Projection.FromPixelToLatLng(px, zoom);

            //    //    var r1 = Overlay.Control.MapProvider.Projection.GetGroundResolution(zoom, p.Lat);
            //    //    var r2 = Overlay.Control.MapProvider.Projection.GetGroundResolution((int)Overlay.Control.Zoom, p.Lat);
            //    //    var sizeDiff = r2 / r1;

            //    //    GMapMarkerTile m = new GMapMarkerTile(p, (int)(Overlay.Control.MapProvider.Projection.TileSize.Width / sizeDiff));
            //    //    Overlay.Markers.Add(m);
            //    //}
            //}
        }

        private void Prefetch_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void Prefetch_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Stop();
        }

        public static void Shuffle1<T>(List<T> deck)
        {
            var random = new Random();
            int N = deck.Count;

            for (int i = 0; i < N; ++i)
            {
                int r = i + random.Next(N - i);
                T t = deck[r];
                deck[r] = deck[i];
                deck[i] = t;
            }
        }

        void worker_DoWork1(object sender, DoWorkEventArgs e)
        {
            if (list != null)
            {
                list.Clear();
                list = null;
            }
            list = provider.Projection.GetAreaTileList(area, zoom, 0);
            maxOfTiles = provider.Projection.GetTileMatrixMaxXY(zoom);
            all = list.Count;

            int countOk = 0;

            if (Shuffle)
            {
                Shuffle1(list);
            }

            //lock (this)
            //{
            //    CachedTiles.Clear();
            //}

            var __任务列表 = new List<Task>();
            for (int j = 0; j < _线程数; j++)
            {

                var temp = Task.Factory.StartNew(q =>
                {
                    var __线程标识 = (int)q;
                    int retryCount = 0;

                    for (int i = __线程标识; i < all; i = i + _线程数)
                    {
                        if (worker.CancellationPending)
                            break;

                        GPoint p = list[i];
                        if (CacheTiles(zoom, p))
                        {
                            //if (Overlay != null)
                            //{
                            //    lock (this)
                            //    {
                            //        CachedTiles.Enqueue(p);
                            //    }
                            //}
                            countOk++;
                            retryCount = 0;
                        }
                        else
                        {
                            if (++retryCount <= retry) // retry only one
                            {
                                i = i - _线程数;
                                Thread.Sleep(1111);
                                continue;
                            }
                            failure++;
                            MethodInvoker m = delegate
                            {
                                label2.Text = string.Format("下载失败数量: {0}", failure);
                            };
                            Invoke(m);
                            retryCount = 0;
                        }

                        worker.ReportProgress(countOk * 100 / all, countOk);

                        if (sleep > 0)
                        {
                            Thread.Sleep(sleep);
                        }
                    }
                }, j);
                __任务列表.Add(temp);
            }
            Task.WaitAll(__任务列表.ToArray());

            e.Result = countOk;

            if (!IsDisposed)
            {
                done.WaitOne();
            }
        }

    }

    //class GMapMarkerTile : GMapMarker
    //{
    //    static Brush Fill = new SolidBrush(Color.FromArgb(155, Color.Blue));

    //    public GMapMarkerTile(PointLatLng p, int size)
    //        : base(p)
    //    {
    //        Size = new System.Drawing.Size(size, size);
    //    }

    //    public override void OnRender(Graphics g)
    //    {
    //        g.FillRectangle(Fill, new Rectangle(LocalPosition.X, LocalPosition.Y, Size.Width, Size.Height));
    //    }
    //}
}

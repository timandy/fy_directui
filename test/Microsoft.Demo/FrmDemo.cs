using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Windows.Forms;

namespace Microsoft.Demo
{
    public partial class FrmDemo : UIForm
    {
        UIButton btnOut;
        UIButton btnInner;
        UIButton btnInner2;
        UILabel label;
        UIProgress progress;
        UILine line;
        UIImage image;
        UIMarquee marquee;
        UILink link;
        UILink link2;

        public FrmDemo()
        {
            InitializeComponent();

            image = new UIImage();
            image.Dock = DockStyle.Right;
            image.Width = 400;
            this.UIControls.Add(image);
            //
            line = new UILine();
            line.Location = new Point(300, 270);
            line.Size = new Size(500, 50);
            line.LineBlendStyle = BlendStyle.FadeInFadeOut;
            line.LineWidth = 2;
            line.LineDashStyle = DashStyle.Dash;
            this.UIControls.Add(line);
            //
            label = new UILabel();
            label.Location = new Point(250, 200);
            label.Size = new Size(100, 50);
            label.Font = new Font("微软雅黑", 13f);
            label.Text = "测试文本测试文本测试文本测试文本测试文本";
            this.UIControls.Add(label);
            //
            progress = new UIProgress();
            progress.Location = new Point(300, 200);
            progress.Percentage = 20;
            progress.Size = new Size(600, 50);
            progress.Anchor = AnchorStyles.None;
            this.UIControls.Add(progress);
            //
            btnOut = new UIButton();
            btnOut.Size = new Size(300, 100);
            btnOut.Location = new Point(10, 20);
            btnOut.Dock = DockStyle.None;
            btnOut.UIParent = this;
            btnOut.Name = "out";
            btnOut.Text = btnOut.Name;
            btnOut.Font = new Font(btnOut.Font.FontFamily, 45f);
            btnOut.TextRenderingHint = TextRenderingHint.AntiAlias;
            btnOut.Click += (sender, e) => Console.WriteLine("单击out");
            this.UIControls.Add(btnOut);

            //
            btnInner2 = new UIButton();
            btnInner2.Size = new Size(50, 20);
            btnInner2.Location = new Point(55, 55);
            btnInner2.UIParent = this.btnOut;
            btnInner2.Name = "in2";
            btnInner2.Text = btnInner2.Name;
            btnInner2.Click += (sender, e) => MessageBox.Show("单击in2");
            this.btnOut.UIControls.Add(btnInner2);
            //
            btnInner = new UIButton();
            btnInner.Size = new Size(50, 20);
            btnInner.Location = new Point(5, 15);
            btnInner.UIParent = this.btnOut;
            btnInner.Name = "in";
            btnInner.Text = btnInner.Name;
            btnInner.Click += (sender, e) => Console.WriteLine("单击in");
            this.btnOut.UIControls.Add(btnInner);
            //
            marquee = new UIMarquee();
            marquee.Size = new Size(801, 4);
            marquee.Location = new Point(100, 200);
            marquee.BorderColor = Color.Transparent;
            this.marquee.BackColor = Color.Transparent;
            marquee.Dock = DockStyle.Bottom;
            marquee.ProgressColor = Color.DodgerBlue;
            this.UIControls.Add(this.marquee);
            this.marquee.SendToBack();
            //
            link = new UILink();
            link.Size = new Size(40, 15);
            link.Location = new Point(500, 10);
            this.link.Font = new Font("微软雅黑", 10f, GraphicsUnit.Point);
            link.Text = "换一张";
            this.UIControls.Add(this.link);
            //
            link2 = new UILink();
            link2.Size = new Size(40, 15);
            link2.Location = new Point(540, 10);
            link2.Text = "换一张";
            this.UIControls.Add(this.link2);
        }

        public void TestCore(FormBorderStyle border, IUIWindow target)
        {
            //初始化
            this.FormBorderStyle = border;
            this.btnOut.UIParent = target;

            //FindUIWindow
            Assert.AreEqual(btnOut.FindUIWindow(), target);
            Assert.AreEqual(btnInner.FindUIWindow(), target);
            Assert.AreEqual(target.FindUIWindow(), target);

            //FindUIChild
            Assert.AreEqual(target.FindUIChild(Point.Empty), null);
            Assert.AreEqual(target.FindUIChild(new Point(10, 20)), this.btnOut);
            Assert.AreEqual(target.FindUIChild(new Point(109, 69)), this.btnOut);
            Assert.AreEqual(target.FindUIChild(new Point(15, 35)), this.btnInner);
            Assert.AreEqual(target.FindUIChild(new Point(64, 54)), this.btnInner);
            //FindUIChild
            Assert.AreEqual(this.btnOut.FindUIChild(Point.Empty), null);
            Assert.AreEqual(this.btnOut.FindUIChild(new Point(5, 15)), this.btnInner);
            Assert.AreEqual(this.btnOut.FindUIChild(new Point(54, 34)), this.btnInner);
            //FindUIChild
            Assert.AreEqual(target.FindUIChild("in2"), this.btnInner2);
            //PointToClient
            Point p = new Point(15, 35);//window client
            Point sp = target.PointToScreen(p);
            Assert.AreEqual(target.PointToClient(sp), p);
            Assert.AreEqual(this.btnOut.PointToClient(sp), new Point(5, 15));
            Assert.AreEqual(this.btnInner.PointToClient(sp), Point.Empty);
            //PointToScreen
            Assert.AreEqual(target.PointToScreen(p), sp);
            Assert.AreEqual(this.btnOut.PointToScreen(new Point(5, 15)), sp);
            Assert.AreEqual(this.btnInner.PointToScreen(Point.Empty), sp);
            //PointToUIControl
            Assert.AreEqual(target.PointToUIControl(p), p);
            Assert.AreEqual(this.btnOut.PointToUIControl(p), new Point(5, 15));
            Assert.AreEqual(this.btnInner.PointToUIControl(p), Point.Empty);
            //PointToUIWindow
            Assert.AreEqual(target.PointToUIWindow(p), p);
            Assert.AreEqual(this.btnOut.PointToUIWindow(new Point(5, 15)), p);
            Assert.AreEqual(this.btnInner.PointToUIWindow(Point.Empty), p);
            //RectangleToClient
            Rectangle r = new Rectangle(15, 35, 10, 20);//window client
            Rectangle sr = target.RectangleToScreen(r);
            Assert.AreEqual(target.RectangleToClient(sr), r);
            Assert.AreEqual(this.btnOut.RectangleToClient(sr), new Rectangle(5, 15, 10, 20));
            Assert.AreEqual(this.btnInner.RectangleToClient(sr), new Rectangle(0, 0, 10, 20));
            //RectangleToScreen
            Assert.AreEqual(target.RectangleToScreen(r), sr);
            Assert.AreEqual(this.btnOut.RectangleToScreen(new Rectangle(5, 15, 10, 20)), sr);
            Assert.AreEqual(this.btnInner.RectangleToScreen(new Rectangle(0, 0, 10, 20)), sr);
            //RectangleToUIControl
            Assert.AreEqual(target.RectangleToUIControl(r), r);
            Assert.AreEqual(this.btnOut.RectangleToUIControl(r), new Rectangle(5, 15, 10, 20));
            Assert.AreEqual(this.btnInner.RectangleToUIControl(r), new Rectangle(0, 0, 10, 20));
            //RectangleToUIWindow
            Assert.AreEqual(target.RectangleToUIWindow(r), r);
            Assert.AreEqual(this.btnOut.RectangleToUIWindow(new Rectangle(5, 15, 10, 20)), r);
            Assert.AreEqual(this.btnInner.RectangleToUIWindow(new Rectangle(0, 0, 10, 20)), r);
            //
            this.btnOut.SendToBack();
            this.btnOut.BringToFront();
        }

        private void btnWithBorder_Click(object sender, EventArgs e)
        {
            this.TestCore(FormBorderStyle.Sizable, this);
        }

        private void btnNoBorder_Click(object sender, EventArgs e)
        {
            this.TestCore(FormBorderStyle.None, this);
        }

        private void btnWithBorder2_Click(object sender, EventArgs e)
        {
            this.TestCore(FormBorderStyle.Sizable, this.uiWinControl1);
        }

        private void btnNoBorder2_Click(object sender, EventArgs e)
        {
            this.TestCore(FormBorderStyle.None, this.uiWinControl1);
        }

        private void btnAddFrame_Click(object sender, EventArgs e)
        {
            this.image.AddFrame();
            this.image.AddFrame();
            this.image.AddFrame();
            this.image.AddFrame();
            this.image.AddFrame();
            this.image.AddFrame();
        }

        private void btnClearFrame_Click(object sender, EventArgs e)
        {
            this.image.ClearFrame();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.marquee.Stopped = !this.marquee.Stopped;
        }
    }
}

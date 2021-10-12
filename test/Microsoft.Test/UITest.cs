using System.Windows.Forms;
using Microsoft.Demo;
using NUnit.Framework;

namespace Microsoft.Test
{
    public class UITest
    {
        [Test]
        public void TestSizeableForm()
        {
            FrmDemo frm = new FrmDemo();
            frm.TestCore(FormBorderStyle.Sizable, frm);
        }

        [Test]
        public void TestNoneForm()
        {
            FrmDemo frm = new FrmDemo();
            frm.TestCore(FormBorderStyle.None, frm);
        }

        [Test]
        public void TestSizeableControl()
        {
            FrmDemo frm = new FrmDemo();
            frm.TestCore(FormBorderStyle.Sizable, frm.uiWinControl1);
        }

        [Test]
        public void TestNoneControl()
        {
            FrmDemo frm = new FrmDemo();
            frm.TestCore(FormBorderStyle.None, frm.uiWinControl1);
        }
    }
}
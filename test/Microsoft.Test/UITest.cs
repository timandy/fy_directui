using System;
using System.Windows.Forms;
using Microsoft.Demo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.Test
{
    [TestClass]
    public class UITest
    {
        [TestMethod]
        public void TestSizeableForm()
        {
            FrmDemo frm = new FrmDemo();
            frm.TestCore(FormBorderStyle.Sizable, frm);
        }

        [TestMethod]
        public void TestNoneForm()
        {
            FrmDemo frm = new FrmDemo();
            frm.TestCore(FormBorderStyle.None, frm);
        }

        [TestMethod]
        public void TestSizeableControl()
        {
            FrmDemo frm = new FrmDemo();
            frm.TestCore(FormBorderStyle.Sizable, frm.uiWinControl1);
        }

        [TestMethod]
        public void TestNoneControl()
        {
            FrmDemo frm = new FrmDemo();
            frm.TestCore(FormBorderStyle.None, frm.uiWinControl1);
        }
    }
}

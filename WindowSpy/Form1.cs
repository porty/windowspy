using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowSpy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var enumerator = new WindowEnumerator();
            enumerator.Thing();

            treeView1.BeginUpdate();
            treeView1.Nodes.Clear();
            foreach (var window in enumerator.Windows)
            {
                var node = new TreeNode(window.ToString(), window.IconIndex, window.IconIndex);
                treeView1.Nodes.Add(node);
            }
            treeView1.EndUpdate();
        }
    }
}

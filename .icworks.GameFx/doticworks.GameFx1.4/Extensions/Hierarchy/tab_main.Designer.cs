/*
 * 由SharpDevelop创建。
 * 用户： DELL
 * 日期: 2021/2/4
 * 时间: Go home day！ 10:36
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
namespace Hierarchy
{
	partial class tab_main
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Disposes resources used by the control.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("GameWorld");
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.tree = new System.Windows.Forms.TreeView();
			this.panright = new System.Windows.Forms.Panel();
			this.textBox1 = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize) (this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.panright.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.BackColor = System.Drawing.Color.Gray;
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.tree);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.panright);
			this.splitContainer1.Size = new System.Drawing.Size(695, 419);
			this.splitContainer1.SplitterDistance = 470;
			this.splitContainer1.SplitterWidth = 3;
			this.splitContainer1.TabIndex = 0;
			// 
			// tree
			// 
			this.tree.BackColor = System.Drawing.Color.DimGray;
			this.tree.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tree.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.tree.ForeColor = System.Drawing.Color.DarkGray;
			this.tree.Location = new System.Drawing.Point(0, 0);
			this.tree.Name = "tree";
			treeNode1.Name = "root";
			treeNode1.Text = "GameWorld";
			this.tree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {treeNode1});
			this.tree.Size = new System.Drawing.Size(470, 419);
			this.tree.TabIndex = 0;
			this.tree.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TreeNodeMouseClick);
			// 
			// panright
			// 
			this.panright.BackColor = System.Drawing.Color.DimGray;
			this.panright.Controls.Add(this.textBox1);
			this.panright.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panright.Location = new System.Drawing.Point(0, 0);
			this.panright.Name = "panright";
			this.panright.Size = new System.Drawing.Size(222, 419);
			this.panright.TabIndex = 0;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(3, 3);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(176, 21);
			this.textBox1.TabIndex = 0;
			// 
			// tab_main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.splitContainer1);
			this.Name = "tab_main";
			this.Size = new System.Drawing.Size(695, 419);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize) (this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.panright.ResumeLayout(false);
			this.panright.PerformLayout();
			this.ResumeLayout(false);
		}

		private System.Windows.Forms.Panel panright;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TreeView tree;
	}
}

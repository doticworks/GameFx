/*
 * 由SharpDevelop创建。
 * 用户： DELL
 * 日期: 2021/1/15
 * 时间: 17:11
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
namespace doticworks.GameFx
{
	partial class GameBox
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
			this.SuspendLayout();
			// 
			// GameBox
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Silver;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.DoubleBuffered = true;
			this.Font = new System.Drawing.Font("Segoe UI Symbol", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.Name = "GameBox";
			this.Size = new System.Drawing.Size(1039, 504);
			this.SizeChanged += new System.EventHandler(this.GameBoxSizeChanged);
			this.ResumeLayout(false);
		}
	}
}

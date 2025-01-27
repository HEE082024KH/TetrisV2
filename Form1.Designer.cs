namespace TetrisV2;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        pictureBox1 = new System.Windows.Forms.PictureBox();
        pictureBox2 = new System.Windows.Forms.PictureBox();
        label1 = new System.Windows.Forms.Label();
        label2 = new System.Windows.Forms.Label();
        label3 = new System.Windows.Forms.Label();
        ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
        ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
        SuspendLayout();
        // 
        // pictureBox1
        // 
        pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
        pictureBox1.Location = new System.Drawing.Point(235, 20);
        pictureBox1.Name = "pictureBox1";
        pictureBox1.Size = new System.Drawing.Size(731, 632);
        pictureBox1.TabIndex = 0;
        pictureBox1.TabStop = false;
        pictureBox1.Click += pictureBox1_Click;
        // 
        // pictureBox2
        // 
        pictureBox2.Location = new System.Drawing.Point(759, 321);
        pictureBox2.Name = "pictureBox2";
        pictureBox2.Size = new System.Drawing.Size(211, 319);
        pictureBox2.TabIndex = 1;
        pictureBox2.TabStop = false;
        pictureBox2.Click += pictureBox2_Click;
        // 
        // label1
        // 
        label1.Font = new System.Drawing.Font("Segoe UI", 18F);
        label1.Location = new System.Drawing.Point(759, 28);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(196, 54);
        label1.TabIndex = 2;
        label1.Text = "Score:";
        label1.Click += label1_Click;
        // 
        // label2
        // 
        label2.Font = new System.Drawing.Font("Segoe UI", 15F);
        label2.Location = new System.Drawing.Point(762, 82);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(196, 41);
        label2.TabIndex = 3;
        label2.Text = "Level:";
        label2.Click += label2_Click;
        // 
        // label3
        // 
        label3.Font = new System.Drawing.Font("Segoe UI", 15F);
        label3.Location = new System.Drawing.Point(759, 285);
        label3.Name = "label3";
        label3.Size = new System.Drawing.Size(84, 33);
        label3.TabIndex = 4;
        label3.Text = "Next";
        label3.Click += label3_Click;
        // 
        // Form1
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.Color.Black;
        ClientSize = new System.Drawing.Size(982, 653);
        Controls.Add(label3);
        Controls.Add(label2);
        Controls.Add(label1);
        Controls.Add(pictureBox2);
        Controls.Add(pictureBox1);
        Text = "Form1";
        ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
        ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
        ResumeLayout(false);
    }

    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;

    private System.Windows.Forms.Label label1;

    private System.Windows.Forms.PictureBox pictureBox2;

    private System.Windows.Forms.PictureBox pictureBox1;

    #endregion
}
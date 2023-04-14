
namespace FocusForce
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.buttonToggleGuard = new System.Windows.Forms.Button();
            this.timerCheck = new System.Windows.Forms.Timer(this.components);
            this.buttonAssignCombo = new System.Windows.Forms.Button();
            this.labelKeyCombo = new System.Windows.Forms.Label();
            this.labelEnabled = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.checkBoxStartMinimized = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // buttonToggleGuard
            // 
            this.buttonToggleGuard.Location = new System.Drawing.Point(24, 68);
            this.buttonToggleGuard.Name = "buttonToggleGuard";
            this.buttonToggleGuard.Size = new System.Drawing.Size(149, 45);
            this.buttonToggleGuard.TabIndex = 0;
            this.buttonToggleGuard.Text = "Enable / disable guard";
            this.buttonToggleGuard.UseVisualStyleBackColor = true;
            this.buttonToggleGuard.Click += new System.EventHandler(this.buttonToggleGuard_Click);
            // 
            // timerCheck
            // 
            this.timerCheck.Tick += new System.EventHandler(this.timerCheck_Tick);
            // 
            // buttonAssignCombo
            // 
            this.buttonAssignCombo.Location = new System.Drawing.Point(24, 132);
            this.buttonAssignCombo.Name = "buttonAssignCombo";
            this.buttonAssignCombo.Size = new System.Drawing.Size(149, 46);
            this.buttonAssignCombo.TabIndex = 1;
            this.buttonAssignCombo.Text = "Assign key combo";
            this.buttonAssignCombo.UseVisualStyleBackColor = true;
            this.buttonAssignCombo.Click += new System.EventHandler(this.buttonAssignCombo_Click);
            // 
            // labelKeyCombo
            // 
            this.labelKeyCombo.AutoSize = true;
            this.labelKeyCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelKeyCombo.Location = new System.Drawing.Point(240, 140);
            this.labelKeyCombo.Name = "labelKeyCombo";
            this.labelKeyCombo.Size = new System.Drawing.Size(152, 25);
            this.labelKeyCombo.TabIndex = 2;
            this.labelKeyCombo.Text = "labelKeyCombo";
            // 
            // labelEnabled
            // 
            this.labelEnabled.AutoSize = true;
            this.labelEnabled.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelEnabled.Location = new System.Drawing.Point(240, 75);
            this.labelEnabled.Name = "labelEnabled";
            this.labelEnabled.Size = new System.Drawing.Size(137, 25);
            this.labelEnabled.TabIndex = 3;
            this.labelEnabled.Text = "labelEnabled";
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelStatus.Location = new System.Drawing.Point(21, 24);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(100, 24);
            this.labelStatus.TabIndex = 4;
            this.labelStatus.Text = "labelStatus";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Location = new System.Drawing.Point(0, 258);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(443, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "DCS Focus Guard";
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // checkBoxStartMinimized
            // 
            this.checkBoxStartMinimized.AutoSize = true;
            this.checkBoxStartMinimized.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxStartMinimized.Location = new System.Drawing.Point(25, 204);
            this.checkBoxStartMinimized.Name = "checkBoxStartMinimized";
            this.checkBoxStartMinimized.Size = new System.Drawing.Size(159, 28);
            this.checkBoxStartMinimized.TabIndex = 6;
            this.checkBoxStartMinimized.Text = "Start minimized";
            this.checkBoxStartMinimized.UseVisualStyleBackColor = true;
            this.checkBoxStartMinimized.CheckedChanged += new System.EventHandler(this.checkBoxStartMinimized_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 280);
            this.Controls.Add(this.checkBoxStartMinimized);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.labelEnabled);
            this.Controls.Add(this.labelKeyCombo);
            this.Controls.Add(this.buttonAssignCombo);
            this.Controls.Add(this.buttonToggleGuard);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "DCS Focus Guard";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonToggleGuard;
        private System.Windows.Forms.Timer timerCheck;
        private System.Windows.Forms.Button buttonAssignCombo;
        private System.Windows.Forms.Label labelKeyCombo;
        private System.Windows.Forms.Label labelEnabled;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.CheckBox checkBoxStartMinimized;
    }
}


namespace Paint
{
    partial class Paint
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Paint));
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.FileItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAsItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.CloseItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.ExitItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Tools = new System.Windows.Forms.ToolStripMenuItem();
            this.ClearItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.PencilItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FillItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TextItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EraserItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PipetteItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LineItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RectangleItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EllipseItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WindowsItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolBar = new System.Windows.Forms.ToolStrip();
            this.Pencil = new System.Windows.Forms.ToolStripButton();
            this.Fill = new System.Windows.Forms.ToolStripButton();
            this.TextTool = new System.Windows.Forms.ToolStripButton();
            this.Eraser = new System.Windows.Forms.ToolStripButton();
            this.Pipette = new System.Windows.Forms.ToolStripButton();
            this.LineTool = new System.Windows.Forms.ToolStripButton();
            this.RectangleTool = new System.Windows.Forms.ToolStripButton();
            this.EllepseTool = new System.Windows.Forms.ToolStripButton();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.MainMenu.SuspendLayout();
            this.toolBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileItem,
            this.Tools,
            this.WindowsItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(842, 24);
            this.MainMenu.TabIndex = 1;
            this.MainMenu.Text = "MainMenu";
            // 
            // FileItem
            // 
            this.FileItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewItem,
            this.OpenItem,
            this.SaveItem,
            this.SaveAsItem,
            this.toolStripMenuItem1,
            this.CloseItem,
            this.toolStripMenuItem2,
            this.ExitItem});
            this.FileItem.Name = "FileItem";
            this.FileItem.Size = new System.Drawing.Size(48, 20);
            this.FileItem.Text = "&Файл";
            // 
            // NewItem
            // 
            this.NewItem.Image = ((System.Drawing.Image)(resources.GetObject("NewItem.Image")));
            this.NewItem.Name = "NewItem";
            this.NewItem.Size = new System.Drawing.Size(153, 22);
            this.NewItem.Text = "&Новый";
            this.NewItem.Click += new System.EventHandler(this.NewItem_Click);
            // 
            // OpenItem
            // 
            this.OpenItem.Image = ((System.Drawing.Image)(resources.GetObject("OpenItem.Image")));
            this.OpenItem.Name = "OpenItem";
            this.OpenItem.Size = new System.Drawing.Size(153, 22);
            this.OpenItem.Text = "&Открыть";
            this.OpenItem.Click += new System.EventHandler(this.OpenItem_Click);
            // 
            // SaveItem
            // 
            this.SaveItem.Image = ((System.Drawing.Image)(resources.GetObject("SaveItem.Image")));
            this.SaveItem.Name = "SaveItem";
            this.SaveItem.Size = new System.Drawing.Size(153, 22);
            this.SaveItem.Text = "&Сохранить";
            this.SaveItem.Click += new System.EventHandler(this.SaveItem_Click);
            // 
            // SaveAsItem
            // 
            this.SaveAsItem.Image = ((System.Drawing.Image)(resources.GetObject("SaveAsItem.Image")));
            this.SaveAsItem.Name = "SaveAsItem";
            this.SaveAsItem.Size = new System.Drawing.Size(153, 22);
            this.SaveAsItem.Text = "Сохранить &как";
            this.SaveAsItem.Click += new System.EventHandler(this.SaveAsItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(150, 6);
            // 
            // CloseItem
            // 
            this.CloseItem.Image = ((System.Drawing.Image)(resources.GetObject("CloseItem.Image")));
            this.CloseItem.Name = "CloseItem";
            this.CloseItem.Size = new System.Drawing.Size(153, 22);
            this.CloseItem.Text = "&Закрыть";
            this.CloseItem.Click += new System.EventHandler(this.CloseItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(150, 6);
            // 
            // ExitItem
            // 
            this.ExitItem.Image = ((System.Drawing.Image)(resources.GetObject("ExitItem.Image")));
            this.ExitItem.Name = "ExitItem";
            this.ExitItem.Size = new System.Drawing.Size(153, 22);
            this.ExitItem.Text = "&Выход";
            this.ExitItem.Click += new System.EventHandler(this.ExitItem_Click);
            // 
            // Tools
            // 
            this.Tools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ClearItem,
            this.toolStripMenuItem3,
            this.PencilItem,
            this.FillItem,
            this.TextItem,
            this.EraserItem,
            this.PipetteItem,
            this.LineItem,
            this.RectangleItem,
            this.EllipseItem});
            this.Tools.Name = "Tools";
            this.Tools.Size = new System.Drawing.Size(95, 20);
            this.Tools.Text = "&Инструменты";
            // 
            // ClearItem
            // 
            this.ClearItem.Image = ((System.Drawing.Image)(resources.GetObject("ClearItem.Image")));
            this.ClearItem.Name = "ClearItem";
            this.ClearItem.Size = new System.Drawing.Size(163, 22);
            this.ClearItem.Text = "&Очистить";
            this.ClearItem.Click += new System.EventHandler(this.ClearItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(160, 6);
            // 
            // PencilItem
            // 
            this.PencilItem.Image = ((System.Drawing.Image)(resources.GetObject("PencilItem.Image")));
            this.PencilItem.Name = "PencilItem";
            this.PencilItem.Size = new System.Drawing.Size(163, 22);
            this.PencilItem.Text = "&Карандаш";
            this.PencilItem.Click += new System.EventHandler(this.PencilItem_Click);
            // 
            // FillItem
            // 
            this.FillItem.Image = ((System.Drawing.Image)(resources.GetObject("FillItem.Image")));
            this.FillItem.Name = "FillItem";
            this.FillItem.Size = new System.Drawing.Size(163, 22);
            this.FillItem.Text = "&Заливка";
            this.FillItem.Click += new System.EventHandler(this.FillItem_Click);
            // 
            // TextItem
            // 
            this.TextItem.Image = ((System.Drawing.Image)(resources.GetObject("TextItem.Image")));
            this.TextItem.Name = "TextItem";
            this.TextItem.Size = new System.Drawing.Size(163, 22);
            this.TextItem.Text = "&Текст";
            this.TextItem.Click += new System.EventHandler(this.TextItem_Click);
            // 
            // EraserItem
            // 
            this.EraserItem.Image = ((System.Drawing.Image)(resources.GetObject("EraserItem.Image")));
            this.EraserItem.Name = "EraserItem";
            this.EraserItem.Size = new System.Drawing.Size(163, 22);
            this.EraserItem.Text = "&Резинка";
            this.EraserItem.Click += new System.EventHandler(this.EraserItem_Click);
            // 
            // PipetteItem
            // 
            this.PipetteItem.Image = ((System.Drawing.Image)(resources.GetObject("PipetteItem.Image")));
            this.PipetteItem.Name = "PipetteItem";
            this.PipetteItem.Size = new System.Drawing.Size(163, 22);
            this.PipetteItem.Text = "&Пипетка";
            this.PipetteItem.Click += new System.EventHandler(this.PipetteItem_Click);
            // 
            // LineItem
            // 
            this.LineItem.Image = ((System.Drawing.Image)(resources.GetObject("LineItem.Image")));
            this.LineItem.Name = "LineItem";
            this.LineItem.Size = new System.Drawing.Size(163, 22);
            this.LineItem.Text = "&Линия";
            this.LineItem.Click += new System.EventHandler(this.LineItem_Click);
            // 
            // RectangleItem
            // 
            this.RectangleItem.Image = ((System.Drawing.Image)(resources.GetObject("RectangleItem.Image")));
            this.RectangleItem.Name = "RectangleItem";
            this.RectangleItem.Size = new System.Drawing.Size(163, 22);
            this.RectangleItem.Text = "Пря&моугольник";
            this.RectangleItem.Click += new System.EventHandler(this.RectangleItem_Click);
            // 
            // EllipseItem
            // 
            this.EllipseItem.Image = ((System.Drawing.Image)(resources.GetObject("EllipseItem.Image")));
            this.EllipseItem.Name = "EllipseItem";
            this.EllipseItem.Size = new System.Drawing.Size(163, 22);
            this.EllipseItem.Text = "Эллип&с";
            this.EllipseItem.Click += new System.EventHandler(this.EllipseItem_Click);
            // 
            // WindowsItem
            // 
            this.WindowsItem.Name = "WindowsItem";
            this.WindowsItem.Size = new System.Drawing.Size(48, 20);
            this.WindowsItem.Text = "&Окно";
            // 
            // toolBar
            // 
            this.toolBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Pencil,
            this.Fill,
            this.TextTool,
            this.Eraser,
            this.Pipette,
            this.LineTool,
            this.RectangleTool,
            this.EllepseTool});
            this.toolBar.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolBar.Location = new System.Drawing.Point(0, 24);
            this.toolBar.MaximumSize = new System.Drawing.Size(60, 565);
            this.toolBar.MinimumSize = new System.Drawing.Size(60, 565);
            this.toolBar.Name = "toolBar";
            this.toolBar.Size = new System.Drawing.Size(60, 565);
            this.toolBar.TabIndex = 4;
            this.toolBar.Text = "toolBar";
            // 
            // Pencil
            // 
            this.Pencil.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Pencil.Image = ((System.Drawing.Image)(resources.GetObject("Pencil.Image")));
            this.Pencil.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Pencil.Name = "Pencil";
            this.Pencil.Size = new System.Drawing.Size(24, 24);
            this.Pencil.ToolTipText = "Карандаш";
            this.Pencil.Click += new System.EventHandler(this.Pencil_Click);
            // 
            // Fill
            // 
            this.Fill.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Fill.Image = ((System.Drawing.Image)(resources.GetObject("Fill.Image")));
            this.Fill.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Fill.Name = "Fill";
            this.Fill.Size = new System.Drawing.Size(24, 24);
            this.Fill.ToolTipText = "Заливка";
            this.Fill.Click += new System.EventHandler(this.Fill_Click);
            // 
            // TextTool
            // 
            this.TextTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TextTool.Image = ((System.Drawing.Image)(resources.GetObject("TextTool.Image")));
            this.TextTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TextTool.Name = "TextTool";
            this.TextTool.Size = new System.Drawing.Size(24, 24);
            this.TextTool.ToolTipText = "Текст";
            this.TextTool.Click += new System.EventHandler(this.TextTool_Click);
            // 
            // Eraser
            // 
            this.Eraser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Eraser.Image = ((System.Drawing.Image)(resources.GetObject("Eraser.Image")));
            this.Eraser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Eraser.Name = "Eraser";
            this.Eraser.Size = new System.Drawing.Size(24, 24);
            this.Eraser.ToolTipText = "Ластик";
            this.Eraser.Click += new System.EventHandler(this.Eraser_Click);
            // 
            // Pipette
            // 
            this.Pipette.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Pipette.Image = ((System.Drawing.Image)(resources.GetObject("Pipette.Image")));
            this.Pipette.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Pipette.Name = "Pipette";
            this.Pipette.Size = new System.Drawing.Size(24, 24);
            this.Pipette.ToolTipText = "Пипетка";
            this.Pipette.Click += new System.EventHandler(this.Pipette_Click);
            // 
            // LineTool
            // 
            this.LineTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.LineTool.Image = ((System.Drawing.Image)(resources.GetObject("LineTool.Image")));
            this.LineTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LineTool.Name = "LineTool";
            this.LineTool.Size = new System.Drawing.Size(24, 24);
            this.LineTool.ToolTipText = "Линия";
            this.LineTool.Click += new System.EventHandler(this.LineTool_Click);
            // 
            // RectangleTool
            // 
            this.RectangleTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RectangleTool.Image = ((System.Drawing.Image)(resources.GetObject("RectangleTool.Image")));
            this.RectangleTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RectangleTool.Name = "RectangleTool";
            this.RectangleTool.Size = new System.Drawing.Size(24, 24);
            this.RectangleTool.ToolTipText = "Прямоугольник";
            this.RectangleTool.Click += new System.EventHandler(this.RectangleTool_Click);
            // 
            // EllepseTool
            // 
            this.EllepseTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.EllepseTool.Image = ((System.Drawing.Image)(resources.GetObject("EllepseTool.Image")));
            this.EllepseTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EllepseTool.Name = "EllepseTool";
            this.EllepseTool.Size = new System.Drawing.Size(24, 24);
            this.EllepseTool.ToolTipText = "Эллипс";
            this.EllepseTool.Click += new System.EventHandler(this.EllepseTool_Click);
            // 
            // Paint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 589);
            this.Controls.Add(this.toolBar);
            this.Controls.Add(this.MainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.MainMenu;
            this.Name = "Paint";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Рисовалка";
            this.Load += new System.EventHandler(this.Paint_Load);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.toolBar.ResumeLayout(false);
            this.toolBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem FileItem;
        private System.Windows.Forms.ToolStripMenuItem NewItem;
        private System.Windows.Forms.ToolStripMenuItem OpenItem;
        private System.Windows.Forms.ToolStripMenuItem SaveItem;
        private System.Windows.Forms.ToolStripMenuItem SaveAsItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem CloseItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem ExitItem;
        private System.Windows.Forms.ToolStripMenuItem Tools;
        private System.Windows.Forms.ToolStripMenuItem WindowsItem;
        private System.Windows.Forms.ToolStripMenuItem ClearItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem PencilItem;
        private System.Windows.Forms.ToolStripMenuItem FillItem;
        private System.Windows.Forms.ToolStripMenuItem TextItem;
        private System.Windows.Forms.ToolStripMenuItem EraserItem;
        private System.Windows.Forms.ToolStripMenuItem PipetteItem;
        private System.Windows.Forms.ToolStripMenuItem LineItem;
        private System.Windows.Forms.ToolStripMenuItem RectangleItem;
        private System.Windows.Forms.ToolStripMenuItem EllipseItem;
        private System.Windows.Forms.ToolStrip toolBar;
        private System.Windows.Forms.ToolStripButton Pencil;
        private System.Windows.Forms.ToolStripButton Fill;
        private System.Windows.Forms.ToolStripButton TextTool;
        private System.Windows.Forms.ToolStripButton Eraser;
        private System.Windows.Forms.ToolStripButton Pipette;
        private System.Windows.Forms.ToolStripButton LineTool;
        private System.Windows.Forms.ToolStripButton RectangleTool;
        private System.Windows.Forms.ToolStripButton EllepseTool;
        private System.Windows.Forms.ColorDialog colorDialog;
    }
}


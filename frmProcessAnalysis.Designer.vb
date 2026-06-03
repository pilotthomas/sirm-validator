<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProcessAnalysis
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProcessAnalysis))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.chkViewImage = New System.Windows.Forms.CheckBox()
        Me.lblRefreshed = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpEnd = New System.Windows.Forms.DateTimePicker()
        Me.dtpStart = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnCallProc = New System.Windows.Forms.Button()
        Me.grdAnalysis = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.menuMain = New System.Windows.Forms.MenuStrip()
        Me.FIleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupByToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DefaultToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.IndexedByToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ListImageIOIndexedIntoDoclinkBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CommonDataSet = New Maxum.CommonDataSet()
        Me.dtp = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.C1TrueDBGrid1 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.ListImageIO_IndexedIntoDoclinkTableAdapter = New Maxum.CommonDataSetTableAdapters.ListImageIO_IndexedIntoDoclinkTableAdapter()
        Me.Panel1.SuspendLayout()
        CType(Me.grdAnalysis, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.menuMain.SuspendLayout()
        CType(Me.ListImageIOIndexedIntoDoclinkBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CommonDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1TrueDBGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.chkViewImage)
        Me.Panel1.Controls.Add(Me.lblRefreshed)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.dtpEnd)
        Me.Panel1.Controls.Add(Me.dtpStart)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.btnCallProc)
        Me.Panel1.Controls.Add(Me.grdAnalysis)
        Me.Panel1.Controls.Add(Me.menuMain)
        Me.Panel1.Location = New System.Drawing.Point(5, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(775, 417)
        Me.Panel1.TabIndex = 0
        '
        'chkViewImage
        '
        Me.chkViewImage.AutoSize = True
        Me.chkViewImage.Location = New System.Drawing.Point(495, 43)
        Me.chkViewImage.Name = "chkViewImage"
        Me.chkViewImage.Size = New System.Drawing.Size(81, 17)
        Me.chkViewImage.TabIndex = 8
        Me.chkViewImage.Text = "View Image"
        Me.chkViewImage.UseVisualStyleBackColor = True
        '
        'lblRefreshed
        '
        Me.lblRefreshed.AccessibleRole = System.Windows.Forms.AccessibleRole.RowHeader
        Me.lblRefreshed.AutoSize = True
        Me.lblRefreshed.Location = New System.Drawing.Point(363, 8)
        Me.lblRefreshed.Name = "lblRefreshed"
        Me.lblRefreshed.Size = New System.Drawing.Size(0, 13)
        Me.lblRefreshed.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AccessibleRole = System.Windows.Forms.AccessibleRole.RowHeader
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(189, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "End Date"
        '
        'dtpEnd
        '
        Me.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEnd.Location = New System.Drawing.Point(247, 37)
        Me.dtpEnd.Name = "dtpEnd"
        Me.dtpEnd.Size = New System.Drawing.Size(107, 20)
        Me.dtpEnd.TabIndex = 4
        '
        'dtpStart
        '
        Me.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpStart.Location = New System.Drawing.Point(67, 37)
        Me.dtpStart.Name = "dtpStart"
        Me.dtpStart.Size = New System.Drawing.Size(107, 20)
        Me.dtpStart.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AccessibleRole = System.Windows.Forms.AccessibleRole.RowHeader
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Start Date"
        '
        'btnCallProc
        '
        Me.btnCallProc.Location = New System.Drawing.Point(369, 37)
        Me.btnCallProc.Name = "btnCallProc"
        Me.btnCallProc.Size = New System.Drawing.Size(97, 23)
        Me.btnCallProc.TabIndex = 1
        Me.btnCallProc.Text = "Refresh Data"
        Me.btnCallProc.UseVisualStyleBackColor = True
        '
        'grdAnalysis
        '
        Me.grdAnalysis.AllowFilter = False
        Me.grdAnalysis.AllowUpdate = False
        Me.grdAnalysis.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdAnalysis.DataSource = Me.ListImageIOIndexedIntoDoclinkBindingSource
        Me.grdAnalysis.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.GroupBy
        Me.grdAnalysis.ExtendRightColumn = True
        Me.grdAnalysis.FilterBar = True
        Me.grdAnalysis.GroupByCaption = "Drag a column header here to group by that column"
        Me.grdAnalysis.Images.Add(CType(resources.GetObject("grdAnalysis.Images"), System.Drawing.Image))
        Me.grdAnalysis.LinesPerRow = 2
        Me.grdAnalysis.Location = New System.Drawing.Point(1, 65)
        Me.grdAnalysis.MaintainRowCurrency = True
        Me.grdAnalysis.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightCell
        Me.grdAnalysis.Name = "grdAnalysis"
        Me.grdAnalysis.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdAnalysis.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdAnalysis.PreviewInfo.ZoomFactor = 75.0R
        Me.grdAnalysis.PrintInfo.PageSettings = CType(resources.GetObject("grdAnalysis.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdAnalysis.Size = New System.Drawing.Size(772, 348)
        Me.grdAnalysis.TabIndex = 0
        Me.grdAnalysis.Text = "C1TrueDBGrid1"
        Me.grdAnalysis.VisualStyle = C1.Win.C1TrueDBGrid.VisualStyle.Office2007Blue
        Me.grdAnalysis.PropBag = resources.GetString("grdAnalysis.PropBag")
        '
        'menuMain
        '
        Me.menuMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FIleToolStripMenuItem, Me.GroupByToolStripMenuItem})
        Me.menuMain.Location = New System.Drawing.Point(0, 0)
        Me.menuMain.Name = "menuMain"
        Me.menuMain.Size = New System.Drawing.Size(775, 24)
        Me.menuMain.Stretch = False
        Me.menuMain.TabIndex = 7
        Me.menuMain.Text = "MenuStrip1"
        '
        'FIleToolStripMenuItem
        '
        Me.FIleToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem})
        Me.FIleToolStripMenuItem.Name = "FIleToolStripMenuItem"
        Me.FIleToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FIleToolStripMenuItem.Text = "FIle"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(92, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'GroupByToolStripMenuItem
        '
        Me.GroupByToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DefaultToolStripMenuItem, Me.IndexedByToolStripMenuItem})
        Me.GroupByToolStripMenuItem.Name = "GroupByToolStripMenuItem"
        Me.GroupByToolStripMenuItem.Size = New System.Drawing.Size(114, 20)
        Me.GroupByToolStripMenuItem.Text = "Grouping Options"
        '
        'DefaultToolStripMenuItem
        '
        Me.DefaultToolStripMenuItem.Name = "DefaultToolStripMenuItem"
        Me.DefaultToolStripMenuItem.Size = New System.Drawing.Size(202, 22)
        Me.DefaultToolStripMenuItem.Text = "Destination - Doc Type"
        '
        'IndexedByToolStripMenuItem
        '
        Me.IndexedByToolStripMenuItem.Name = "IndexedByToolStripMenuItem"
        Me.IndexedByToolStripMenuItem.Size = New System.Drawing.Size(202, 22)
        Me.IndexedByToolStripMenuItem.Text = "Indexed By - Destination"
        '
        'ListImageIOIndexedIntoDoclinkBindingSource
        '
        Me.ListImageIOIndexedIntoDoclinkBindingSource.DataMember = "ListImageIO_IndexedIntoDoclink"
        Me.ListImageIOIndexedIntoDoclinkBindingSource.DataSource = Me.CommonDataSet
        '
        'CommonDataSet
        '
        Me.CommonDataSet.DataSetName = "CommonDataSet"
        Me.CommonDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'dtp
        '
        Me.dtp.Location = New System.Drawing.Point(99, 0)
        Me.dtp.Name = "dtp"
        Me.dtp.Size = New System.Drawing.Size(200, 20)
        Me.dtp.TabIndex = 3
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Location = New System.Drawing.Point(99, 26)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(200, 20)
        Me.DateTimePicker2.TabIndex = 4
        '
        'C1TrueDBGrid1
        '
        Me.C1TrueDBGrid1.AllowUpdate = False
        Me.C1TrueDBGrid1.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.GroupBy
        Me.C1TrueDBGrid1.GroupByCaption = "Drag a column header here to group by that column"
        Me.C1TrueDBGrid1.Images.Add(CType(resources.GetObject("C1TrueDBGrid1.Images"), System.Drawing.Image))
        Me.C1TrueDBGrid1.LinesPerRow = 2
        Me.C1TrueDBGrid1.Location = New System.Drawing.Point(7, 85)
        Me.C1TrueDBGrid1.Name = "C1TrueDBGrid1"
        Me.C1TrueDBGrid1.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.C1TrueDBGrid1.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.C1TrueDBGrid1.PreviewInfo.ZoomFactor = 75.0R
        Me.C1TrueDBGrid1.PrintInfo.PageSettings = CType(resources.GetObject("C1TrueDBGrid1.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.C1TrueDBGrid1.Size = New System.Drawing.Size(1171, 284)
        Me.C1TrueDBGrid1.TabIndex = 0
        Me.C1TrueDBGrid1.Text = "C1TrueDBGrid1"
        Me.C1TrueDBGrid1.PropBag = resources.GetString("C1TrueDBGrid1.PropBag")
        '
        'ListImageIO_IndexedIntoDoclinkTableAdapter
        '
        Me.ListImageIO_IndexedIntoDoclinkTableAdapter.ClearBeforeFill = True
        '
        'frmProcessAnalysis
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 420)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.menuMain
        Me.Name = "frmProcessAnalysis"
        Me.Text = "Bird Eye View"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.grdAnalysis, System.ComponentModel.ISupportInitialize).EndInit()
        Me.menuMain.ResumeLayout(False)
        Me.menuMain.PerformLayout()
        CType(Me.ListImageIOIndexedIntoDoclinkBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CommonDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1TrueDBGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents grdAnalysis As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnCallProc As System.Windows.Forms.Button
    Friend WithEvents dtp As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents C1TrueDBGrid1 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents ListImageIO_IndexedIntoDoclinkTableAdapter As Maxum.CommonDataSetTableAdapters.ListImageIO_IndexedIntoDoclinkTableAdapter
    Friend WithEvents ListImageIOIndexedIntoDoclinkBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CommonDataSet As Maxum.CommonDataSet
    Friend WithEvents lblRefreshed As System.Windows.Forms.Label
    Friend WithEvents menuMain As System.Windows.Forms.MenuStrip
    Friend WithEvents FIleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupByToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DefaultToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IndexedByToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents chkViewImage As System.Windows.Forms.CheckBox
End Class

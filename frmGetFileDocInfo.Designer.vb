<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGetFileDocInfo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGetFileDocInfo))
        Me.ImageListBox = New System.Windows.Forms.ListBox()
        Me.cmsImageListBox = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CopySelectedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.txtFileName = New System.Windows.Forms.TextBox()
        Me.lblOrdNum = New System.Windows.Forms.Label()
        Me.btnGetInfo = New System.Windows.Forms.Button()
        Me.txtInfo = New System.Windows.Forms.TextBox()
        Me.btnCopyFileToCollator = New System.Windows.Forms.Button()
        Me.btnPrevious = New System.Windows.Forms.Button()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.txtContent = New System.Windows.Forms.TextBox()
        Me.GetDocumentInfoFromFileTableAdapter = New Maxum.CommonDataSetTableAdapters.GetDocumentInfoFromFileTableAdapter()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.tsmiRotate = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiAnalysis = New System.Windows.Forms.ToolStripMenuItem()
        Me.AdminToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ErrorReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.cmsImage = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tsmiCopyImage = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiCopyAllImages = New System.Windows.Forms.ToolStripMenuItem()
        Me.GetDocumentInfoFromFileBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.btnViewArchive = New System.Windows.Forms.Button()
        Me.lblGoToPage = New System.Windows.Forms.Label()
        Me.txtGoToPage = New System.Windows.Forms.TextBox()
        Me.btnReleaseImage = New System.Windows.Forms.Button()
        Me.cmsImageListBox.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsImage.SuspendLayout()
        CType(Me.GetDocumentInfoFromFileBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ImageListBox
        '
        Me.ImageListBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ImageListBox.ContextMenuStrip = Me.cmsImageListBox
        Me.ImageListBox.FormattingEnabled = True
        Me.ImageListBox.HorizontalScrollbar = True
        Me.ImageListBox.Location = New System.Drawing.Point(12, 184)
        Me.ImageListBox.Name = "ImageListBox"
        Me.ImageListBox.ScrollAlwaysVisible = True
        Me.ImageListBox.Size = New System.Drawing.Size(580, 277)
        Me.ImageListBox.TabIndex = 1
        '
        'cmsImageListBox
        '
        Me.cmsImageListBox.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopySelectedToolStripMenuItem, Me.ToolStripMenuItem2})
        Me.cmsImageListBox.Name = "ContextMenuStrip1"
        Me.cmsImageListBox.Size = New System.Drawing.Size(196, 48)
        '
        'CopySelectedToolStripMenuItem
        '
        Me.CopySelectedToolStripMenuItem.Image = Global.Maxum.My.Resources.Resources.CopyHS1
        Me.CopySelectedToolStripMenuItem.Name = "CopySelectedToolStripMenuItem"
        Me.CopySelectedToolStripMenuItem.Size = New System.Drawing.Size(195, 22)
        Me.CopySelectedToolStripMenuItem.Text = "Copy Selected List Text"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Image = Global.Maxum.My.Resources.Resources.CopyHS1
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(195, 22)
        Me.ToolStripMenuItem2.Text = "Copy All List Text"
        '
        'txtFileName
        '
        Me.txtFileName.Location = New System.Drawing.Point(142, 25)
        Me.txtFileName.Name = "txtFileName"
        Me.txtFileName.Size = New System.Drawing.Size(450, 20)
        Me.txtFileName.TabIndex = 20
        '
        'lblOrdNum
        '
        Me.lblOrdNum.AutoSize = True
        Me.lblOrdNum.Location = New System.Drawing.Point(9, 28)
        Me.lblOrdNum.Name = "lblOrdNum"
        Me.lblOrdNum.Size = New System.Drawing.Size(129, 13)
        Me.lblOrdNum.TabIndex = 21
        Me.lblOrdNum.Text = "File Name or DocumentID"
        '
        'btnGetInfo
        '
        Me.btnGetInfo.Location = New System.Drawing.Point(12, 51)
        Me.btnGetInfo.Name = "btnGetInfo"
        Me.btnGetInfo.Size = New System.Drawing.Size(75, 23)
        Me.btnGetInfo.TabIndex = 27
        Me.btnGetInfo.Text = "Get Info"
        Me.btnGetInfo.UseVisualStyleBackColor = True
        '
        'txtInfo
        '
        Me.txtInfo.Location = New System.Drawing.Point(12, 76)
        Me.txtInfo.Multiline = True
        Me.txtInfo.Name = "txtInfo"
        Me.txtInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtInfo.Size = New System.Drawing.Size(580, 75)
        Me.txtInfo.TabIndex = 28
        '
        'btnCopyFileToCollator
        '
        Me.btnCopyFileToCollator.Enabled = False
        Me.btnCopyFileToCollator.Location = New System.Drawing.Point(12, 155)
        Me.btnCopyFileToCollator.Name = "btnCopyFileToCollator"
        Me.btnCopyFileToCollator.Size = New System.Drawing.Size(40, 23)
        Me.btnCopyFileToCollator.TabIndex = 29
        Me.btnCopyFileToCollator.Text = "Copy File To Collator"
        Me.btnCopyFileToCollator.UseVisualStyleBackColor = True
        Me.btnCopyFileToCollator.Visible = False
        '
        'btnPrevious
        '
        Me.btnPrevious.Enabled = False
        Me.btnPrevious.Location = New System.Drawing.Point(611, 52)
        Me.btnPrevious.Name = "btnPrevious"
        Me.btnPrevious.Size = New System.Drawing.Size(59, 23)
        Me.btnPrevious.TabIndex = 30
        Me.btnPrevious.Text = "Previous"
        Me.btnPrevious.UseVisualStyleBackColor = True
        '
        'btnNext
        '
        Me.btnNext.Enabled = False
        Me.btnNext.Location = New System.Drawing.Point(770, 52)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(59, 23)
        Me.btnNext.TabIndex = 31
        Me.btnNext.Text = "Next"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'txtContent
        '
        Me.txtContent.Location = New System.Drawing.Point(670, 54)
        Me.txtContent.Name = "txtContent"
        Me.txtContent.ReadOnly = True
        Me.txtContent.Size = New System.Drawing.Size(100, 20)
        Me.txtContent.TabIndex = 32
        '
        'GetDocumentInfoFromFileTableAdapter
        '
        Me.GetDocumentInfoFromFileTableAdapter.ClearBeforeFill = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiRotate, Me.tsmiAnalysis, Me.AdminToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(933, 24)
        Me.MenuStrip1.TabIndex = 34
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'tsmiRotate
        '
        Me.tsmiRotate.Enabled = False
        Me.tsmiRotate.Image = Global.Maxum.My.Resources.Resources.FlipVerticalHS
        Me.tsmiRotate.Name = "tsmiRotate"
        Me.tsmiRotate.Size = New System.Drawing.Size(69, 20)
        Me.tsmiRotate.Text = "Rotate"
        '
        'tsmiAnalysis
        '
        Me.tsmiAnalysis.Name = "tsmiAnalysis"
        Me.tsmiAnalysis.Size = New System.Drawing.Size(94, 20)
        Me.tsmiAnalysis.Text = "Birds Eye View"
        '
        'AdminToolStripMenuItem
        '
        Me.AdminToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ErrorReportToolStripMenuItem})
        Me.AdminToolStripMenuItem.Name = "AdminToolStripMenuItem"
        Me.AdminToolStripMenuItem.Size = New System.Drawing.Size(55, 20)
        Me.AdminToolStripMenuItem.Text = "Admin"
        '
        'ErrorReportToolStripMenuItem
        '
        Me.ErrorReportToolStripMenuItem.Name = "ErrorReportToolStripMenuItem"
        Me.ErrorReportToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
        Me.ErrorReportToolStripMenuItem.Text = "Audit"
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.ContextMenuStrip = Me.cmsImage
        Me.PictureBox1.Location = New System.Drawing.Point(609, 80)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(308, 387)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 14
        Me.PictureBox1.TabStop = False
        '
        'cmsImage
        '
        Me.cmsImage.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiCopyImage, Me.tsmiCopyAllImages})
        Me.cmsImage.Name = "cmsImage"
        Me.cmsImage.Size = New System.Drawing.Size(161, 48)
        '
        'tsmiCopyImage
        '
        Me.tsmiCopyImage.Image = Global.Maxum.My.Resources.Resources.CopyHS1
        Me.tsmiCopyImage.Name = "tsmiCopyImage"
        Me.tsmiCopyImage.Size = New System.Drawing.Size(160, 22)
        Me.tsmiCopyImage.Text = "Copy Image"
        '
        'tsmiCopyAllImages
        '
        Me.tsmiCopyAllImages.Image = Global.Maxum.My.Resources.Resources.CopyHS1
        Me.tsmiCopyAllImages.Name = "tsmiCopyAllImages"
        Me.tsmiCopyAllImages.Size = New System.Drawing.Size(160, 22)
        Me.tsmiCopyAllImages.Text = "Copy All Images"
        '
        'GetDocumentInfoFromFileBindingSource
        '
        Me.GetDocumentInfoFromFileBindingSource.DataMember = "GetDocumentInfoFromFile"
        '
        'BackgroundWorker1
        '
        Me.BackgroundWorker1.WorkerReportsProgress = True
        Me.BackgroundWorker1.WorkerSupportsCancellation = True
        '
        'Timer1
        '
        Me.Timer1.Interval = 500
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(93, 57)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(499, 12)
        Me.ProgressBar1.TabIndex = 35
        Me.ProgressBar1.Visible = False
        '
        'btnViewArchive
        '
        Me.btnViewArchive.Enabled = False
        Me.btnViewArchive.Location = New System.Drawing.Point(171, 157)
        Me.btnViewArchive.Name = "btnViewArchive"
        Me.btnViewArchive.Size = New System.Drawing.Size(185, 21)
        Me.btnViewArchive.TabIndex = 36
        Me.btnViewArchive.Text = "View Original Archived File"
        Me.btnViewArchive.UseVisualStyleBackColor = True
        '
        'lblGoToPage
        '
        Me.lblGoToPage.AutoSize = True
        Me.lblGoToPage.Enabled = False
        Me.lblGoToPage.Location = New System.Drawing.Point(842, 39)
        Me.lblGoToPage.Name = "lblGoToPage"
        Me.lblGoToPage.Size = New System.Drawing.Size(65, 13)
        Me.lblGoToPage.TabIndex = 37
        Me.lblGoToPage.Text = "Go To Page"
        '
        'txtGoToPage
        '
        Me.txtGoToPage.Enabled = False
        Me.txtGoToPage.Location = New System.Drawing.Point(845, 55)
        Me.txtGoToPage.Name = "txtGoToPage"
        Me.txtGoToPage.Size = New System.Drawing.Size(53, 20)
        Me.txtGoToPage.TabIndex = 38
        '
        'btnReleaseImage
        '
        Me.btnReleaseImage.Enabled = False
        Me.btnReleaseImage.Location = New System.Drawing.Point(495, 157)
        Me.btnReleaseImage.Name = "btnReleaseImage"
        Me.btnReleaseImage.Size = New System.Drawing.Size(97, 23)
        Me.btnReleaseImage.TabIndex = 39
        Me.btnReleaseImage.Text = "Release Image"
        Me.btnReleaseImage.UseVisualStyleBackColor = True
        '
        'frmGetFileDocInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(933, 487)
        Me.Controls.Add(Me.btnReleaseImage)
        Me.Controls.Add(Me.txtGoToPage)
        Me.Controls.Add(Me.lblGoToPage)
        Me.Controls.Add(Me.btnViewArchive)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.txtContent)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.btnPrevious)
        Me.Controls.Add(Me.btnCopyFileToCollator)
        Me.Controls.Add(Me.txtInfo)
        Me.Controls.Add(Me.btnGetInfo)
        Me.Controls.Add(Me.lblOrdNum)
        Me.Controls.Add(Me.txtFileName)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.ImageListBox)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmGetFileDocInfo"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.Text = "AIRR Validator"
        Me.cmsImageListBox.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsImage.ResumeLayout(False)
        CType(Me.GetDocumentInfoFromFileBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ImageListBox As System.Windows.Forms.ListBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents txtFileName As System.Windows.Forms.TextBox
    Friend WithEvents lblOrdNum As System.Windows.Forms.Label
    'Friend WithEvents tsmiRotate As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnGetInfo As System.Windows.Forms.Button
    Friend WithEvents txtInfo As System.Windows.Forms.TextBox
    Friend WithEvents btnCopyFileToCollator As System.Windows.Forms.Button
    Friend WithEvents btnPrevious As System.Windows.Forms.Button
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents txtContent As System.Windows.Forms.TextBox
    Friend WithEvents GetDocumentInfoFromFileBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents GetDocumentInfoFromFileTableAdapter As Maxum.CommonDataSetTableAdapters.GetDocumentInfoFromFileTableAdapter
    Friend WithEvents CopyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopyAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsImageListBox As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents CopySelectedToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiRotate As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsImage As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents tsmiCopyImage As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiCopyAllImages As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents btnViewArchive As System.Windows.Forms.Button
    Friend WithEvents tsmiAnalysis As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblGoToPage As System.Windows.Forms.Label
    Friend WithEvents txtGoToPage As System.Windows.Forms.TextBox
    Friend WithEvents AdminToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ErrorReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnReleaseImage As System.Windows.Forms.Button
    'Friend WithEvents RotateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem


End Class

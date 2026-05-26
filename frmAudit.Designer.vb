<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAudit
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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAudit))
        Me.txtMessage = New System.Windows.Forms.TextBox()
        Me.btnResubmit = New C1.Win.C1Input.C1Button()
        Me.btnFindInArchive = New C1.Win.C1Input.C1Button()
        Me.ManualValidateButton = New C1.Win.C1Input.C1Button()
        Me.grdAudit = New System.Windows.Forms.DataGridView()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Filename = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GUID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReceivedFrom = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PageCount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReceivedDateTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Type = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Process = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FileProcessed = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ImagesProcessed = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.EdmVerified = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ID1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KeyValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DocType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GUID1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FrameCount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Process1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MessageDateTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EdmVerified1 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.CalculateImageIoMessagesDataTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.btnRefresh = New C1.Win.C1Input.C1Button()
        Me.chkShowImage = New System.Windows.Forms.CheckBox()
        Me.chkImageNotProcessed = New System.Windows.Forms.CheckBox()
        Me.chkFilterVerified = New System.Windows.Forms.CheckBox()
        Me.chkFileNotProcessed = New System.Windows.Forms.CheckBox()
        Me.chkOverdue = New System.Windows.Forms.CheckBox()
        CType(Me.grdAudit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CalculateImageIoMessagesDataTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtMessage
        '
        Me.txtMessage.Location = New System.Drawing.Point(6, 34)
        Me.txtMessage.Multiline = True
        Me.txtMessage.Name = "txtMessage"
        Me.txtMessage.Size = New System.Drawing.Size(344, 41)
        Me.txtMessage.TabIndex = 4
        '
        'btnResubmit
        '
        Me.btnResubmit.Location = New System.Drawing.Point(365, 6)
        Me.btnResubmit.Name = "btnResubmit"
        Me.btnResubmit.Size = New System.Drawing.Size(61, 22)
        Me.btnResubmit.TabIndex = 8
        Me.btnResubmit.Text = "Resubmit"
        Me.btnResubmit.UseVisualStyleBackColor = True
        Me.btnResubmit.VisualStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        Me.btnResubmit.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'btnFindInArchive
        '
        Me.btnFindInArchive.Location = New System.Drawing.Point(108, 6)
        Me.btnFindInArchive.Name = "btnFindInArchive"
        Me.btnFindInArchive.Size = New System.Drawing.Size(61, 22)
        Me.btnFindInArchive.TabIndex = 7
        Me.btnFindInArchive.Text = "Find"
        Me.btnFindInArchive.UseVisualStyleBackColor = True
        Me.btnFindInArchive.VisualStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        Me.btnFindInArchive.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'ManualValidateButton
        '
        Me.ManualValidateButton.Location = New System.Drawing.Point(210, 6)
        Me.ManualValidateButton.Name = "ManualValidateButton"
        Me.ManualValidateButton.Size = New System.Drawing.Size(114, 22)
        Me.ManualValidateButton.TabIndex = 6
        Me.ManualValidateButton.Text = "Manual Validate"
        Me.ManualValidateButton.UseVisualStyleBackColor = True
        Me.ManualValidateButton.VisualStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        Me.ManualValidateButton.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'grdAudit
        '
        Me.grdAudit.AllowUserToAddRows = False
        Me.grdAudit.AllowUserToDeleteRows = False
        Me.grdAudit.AllowUserToOrderColumns = True
        Me.grdAudit.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdAudit.AutoGenerateColumns = False
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdAudit.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.grdAudit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdAudit.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.Filename, Me.GUID, Me.ReceivedFrom, Me.PageCount, Me.ReceivedDateTime, Me.Type, Me.Process, Me.FileProcessed, Me.ImagesProcessed, Me.EdmVerified, Me.ID1, Me.KeyValue, Me.DocType, Me.GUID1, Me.FrameCount, Me.Process1, Me.MessageDateTime, Me.EdmVerified1})
        Me.grdAudit.DataSource = Me.CalculateImageIoMessagesDataTableBindingSource
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdAudit.DefaultCellStyle = DataGridViewCellStyle8
        Me.grdAudit.Location = New System.Drawing.Point(6, 81)
        Me.grdAudit.Name = "grdAudit"
        Me.grdAudit.ReadOnly = True
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdAudit.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.grdAudit.Size = New System.Drawing.Size(827, 305)
        Me.grdAudit.TabIndex = 9
        '
        'ID
        '
        Me.ID.DataPropertyName = "ID"
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.ReadOnly = True
        Me.ID.Width = 50
        '
        'Filename
        '
        Me.Filename.DataPropertyName = "Filename"
        Me.Filename.HeaderText = "Filename"
        Me.Filename.Name = "Filename"
        Me.Filename.ReadOnly = True
        '
        'GUID
        '
        Me.GUID.DataPropertyName = "GUID"
        Me.GUID.HeaderText = "GUID"
        Me.GUID.Name = "GUID"
        Me.GUID.ReadOnly = True
        '
        'ReceivedFrom
        '
        Me.ReceivedFrom.DataPropertyName = "ReceivedFrom"
        Me.ReceivedFrom.HeaderText = "ReceivedFrom"
        Me.ReceivedFrom.Name = "ReceivedFrom"
        Me.ReceivedFrom.ReadOnly = True
        '
        'PageCount
        '
        Me.PageCount.DataPropertyName = "PageCount"
        Me.PageCount.HeaderText = "PageCount"
        Me.PageCount.Name = "PageCount"
        Me.PageCount.ReadOnly = True
        '
        'ReceivedDateTime
        '
        Me.ReceivedDateTime.DataPropertyName = "ReceivedDateTime"
        Me.ReceivedDateTime.HeaderText = "ReceivedDateTime"
        Me.ReceivedDateTime.Name = "ReceivedDateTime"
        Me.ReceivedDateTime.ReadOnly = True
        Me.ReceivedDateTime.Width = 120
        '
        'Type
        '
        Me.Type.DataPropertyName = "Type"
        Me.Type.HeaderText = "Type"
        Me.Type.Name = "Type"
        Me.Type.ReadOnly = True
        '
        'Process
        '
        Me.Process.DataPropertyName = "Process"
        Me.Process.HeaderText = "Process"
        Me.Process.Name = "Process"
        Me.Process.ReadOnly = True
        '
        'FileProcessed
        '
        Me.FileProcessed.DataPropertyName = "FileProcessed"
        Me.FileProcessed.HeaderText = "FileProcessed"
        Me.FileProcessed.Name = "FileProcessed"
        Me.FileProcessed.ReadOnly = True
        '
        'ImagesProcessed
        '
        Me.ImagesProcessed.DataPropertyName = "ImagesProcessed"
        Me.ImagesProcessed.HeaderText = "ImagesProcessed"
        Me.ImagesProcessed.Name = "ImagesProcessed"
        Me.ImagesProcessed.ReadOnly = True
        '
        'EdmVerified
        '
        Me.EdmVerified.DataPropertyName = "EdmVerified"
        Me.EdmVerified.HeaderText = "EdmVerified"
        Me.EdmVerified.Name = "EdmVerified"
        Me.EdmVerified.ReadOnly = True
        '
        'ID1
        '
        Me.ID1.DataPropertyName = "ID1"
        Me.ID1.HeaderText = "ID1"
        Me.ID1.Name = "ID1"
        Me.ID1.ReadOnly = True
        '
        'KeyValue
        '
        Me.KeyValue.DataPropertyName = "KeyValue"
        Me.KeyValue.HeaderText = "KeyValue"
        Me.KeyValue.Name = "KeyValue"
        Me.KeyValue.ReadOnly = True
        '
        'DocType
        '
        Me.DocType.DataPropertyName = "DocType"
        Me.DocType.HeaderText = "DocType"
        Me.DocType.Name = "DocType"
        Me.DocType.ReadOnly = True
        '
        'GUID1
        '
        Me.GUID1.DataPropertyName = "GUID1"
        Me.GUID1.HeaderText = "GUID1"
        Me.GUID1.Name = "GUID1"
        Me.GUID1.ReadOnly = True
        '
        'FrameCount
        '
        Me.FrameCount.DataPropertyName = "FrameCount"
        Me.FrameCount.HeaderText = "FrameCount"
        Me.FrameCount.Name = "FrameCount"
        Me.FrameCount.ReadOnly = True
        '
        'Process1
        '
        Me.Process1.DataPropertyName = "Process1"
        Me.Process1.HeaderText = "Process1"
        Me.Process1.Name = "Process1"
        Me.Process1.ReadOnly = True
        '
        'MessageDateTime
        '
        Me.MessageDateTime.DataPropertyName = "MessageDateTime"
        Me.MessageDateTime.HeaderText = "MessageDateTime"
        Me.MessageDateTime.Name = "MessageDateTime"
        Me.MessageDateTime.ReadOnly = True
        '
        'EdmVerified1
        '
        Me.EdmVerified1.DataPropertyName = "EdmVerified1"
        Me.EdmVerified1.HeaderText = "EdmVerified1"
        Me.EdmVerified1.Name = "EdmVerified1"
        Me.EdmVerified1.ReadOnly = True
        '
        'CalculateImageIoMessagesDataTableBindingSource
        '
        Me.CalculateImageIoMessagesDataTableBindingSource.DataSource = GetType(Maxum.EDM.Utilities.DoclinkMonitorService.AuditDataSet.CalculateImageIoMessagesDataTable)
        '
        'btnRefresh
        '
        Me.btnRefresh.Location = New System.Drawing.Point(6, 6)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(61, 22)
        Me.btnRefresh.TabIndex = 10
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = True
        Me.btnRefresh.VisualStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        Me.btnRefresh.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'chkShowImage
        '
        Me.chkShowImage.AutoSize = True
        Me.chkShowImage.Location = New System.Drawing.Point(476, 10)
        Me.chkShowImage.Name = "chkShowImage"
        Me.chkShowImage.Size = New System.Drawing.Size(85, 17)
        Me.chkShowImage.TabIndex = 11
        Me.chkShowImage.Text = "Show Image"
        Me.chkShowImage.UseVisualStyleBackColor = True
        '
        'chkImageNotProcessed
        '
        Me.chkImageNotProcessed.AutoSize = True
        Me.chkImageNotProcessed.Location = New System.Drawing.Point(491, 47)
        Me.chkImageNotProcessed.Name = "chkImageNotProcessed"
        Me.chkImageNotProcessed.Size = New System.Drawing.Size(134, 17)
        Me.chkImageNotProcessed.TabIndex = 12
        Me.chkImageNotProcessed.Text = "Image NOT Processed"
        Me.chkImageNotProcessed.UseVisualStyleBackColor = True
        '
        'chkFilterVerified
        '
        Me.chkFilterVerified.AutoSize = True
        Me.chkFilterVerified.Location = New System.Drawing.Point(365, 47)
        Me.chkFilterVerified.Name = "chkFilterVerified"
        Me.chkFilterVerified.Size = New System.Drawing.Size(114, 17)
        Me.chkFilterVerified.TabIndex = 13
        Me.chkFilterVerified.Text = "EDM NOT Verified"
        Me.chkFilterVerified.UseVisualStyleBackColor = True
        '
        'chkFileNotProcessed
        '
        Me.chkFileNotProcessed.AutoSize = True
        Me.chkFileNotProcessed.Location = New System.Drawing.Point(635, 47)
        Me.chkFileNotProcessed.Name = "chkFileNotProcessed"
        Me.chkFileNotProcessed.Size = New System.Drawing.Size(121, 17)
        Me.chkFileNotProcessed.TabIndex = 14
        Me.chkFileNotProcessed.Text = "File NOT Processed"
        Me.chkFileNotProcessed.UseVisualStyleBackColor = True
        '
        'chkOverdue
        '
        Me.chkOverdue.AutoSize = True
        Me.chkOverdue.Location = New System.Drawing.Point(635, 10)
        Me.chkOverdue.Name = "chkOverdue"
        Me.chkOverdue.Size = New System.Drawing.Size(67, 17)
        Me.chkOverdue.TabIndex = 15
        Me.chkOverdue.Text = "Overdue"
        Me.chkOverdue.UseVisualStyleBackColor = True
        '
        'frmAudit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(839, 398)
        Me.Controls.Add(Me.chkOverdue)
        Me.Controls.Add(Me.chkFileNotProcessed)
        Me.Controls.Add(Me.chkFilterVerified)
        Me.Controls.Add(Me.chkImageNotProcessed)
        Me.Controls.Add(Me.chkShowImage)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.grdAudit)
        Me.Controls.Add(Me.btnResubmit)
        Me.Controls.Add(Me.btnFindInArchive)
        Me.Controls.Add(Me.ManualValidateButton)
        Me.Controls.Add(Me.txtMessage)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmAudit"
        Me.Text = "Pending Validations"
        CType(Me.grdAudit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CalculateImageIoMessagesDataTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents txtMessage As System.Windows.Forms.TextBox
    Private WithEvents btnResubmit As C1.Win.C1Input.C1Button
    Private WithEvents btnFindInArchive As C1.Win.C1Input.C1Button
    Private WithEvents ManualValidateButton As C1.Win.C1Input.C1Button
    Friend WithEvents CalculateImageIoMessagesDataTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents grdAudit As System.Windows.Forms.DataGridView
    Private WithEvents btnRefresh As C1.Win.C1Input.C1Button
    Friend WithEvents chkShowImage As System.Windows.Forms.CheckBox
    Friend WithEvents ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Filename As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GUID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReceivedFrom As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PageCount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReceivedDateTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Type As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Process As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FileProcessed As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ImagesProcessed As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents EdmVerified As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ID1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KeyValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DocType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GUID1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FrameCount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Process1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MessageDateTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EdmVerified1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents chkImageNotProcessed As System.Windows.Forms.CheckBox
    Friend WithEvents chkFilterVerified As System.Windows.Forms.CheckBox
    Friend WithEvents chkFileNotProcessed As System.Windows.Forms.CheckBox
    Friend WithEvents chkOverdue As System.Windows.Forms.CheckBox
    'Friend WithEvents CalculateImageIoMessagesDataTableBindingSource As System.Windows.Forms.BindingSource
End Class

Imports System.Drawing.Color

Public Class FrmMain
	Inherits Windows.Forms.Form

#Region " Windows Form Designer generated code "

	Public Sub New()
		MyBase.New()

		'This call is required by the Windows Form Designer.
		InitializeComponent()

		'Add any initialization after the InitializeComponent() call

	End Sub

	'Form overrides dispose to clean up the component list.
	Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
		If disposing Then
			If Not (components Is Nothing) Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(disposing)
	End Sub

	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer

	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.  
	'Do not modify it using the code editor.
	Friend WithEvents btnID As System.Windows.Forms.Button
	Friend WithEvents lblTimeToID As System.Windows.Forms.Label
	Friend WithEvents btnStop As System.Windows.Forms.Button
	Friend WithEvents tmrID As System.Windows.Forms.Timer
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Me.components = New System.ComponentModel.Container()
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMain))
		Me.btnID = New System.Windows.Forms.Button()
		Me.lblTimeToID = New System.Windows.Forms.Label()
		Me.btnStop = New System.Windows.Forms.Button()
		Me.tmrID = New System.Windows.Forms.Timer(Me.components)
		Me.SuspendLayout()
		'
		'btnID
		'
		Me.btnID.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.btnID.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.btnID.Location = New System.Drawing.Point(7, 78)
		Me.btnID.Name = "btnID"
		Me.btnID.Size = New System.Drawing.Size(91, 23)
		Me.btnID.TabIndex = 0
		Me.btnID.Text = "Identify"
		'
		'lblTimeToID
		'
		Me.lblTimeToID.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.lblTimeToID.BackColor = System.Drawing.Color.Lime
		Me.lblTimeToID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblTimeToID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.lblTimeToID.Location = New System.Drawing.Point(7, 9)
		Me.lblTimeToID.Name = "lblTimeToID"
		Me.lblTimeToID.Size = New System.Drawing.Size(194, 67)
		Me.lblTimeToID.TabIndex = 1
		Me.lblTimeToID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'btnStop
		'
		Me.btnStop.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btnStop.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.btnStop.Location = New System.Drawing.Point(104, 78)
		Me.btnStop.Name = "btnStop"
		Me.btnStop.Size = New System.Drawing.Size(97, 23)
		Me.btnStop.TabIndex = 2
		Me.btnStop.Text = "&Stop"
		'
		'tmrID
		'
		Me.tmrID.Interval = 1000
		'
		'FrmMain
		'
		Me.AcceptButton = Me.btnID
		Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
		Me.AutoSize = True
		Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.AutoValidate = System.Windows.Forms.AutoValidate.Disable
		Me.CausesValidation = False
		Me.ClientSize = New System.Drawing.Size(210, 113)
		Me.Controls.Add(Me.btnStop)
		Me.Controls.Add(Me.lblTimeToID)
		Me.Controls.Add(Me.btnID)
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.MaximizeBox = False
		Me.MaximumSize = New System.Drawing.Size(500, 450)
		Me.MinimizeBox = False
		Me.MinimumSize = New System.Drawing.Size(226, 153)
		Me.Name = "FrmMain"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "K4GDW ID Timer"
		Me.ResumeLayout(False)

	End Sub

#End Region

	Private _intSeconds As Integer
	Private _intMinutes As Integer

	Private Sub BtnIdClick(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnID.Click
		ResetTimer()
		DisplayTime()
		tmrID.Start()
	End Sub

	Private Sub TmrIdTick(ByVal sender As System.Object, ByVal e As EventArgs) Handles tmrID.Tick
		_intSeconds += 1
		If _intSeconds = 60 Then
			_intSeconds = 0
			_intMinutes += 1
		End If
		DisplayTime()
	End Sub

	Private Sub FrmMainLoad(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
		ResetTimer()
		DisplayTime()
	End Sub

	Private Sub ResetTimer()
		_intSeconds = 0
		_intMinutes = 0
		tmrID.Stop()
	End Sub

	Private Sub DisplayTime()
		lblTimeToID.Text = _intMinutes.ToString & "m " & _intSeconds.ToString & "s"
		If _intMinutes < 8 Then
			lblTimeToID.BackColor = Lime
		ElseIf _intMinutes >= 9 And _intMinutes < 10 Then
			lblTimeToID.BackColor = Yellow
		ElseIf _intMinutes >= 10 Then
			lblTimeToID.BackColor = Red
		End If
	End Sub

	Private Sub BtnStopClick(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnStop.Click
		ResetTimer()
		DisplayTime()
	End Sub
End Class
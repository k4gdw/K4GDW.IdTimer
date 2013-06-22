Imports System.Threading
Imports System.Drawing.Color

Public Class frmMain
	Inherits System.Windows.Forms.Form

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
		Me.components = New System.ComponentModel.Container
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
		Me.btnID = New System.Windows.Forms.Button
		Me.lblTimeToID = New System.Windows.Forms.Label
		Me.btnStop = New System.Windows.Forms.Button
		Me.tmrID = New System.Windows.Forms.Timer(Me.components)
		Me.SuspendLayout()
		'
		'btnID
		'
		Me.btnID.Location = New System.Drawing.Point(4, 80)
		Me.btnID.Name = "btnID"
		Me.btnID.Size = New System.Drawing.Size(184, 40)
		Me.btnID.TabIndex = 0
		Me.btnID.Text = "Click Here Or Hit Enter When You ID"
		'
		'lblTimeToID
		'
		Me.lblTimeToID.BackColor = System.Drawing.Color.Lime
		Me.lblTimeToID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.lblTimeToID.Location = New System.Drawing.Point(4, 4)
		Me.lblTimeToID.Name = "lblTimeToID"
		Me.lblTimeToID.Size = New System.Drawing.Size(184, 72)
		Me.lblTimeToID.TabIndex = 1
		Me.lblTimeToID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'btnStop
		'
		Me.btnStop.Location = New System.Drawing.Point(4, 128)
		Me.btnStop.Name = "btnStop"
		Me.btnStop.Size = New System.Drawing.Size(184, 40)
		Me.btnStop.TabIndex = 2
		Me.btnStop.Text = "&Stop"
		'
		'tmrID
		'
		Me.tmrID.Interval = 1000
		'
		'frmMain
		'
		Me.AcceptButton = Me.btnID
		Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
		Me.ClientSize = New System.Drawing.Size(192, 169)
		Me.Controls.Add(Me.btnStop)
		Me.Controls.Add(Me.lblTimeToID)
		Me.Controls.Add(Me.btnID)
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.MaximizeBox = False
		Me.MaximumSize = New System.Drawing.Size(200, 196)
		Me.MinimizeBox = False
		Me.MinimumSize = New System.Drawing.Size(200, 196)
		Me.Name = "frmMain"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "K4GDW ID Timer"
		Me.ResumeLayout(False)

	End Sub

#End Region

	Private intSeconds As Integer
	Private intMinutes As Integer

	Private Sub btnID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnID.Click
        ResetTimer()
        DisplayTime()
        tmrID.Start()
	End Sub

	Private Sub tmrID_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrID.Tick
		intSeconds += 1
		If intSeconds = 60 Then
			intSeconds = 0
			intMinutes += 1
		End If
		DisplayTime()
	End Sub

	Private Sub frmMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
		ResetTimer()
		DisplayTime()
	End Sub

	Private Sub ResetTimer()
		intSeconds = 0
		intMinutes = 0
		tmrID.Stop()
	End Sub

	Private Sub DisplayTime()
		lblTimeToID.Text = intMinutes.ToString & "m " & intSeconds.ToString & "s"
		If intMinutes < 8 Then
			lblTimeToID.BackColor = Lime
		ElseIf intMinutes >= 9 And intMinutes < 10 Then
			lblTimeToID.BackColor = Yellow
		ElseIf intMinutes >= 10 Then
			lblTimeToID.BackColor = Red
		End If
	End Sub

	Private Sub btnStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStop.Click
		ResetTimer()
		DisplayTime()
	End Sub
End Class
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms

Public Class Form1
    ' Declare Variables
    Dim currentDayOfWeek As DayOfWeek = DateTime.Now.DayOfWeek
    Dim gloriousMysteriesLink As String = "https://www.youtube.com/watch?v=gmzvvtuajIk"
    Dim joyfulMysteriesLink As String = "https://www.youtube.com/watch?v=sSy77qPkgRE"
    Dim sorrowfulMysteriesLink As String = "https://www.youtube.com/watch?v=Siu8clv8ds4"
    Dim luminousMysteriesLink As String = "https://www.youtube.com/watch?v=yQgbJ_UVRDg"

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' If application is loaded, hide the form
        Me.Visible = False
        Dim myster As String = ""

        ' Check for command line arguments
        Dim args As String() = Environment.GetCommandLineArgs()
        If args.Length > 1 Then
            Dim command As String = args(1)
            Select Case command

                Case "--sc"
                    Process.Start("https://github.com/jeonnotcool/RosaryDetector")
                    Me.Visible = False
                    Dim notificationn As New NotifyIcon()
                    notificationn.Icon = SystemIcons.Information
                    notificationn.Visible = True
                    notificationn.BalloonTipTitle = "Rosary Detector GitHub Repo"
                    notificationn.BalloonTipText = "has been launched on your browser."
                    notificationn.ShowBalloonTip(3000)
                    Application.Exit()
                    Return
                Case "--about"
                    ' Send notification to Windows Notification Center
                    Dim notificationn As New NotifyIcon()
                    notificationn.Icon = SystemIcons.Information
                    notificationn.Visible = True
                    notificationn.BalloonTipTitle = "About"
                    notificationn.BalloonTipText = "RosaryDetector v1"
                    notificationn.ShowBalloonTip(3000)
                    Application.Exit()
                    Return
                Case "--help", "--?"
                    ' Display help message
                    Dim helpMessage As String = "RosaryDetector Help" & vbCrLf &
                                    "Available command line arguments:" & vbCrLf &
                                    "--sc: Open the GitHub repository for RosaryDetector" & vbCrLf &
                                    "--about: Display information about RosaryDetector" & vbCrLf &
                                    "--help or -h: Display this help message"
                    MessageBox.Show(helpMessage, "Help", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Application.Exit()
                    Return
                Case ""
                    ' Display help message
                    Dim helpMessage As String = "RosaryDetector should be launched directly instead of command line. " & vbCrLf &
                        "Please type 'RosaryDetector --help' for more information."
                    MessageBox.Show(helpMessage, "Help", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Application.Exit()
                    Return
            End Select

        End If

        Select Case currentDayOfWeek
            Case DayOfWeek.Sunday
                myster = "Glorious Mysteries"
            Case DayOfWeek.Monday
                myster = "Joyful Mysteries"
            Case DayOfWeek.Tuesday
                myster = "Sorrowful Mysteries"
            Case DayOfWeek.Wednesday
                myster = "Glorious Mysteries"
            Case DayOfWeek.Thursday
                myster = "Luminous Mysteries"
            Case DayOfWeek.Friday
                myster = "Sorrowful Mysteries"
            Case DayOfWeek.Saturday
                myster = "Joyful Mysteries"
        End Select

        ' Open the link based on the selected mystery
        Select Case myster
            Case "Glorious Mysteries"
                Process.Start(gloriousMysteriesLink)
            Case "Joyful Mysteries"
                Process.Start(joyfulMysteriesLink)
            Case "Sorrowful Mysteries"
                Process.Start(sorrowfulMysteriesLink)
            Case "Luminous Mysteries"
                Process.Start(luminousMysteriesLink)
        End Select

        ' Send notification to Windows Notification Center
        Dim notification As New NotifyIcon()
        notification.Icon = SystemIcons.WinLogo
        notification.Visible = True
        notification.BalloonTipTitle = "The " & myster & " " & currentDayOfWeek.ToString()
        notification.BalloonTipText = "has been launched on your default browser."
        notification.ShowBalloonTip(3000)
        Application.Exit()
    End Sub
End Class

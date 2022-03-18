Imports System.IO
Imports System.Diagnostics.Process
Imports SharpCompress.Archive
Imports SharpCompress.Common
Imports System.Net.WebClient
Imports System.Net
Imports System.ComponentModel
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Threading

Public Class Launcher

    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer
    Dim fileName1 As String = "Client.exe"
    Dim fileName2 As String = "Full.rar"
    Dim fileName3 As String = "Update.rar"
    Dim fileName4 As String = "Files.rar"
    Dim fileName5 As String = "Update.exe"
    Dim fileName6 As String = "windowed"
    Dim fileName7 As String = "\Client.exe"
    Dim ProcessName As String = "Client"
    Dim ProcessName2 As String = "Update"
    Dim EspFile As String = "Esp"
    Dim LangFile As String = "Idioma"
    Dim Text1 As String = "You can start the game now."
    Dim Text1Esp As String = "Ya puede iniciar el juego."
    Dim Text2 As String = " - Helbreath Launcher v3.0 coded by prlucas -"
    Dim TitleMsgError As String = "Launcher Error"
    Dim TitleMsgStartup As String = "Warning"
    Dim TitleMsgStartupEsp As String = "Advertencia"
    Dim MsgError As String = "Reboot Launcher and dont close Update Console."
    Dim MsgErrorEsp As String = "Por favor no cierre la consola de actualizacion. Una vez que termine inicie el juego"
    Dim MsgStartup As String = "Please don't close the console update. Once complete start the game"
    Dim MsgStartupEsp As String = "Por favor no cierre la consola de actualizacion hasta que termine. Luego inicie el juego."
    Dim ForumAddress As String = "http://helbreathss.net/forum.php"
    Dim WebAddress As String = "http://helbreathss.net/web/index.php"
    Dim p() As Process
    Dim Tasks As New ProgramTasks
    Dim versionfile As String = "version.txt"
    Dim versionurl As String = "http://helbreathss.net/web/download/version.txt"


    Private Sub Launcher_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load

        Tasks.StartupCheckAndDeleteFiles()

        p = Process.GetProcessesByName(ProcessName)

        If p.Count > 0 Then
            showinfo.Clear()
            showinfo.AppendText("      - Ready to start -")
            progress.Value = 100

        Else
            Dim fileReader As String = My.Computer.FileSystem.ReadAllText(versionfile)
            Dim request As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create(versionurl)
            Dim response As System.Net.HttpWebResponse = request.GetResponse()
            Dim sr As System.IO.StreamReader = New System.IO.StreamReader(response.GetResponseStream())
            Dim newestversion As String = sr.ReadToEnd()
            Dim currentversion As String = fileReader

            If newestversion.Contains(currentversion) Then

                showinfo.Clear()
                showinfo.AppendText("      - Ready to start -")
                progress.Value = 100

                If File.Exists(EspFile) = False Then

                Else

                End If

            Else
                If File.Exists(EspFile) = False Then

                    Else

                    End If

                backgroundWorker1.RunWorkerAsync()

                End If



                End If


    End Sub



    Public Class ProgramTasks

        Dim fileName1 As String = "Client.exe"
        Dim fileName2 As String = "Full.rar"
        Dim fileName3 As String = "Update.rar"
        Dim fileName4 As String = "Files.rar"
        Dim FileName5 As String = "Update.exe"
        Dim fileName6 As String = "windowed"
        Dim fileName7 As String = "\Client.exe"
        Dim fileName8 As String = "LauncherUpdate.rar"
        Dim ProcessName As String = "Client"
        Dim WebAddress As String = "http://23489sdasd.com/"
        Dim p() As Process


        Public Sub CheckAndDeleteFiles()

        
            If File.Exists(fileName2) Then
                File.Delete(fileName2)
            End If

            If File.Exists(fileName4) Then
                File.Delete(fileName4)
            End If


        End Sub

        Public Sub StartupCheckAndDeleteFiles()
           

            If File.Exists(fileName6) Then
                File.Delete(fileName6)
            End If

            If File.Exists(fileName2) Then
                File.Delete(fileName2)
            End If

            If File.Exists(fileName4) Then
                File.Delete(fileName4)
            End If

            If File.Exists(FileName5) Then
                File.Delete(FileName5)
            End If

            If File.Exists(fileName8) Then
                File.Delete(fileName8)
            End If

        End Sub

        Public Sub AutoDownloadAndRunUpdate()

            If File.Exists(fileName8) = False Then
                Dim appPath As String = AppDomain.CurrentDomain.BaseDirectory()
                Dim fileName As String = fileName8
                Dim myStringWebResource As String = Nothing
                Dim myWebClient As New WebClient()
                myStringWebResource = WebAddress + fileName
                myWebClient.DownloadFile(myStringWebResource, fileName)
                Dim archive As IArchive = ArchiveFactory.Open(fileName)
                For Each entry In archive.Entries
                    If Not entry.IsDirectory Then
                        entry.WriteToDirectory(appPath, ExtractOptions.ExtractFullPath Or ExtractOptions.Overwrite)
                       
                    End If

                Next

            End If

            Process.Start(FileName5)

        End Sub

        Public Sub RegistryKeyFix()

            Dim osversion As Version = Environment.OSVersion.Version
            Dim filepath As String = fileName7
            Dim Filename
            Filename = fileName1
            Dim appPath As String = Application.StartupPath()
            If (osversion.Major = 6 And osversion.Minor >= 2) Or (osversion.Major = 10 And osversion.Minor >= 0) Then

                My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows NT\CurrentVersion\AppCompatFlags\Layers",
                appPath & filepath, "DWM8And16BitMitigation Layer_ForceDirectDrawEmulation")

            End If

        End Sub

    End Class


    Private Sub minimizeBtn_Click(sender As Object, e As EventArgs) Handles minimizeBtn.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub closeBtn_Click(sender As Object, e As EventArgs) Handles closeBtn.Click
        Me.Close()
    End Sub

    Private Sub strtBtn_Click(sender As Object, e As EventArgs) Handles strtBtn.Click
        Dim osversion As Version = Environment.OSVersion.Version
        Dim filepath As String = fileName7
        Dim Res
        Dim Filename
        Filename = fileName1
        Dim appPath As String = Application.StartupPath()

        Tasks.RegistryKeyFix()

        If File.Exists(Filename) = False Then
            If File.Exists(EspFile) = False Then
                MsgBox(MsgError, MsgBoxStyle.Critical, TitleMsgError)
            Else
                MsgBox(MsgErrorEsp, MsgBoxStyle.Critical, TitleMsgError)
                Process.Start("tasks.exe")
            End If
        Else
            Res = Shell(Filename, vbHide)
        End If

        Tasks.CheckAndDeleteFiles()
    End Sub

    Dim Fullrar As Boolean = True
    Dim Updaterar As Boolean = True
    Dim process1 As String = "Launcher"
    Dim Update1 As String = "Update.rar"
    Dim Full As String = "Full.rar"
    Dim RequiredFile As String = "search.dll"
    Dim LangFile2 As String = "Esp"
    Dim webAddress2 As String = "http://www.helbreathss.net/web/download.php"
    Dim FileDownload As String = "http://helbreathss.net/web/download/Update.rar"
    Dim FullDownload As String = "http://helbreathss.net/web/download/Full.rar"
    Dim NewLine1 As String = "(!) Update completed, now close this windows and Play Game in Launcher"
    Dim NewLine2 As String = "* Thanks for play Helbreath Server *"
    Dim NewLine3 As String = "(!) Operación terminada, ahora cierre esta ventana e inicie el juego desde el Launcher!"
    Dim NewLine4 As String = "* Gracias por jugar Helbreath Server *"
    Dim Requiredfullgame As String = "You need Full game for play Helbreath Server"

    Dim WithEvents WC As New WebClient

    Private Sub backgroundWorker1_DoWork(sender As Object, e As DoWorkEventArgs) Handles backgroundWorker1.DoWork

        Dim p() As Process
        p = Process.GetProcessesByName("Client")
        If p.Count > 0 Then

        Else
            If File.Exists("Client.exe") Then
                File.Delete("Client.exe")
            End If

        End If

        WC.DownloadFileAsync(New Uri(FileDownload), Update1)
        showinfo.Clear()
        showinfo.AppendText("Downloading Updates...")

        

    End Sub


    Private Sub WC_DownloadProgressChanged(ByVal sender As Object, ByVal e As DownloadProgressChangedEventArgs) Handles WC.DownloadProgressChanged

        progress.Value = e.ProgressPercentage



    End Sub



    Private Sub WC_DownloadFileCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs) Handles WC.DownloadFileCompleted

        showinfo.Clear()
        showinfo.AppendText("Installing Updates...")
        Dim appPath As String = AppDomain.CurrentDomain.BaseDirectory()

        
         Dim archive As IArchive = ArchiveFactory.Open(Update1)
        For Each entry In archive.Entries
            If Not entry.IsDirectory Then
                entry.WriteToDirectory(appPath, ExtractOptions.ExtractFullPath Or ExtractOptions.Overwrite)
            End If
        Next

        showinfo.Clear()
        showinfo.AppendText("      - Ready to start -")


    End Sub
    Private Sub BackgroundWorker1_ProgressChanged(ByVal sender As System.Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles backgroundWorker1.ProgressChanged

    End Sub
    Private Sub BackgroundWorker2_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker2.DoWork

      

    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs)
        BackgroundWorker2.RunWorkerAsync()

    End Sub


    Private Sub Launcher_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        drag = True
        mousex = Windows.Forms.Cursor.Position.X - Me.Left
        mousey = Windows.Forms.Cursor.Position.Y - Me.Top
    End Sub

    Private Sub Launcher_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        If drag Then
            Me.Top = Windows.Forms.Cursor.Position.Y - mousey
            Me.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub

    Private Sub Launcher_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp

        drag = False

    End Sub


End Class

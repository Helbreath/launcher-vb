Imports System.Threading

'Launcher/Updater coded by prlucas

Module RebootLauncher

    Dim Process1 As String = "Launcher"
    Dim Program1 As String = "Launcher.exe"

    Sub Main()

        Dim Launcher As Process
        Dim Launcher2 As Process() = Process.GetProcessesByName(Process1)

        For Each Launcher In Launcher2
            Launcher.Kill()
        Next

        System.Diagnostics.Process.Start(Program1)


    End Sub

End Module

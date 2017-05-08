Imports System.Globalization
Imports System.IO
Imports System.Security.Permissions
Imports System.Threading
Imports System.Net
Imports System.Runtime.InteropServices
Imports MetroFramework
Imports Newtonsoft.Json.Linq
Imports NHLGames.AdDetection
Imports NHLGames.Controls
Imports NHLGames.Objects
Imports NHLGames.Utilities.TextboxConsoleOutputRediect
Imports NHLGames.Utilities

Public Class NHLGamesMetro

    Private _serverIp As String
    Private Const DomainName As String = "mf.svc.nhl.com"
    Private Shared _settingsLoaded As Boolean = False
    Public Shared FormInstance As NHLGamesMetro = Nothing
    Private _adDetectorViewModel As AdDetectorViewModel = Nothing
    Private _loadingTimer As Timer
    Public Shared ProgressValue As Integer = 0
    Public Shared ProgressMaxValue As Integer = 1000
    Public Shared FlpCalendar As FlowLayoutPanel
    Public Shared StreamStarted As Boolean = False
    Public Shared ProgressVisible As Boolean = False
    Public Shared GamesDownloadedTime As Date
    Public Shared LabelDate As Label
    Public Shared DownloadLink As String = "https://www.reddit.com/r/nhl_games/"
    Public Shared GameDate As Date = DateHelper.GetPacificTime()
    Private _resizeDirection As Integer = -1
    Private Const ResizeBorderWidth As Integer = 3

    <DllImport("user32.dll")>
    Public Shared Function ReleaseCapture() As Boolean
    End Function

    <DllImport("user32.dll")>
    Public Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal Msg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
    End Function

    Private Const WM_NCLBUTTONDOWN As Integer = &HA1
    Private Const HTBOTTOM As Integer = 15
    Private Const HTBOTTOMLEFT As Integer = 16
    Private Const HTBOTTOMRIGHT As Integer = 17
    Private Const HTLEFT As Integer = 10
    Private Const HTRIGHT As Integer = 11
    Private Const HTTOP As Integer = 12
    Private Const HTTOPLEFT As Integer = 13
    Private Const HTTOPRIGHT As Integer = 14

    ' Starts the application. -- See: https://msdn.microsoft.com/en-us/library/system.windows.forms.application.threadexception(v=vs.110).aspx
    <SecurityPermission(SecurityAction.Demand, Flags:=SecurityPermissionFlag.ControlAppDomain)>
    Public Shared Sub Main()
        ' Add the event handler for handling UI thread exceptions to the event.
        AddHandler Application.ThreadException, AddressOf Form1_UIThreadException

        ' Set the unhandled exception mode to force all Windows Forms errors to go through our handler.
        Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException)

        ' Add the event handler for handling non-UI thread exceptions to the event. 
        AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf CurrentDomain_UnhandledException

        Dim form As New NHLGamesMetro()
        FormInstance = form

        'Setup redirecting console.out to 
        Dim writer = New TextBoxStreamWriter(form.RichTextBox)
        Console.SetOut(writer)

        '' Runs the application.
        Application.Run(form)
    End Sub

    Private Sub NHLGames_Load(sender As Object, e As EventArgs) Handles Me.Load

        AddHandler GameManager.NewGameFound, AddressOf NewGameFoundHandler
        FlpCalendar = flpCalender

        _adDetectorViewModel = New AdDetectorViewModel()
        AdDetectionSettingsElementHost.Child = _adDetectorViewModel.SettingsControl

        TabControl.SelectedIndex = 0
        flpCalender.Controls.Add(New CalenderControl())

        VersionCheck()
        IntitializeApplicationSettings()

    End Sub

    Private Sub IntitializeApplicationSettings()

        SettingsToolTip.SetToolTip(rbQual1, "300 MB/hr")
        SettingsToolTip.SetToolTip(rbQual2, "500 MB/hr")
        SettingsToolTip.SetToolTip(rbQual3, "700 MB/hr")
        SettingsToolTip.SetToolTip(rbQual4, "950 MB/hr")
        SettingsToolTip.SetToolTip(rbQual5, "1.3 GB/hr")
        SettingsToolTip.SetToolTip(rbQual6, "1.8 GB/hr")
        SettingsToolTip.SetToolTip(chk60, "+700 MB/hr (+40%)")

        Dim mpcPath As String = ApplicationSettings.Read(Of String)(ApplicationSettings.Settings.MpcPath, String.Empty)
        Dim mpcPathCurrent As String = PathFinder.GetPathOfMpc
        If mpcPath = String.Empty Then
            ApplicationSettings.SetValue(ApplicationSettings.Settings.MpcPath, mpcPathCurrent)
            mpcPath = mpcPathCurrent
        ElseIf mpcPath <> mpcPathCurrent And mpcPathCurrent <> String.Empty Then
            ApplicationSettings.SetValue(ApplicationSettings.Settings.MpcPath, mpcPathCurrent)
            mpcPath = mpcPathCurrent
        End If
        txtMPCPath.Text = mpcPath

        Dim vlcPath As String = ApplicationSettings.Read(Of String)(ApplicationSettings.Settings.VlcPath, String.Empty)
        Dim vlcPathCurrent As String = PathFinder.GetPathOfVlc
        If vlcPath = String.Empty Then
            ApplicationSettings.SetValue(ApplicationSettings.Settings.VlcPath, vlcPathCurrent)
            vlcPath = vlcPathCurrent
        ElseIf vlcPath <> vlcPathCurrent And vlcPathCurrent <> String.Empty Then
            ApplicationSettings.SetValue(ApplicationSettings.Settings.VlcPath, vlcPathCurrent)
            vlcPath = vlcPathCurrent
        End If
        txtVLCPath.Text = vlcPath

        Dim mpvPath As String = ApplicationSettings.Read(Of String)(ApplicationSettings.Settings.MpvPath, String.Empty)
        Dim mpvPathCurrent As String = Path.Combine(Application.StartupPath, "mpv\mpv.exe")
        If mpvPath = String.Empty Then
            If (Not File.Exists(mpvPathCurrent)) AndAlso vlcPath Is String.Empty AndAlso mpcPath Is String.Empty Then
                Console.WriteLine("Error: Can't find mpv.exe : mpv is a media player that we shipped with NHLGames. You probably moved it or deleted it." &
                                "Please set a player, NHLGames needs one.")
                mpvPathCurrent = String.Empty
            End If
            ApplicationSettings.SetValue(ApplicationSettings.Settings.MpvPath, mpvPathCurrent)
            mpvPath = mpvPathCurrent
        ElseIf mpvPath <> mpvPathCurrent Then
            If File.Exists(mpvPathCurrent) Then
                ApplicationSettings.SetValue(ApplicationSettings.Settings.MpvPath, mpvPathCurrent)
                mpvPath = mpvPathCurrent
            End If
        End If
        txtMpvPath.Text = mpvPath

        Dim streamlinkPath As String = ApplicationSettings.Read(Of String)(ApplicationSettings.Settings.StreamlinkPath, String.Empty)
        Dim streamlinkPathCurrent As String = Path.Combine(Application.StartupPath, "streamlink-0.5.0\streamlink.exe")
        If streamlinkPath = String.Empty Then
            If Not File.Exists(streamlinkPathCurrent) Then
                Console.WriteLine("Error:  Can't find streamlink.exe. Streamlink is a tool that NHLGames uses to send streams to your media player, " &
                                "we shipped it with NHLGames. You probably moved it or deleted it and " &
                                "if you don't set any custom path, you will have to put it back there, " &
                                "just drop the folder 'streamlink-0.5.0' next to NHLGames.exe.")
                streamlinkPathCurrent = String.Empty
            End If
            ApplicationSettings.SetValue(ApplicationSettings.Settings.StreamlinkPath, streamlinkPathCurrent)
            streamlinkPath = streamlinkPathCurrent
        ElseIf streamlinkPath <> streamlinkPathCurrent Then
            If File.Exists(streamlinkPathCurrent) Then
                ApplicationSettings.SetValue(ApplicationSettings.Settings.StreamlinkPath, streamlinkPathCurrent)
                streamlinkPath = streamlinkPathCurrent
            End If
        End If
        txtStreamlinkPath.Text = streamlinkPath

        chkShowFinalScores.Checked = ApplicationSettings.Read(Of Boolean)(ApplicationSettings.Settings.ShowScores, True)
        chkShowLiveScores.Checked = ApplicationSettings.Read(Of Boolean)(ApplicationSettings.Settings.ShowLiveScores, True)
        chkShowSeriesRecord.Checked = ApplicationSettings.Read(Of Boolean)(ApplicationSettings.Settings.ShowSeriesRecord, True)

        Dim watchArgs As Game.GameWatchArguments = ApplicationSettings.Read(Of Game.GameWatchArguments)(ApplicationSettings.Settings.DefaultWatchArgs)
        If watchArgs Is Nothing OrElse watchArgs.StreamlinkPath <> streamlinkPath Then
            SetEventArgsFromForm(True)
            watchArgs = ApplicationSettings.Read(Of Game.GameWatchArguments)(ApplicationSettings.Settings.DefaultWatchArgs)
        End If

        BindWatchArgsToForm(watchArgs)

        If (HostsFile.TestEntry(DomainName, _serverIp) = False) Then
            If MetroFramework.MetroMessageBox.Show(Me, "NHLGames can't work without having its hostname set in your Windows Hosts file. Do you want to let NHLGames adds an entry to your Hosts file, so Windows can resolve NHLGames hostname and connect to its server's IP address?", "Add Hosts Entry", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                HostsFile.AddEntry(_serverIp, DomainName, True)
            End If
        End If

        progress.Location = New Point((flpGames.Width - progress.Width) / 2, flpGames.Location.Y + 150)
        NoGames.Location = New Point((flpGames.Width - NoGames.Width) / 2, flpGames.Location.Y + 148)

        lblDate.Text = If(CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(GameDate.DayOfWeek).Length >= 3,
                            CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(GameDate.DayOfWeek).Substring(0, 3),
                            CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(GameDate.DayOfWeek).ToString()) & ", " &
                        If(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(GameDate.Month).Length >= 3,
                            CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(GameDate.Month).Substring(0, 3),
                            CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(GameDate.Month).ToString()) & " " &
                        Date.Today.Day.ToString & ", " & GameDate.Year.ToString

        LabelDate = lblDate
        GamesDownloadedTime = Now
        _settingsLoaded = True
    End Sub

    Private Sub SetEventArgsFromForm(Optional forceSet As Boolean = False)
        If _settingsLoaded OrElse forceSet Then

            Dim watchArgs As New Game.GameWatchArguments

            watchArgs.Is60Fps = chk60.Checked

            If rbQual6.Checked Then
                watchArgs.Quality = "720p"
            ElseIf rbQual5.Checked Then
                watchArgs.Quality = "540p"
                chk60.Checked = False
            ElseIf rbQual4.Checked Then
                watchArgs.Quality = "504p"
                chk60.Checked = False
            ElseIf rbQual3.Checked Then
                watchArgs.Quality = "360p"
                chk60.Checked = False
            ElseIf rbQual2.Checked Then
                watchArgs.Quality = "288p"
                chk60.Checked = False
            ElseIf rbQual1.Checked Then
                watchArgs.Quality = "224p"
                chk60.Checked = False
            End If

            If rbMPC.Checked Then
                watchArgs.PlayerType = Game.GameWatchArguments.PlayerTypeEnum.Mpc
                watchArgs.PlayerPath = txtMPCPath.Text
            ElseIf rbMpv.Checked Then
                watchArgs.PlayerType = Game.GameWatchArguments.PlayerTypeEnum.Mpv
                watchArgs.PlayerPath = txtMpvPath.Text
            Else
                watchArgs.PlayerType = Game.GameWatchArguments.PlayerTypeEnum.Vlc
                watchArgs.PlayerPath = txtVLCPath.Text
            End If

            watchArgs.StreamlinkPath = txtStreamlinkPath.Text

            If rbAkamai.Checked Then
                watchArgs.Cdn = "akc"
            ElseIf rbLevel3.Checked Then
                watchArgs.Cdn = "l3c"
            End If

            watchArgs.UsePlayerArgs = tgPlayer.Checked
            watchArgs.PlayerArgs = txtPlayerArgs.Text

            watchArgs.UsestreamlinkArgs = tgStreamer.Checked
            watchArgs.StreamlinkArgs = txtStreamerArgs.Text

            watchArgs.UseOutputArgs = tgOutput.Checked
            watchArgs.PlayerOutputPath = txtOutputPath.Text
            ApplicationSettings.SetValue(ApplicationSettings.Settings.DefaultWatchArgs, Serialization.SerializeObject(Of Game.GameWatchArguments)(watchArgs))
        End If
    End Sub

    Private Sub BindWatchArgsToForm(watchArgs As Game.GameWatchArguments)

        If watchArgs IsNot Nothing Then

            chk60.Checked = watchArgs.Is60Fps
            Select Case watchArgs.Quality
                Case "720p"
                    rbQual6.Checked = True
                Case "540p"
                    rbQual5.Checked = True
                Case "504p"
                    rbQual4.Checked = True
                Case "360p"
                    rbQual3.Checked = True
                Case "288p"
                    rbQual2.Checked = True
                Case "224p"
                    rbQual1.Checked = True
            End Select

            If watchArgs.Cdn = "akc" Then
                rbAkamai.Checked = True
            ElseIf watchArgs.Cdn = "l3c" Then
                rbLevel3.Checked = True
            End If

            Dim serverListFromConfig As String = ApplicationSettings.Read(Of String)(ApplicationSettings.Settings.ServerList, String.Empty)
            Dim serverList As String() = serverListFromConfig.Split(";")
            For Each server In serverList
                cbServers.Items.Add(server)
            Next

            cbServers.SelectedItem = ApplicationSettings.Read(Of String)(ApplicationSettings.Settings.SelectedServer, String.Empty)

            If cbServers.SelectedItem <> Nothing Then
                _serverIp = Dns.GetHostEntry(cbServers.SelectedItem.ToString()).AddressList.First.ToString()
            Else
                _serverIp = Dns.GetHostEntry(cbServers.Items(0).ToString()).AddressList.First.ToString()
            End If

            rbVLC.Checked = watchArgs.PlayerType = Game.GameWatchArguments.PlayerTypeEnum.Vlc
            rbMPC.Checked = watchArgs.PlayerType = Game.GameWatchArguments.PlayerTypeEnum.Mpc
            rbMpv.Checked = watchArgs.PlayerType = Game.GameWatchArguments.PlayerTypeEnum.Mpv

            If rbVLC.Checked AndAlso watchArgs.PlayerPath <> txtVLCPath.Text Then
                SetEventArgsFromForm()
            ElseIf rbMPC.Checked AndAlso watchArgs.PlayerPath <> txtMPCPath.Text Then
                SetEventArgsFromForm()
            ElseIf rbMpv.Checked AndAlso watchArgs.PlayerPath <> txtMpvPath.Text Then
                SetEventArgsFromForm()
            End If

            tgPlayer.Checked = watchArgs.UsePlayerArgs
            txtPlayerArgs.Enabled = watchArgs.UsePlayerArgs
            txtPlayerArgs.Text = watchArgs.PlayerArgs

            tgStreamer.Checked = watchArgs.UsestreamlinkArgs
            txtStreamerArgs.Enabled = watchArgs.UsestreamlinkArgs
            txtStreamerArgs.Text = watchArgs.StreamlinkArgs

            txtOutputPath.Text = watchArgs.PlayerOutputPath
            txtOutputPath.Enabled = watchArgs.UseOutputArgs
            tgOutput.Checked = watchArgs.UseOutputArgs

        End If
    End Sub

    ' Handle the UI exceptions by showing a dialog box, and asking the user whether
    ' or not they wish to abort execution.
    Private Shared Sub Form1_UIThreadException(ByVal sender As Object, ByVal t As ThreadExceptionEventArgs)
        Console.WriteLine("Error: {0}", t.Exception.ToString())
    End Sub

    Private Shared Sub CurrentDomain_UnhandledException(ByVal sender As Object, ByVal e As UnhandledExceptionEventArgs)
        Console.WriteLine(e.ExceptionObject.ToString())
    End Sub

    Public Sub HandleException(e As Exception)
        Console.WriteLine(e.ToString())
    End Sub
    Private Sub VersionCheck()
        Dim strLatest = Downloader.DownloadApplicationVersion()
        Console.WriteLine("Status: Current version is {0}", strLatest)
        Dim versionFromSettings = ApplicationSettings.Read(Of String)(ApplicationSettings.Settings.Version, "")

        If strLatest > versionFromSettings Then
            lnkDownload.Text = String.Format("A new version is available, download the latest version v{0} on /r/nhl_games", strLatest)
            DownloadLink &= "wiki/downloads"
            Dim strChangeLog = Downloader.DownloadChangelog()
            MetroMessageBox.Show(Me, String.Format("Version {0} is available! Changes: {1}{2}{3}", strLatest, vbCrLf, vbCrLf, strChangeLog), "New Version Available", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            lnkDownload.Text = "/r/nhl_games"
            lnkDownload.Width = 100
        End If
        lblVersion.Text = String.Format("v{0}", ApplicationSettings.Read(Of String)(ApplicationSettings.Settings.Version))

    End Sub

    Public Sub NewGameFoundHandler(gameObj As Game)

        If InvokeRequired Then
            BeginInvoke(New Action(Of Game)(AddressOf NewGameFoundHandler), gameObj)
        Else
            Dim gameControl As New GameControl(gameObj, ApplicationSettings.Read(Of Boolean)(ApplicationSettings.Settings.ShowScores),
                ApplicationSettings.Read(Of Boolean)(ApplicationSettings.Settings.ShowLiveScores),
                ApplicationSettings.Read(Of Boolean)(ApplicationSettings.Settings.ShowSeriesRecord))
            flpGames.Controls.Add(gameControl)
        End If

    End Sub


    ''' <summary>
    ''' Wrapper for LoadGames to stop UI locking and slow startup
    ''' </summary>
    ''' <param name="dateTime"></param>
    Private Sub LoadGamesAsync(dateTime As DateTime, Optional refreshing As Boolean = False)
        Dim loadGamesFunc As New Action(Of DateTime, Boolean)(Sub(dt As DateTime, rf As Boolean) LoadGames(dt, rf))
        loadGamesFunc.BeginInvoke(dateTime, refreshing, Nothing, Nothing)
    End Sub

    Private Sub ClearGamePanel()
        If InvokeRequired Then
            BeginInvoke(New Action(AddressOf ClearGamePanel))
        Else
            flpGames.Controls.Clear()
        End If
    End Sub

    Private Sub LoadGames(dateTime As DateTime, refreshing As Boolean)
        Dim availableGames As HashSet(Of String) = New HashSet(Of String)
        Try
            ProgressValue = 0
            SetLoading(True)
            SetFormStatusLabel("Loading Games")

            GameManager.ClearGames()
            ClearGamePanel()

            Dim jsonSchedule As JObject = Downloader.DownloadJsonSchedule(dateTime, refreshing)
            availableGames = Downloader.DownloadAvailableGames()
            GameManager.RefreshGames(dateTime, jsonSchedule, availableGames)

            SetFormStatusLabel("Games Found : " & GameManager.GamesList.Count.ToString())
            SetLoading(False)
        Catch ex As Exception
            Console.WriteLine(ex.ToString())
        End Try
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadGamesAsync(GameDate, True)
        flpGames.Focus()
    End Sub

    Private Sub RichTextBox_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox.TextChanged
        RichTextBox.SelectionStart = RichTextBox.Text.Length
        RichTextBox.ScrollToCaret()
    End Sub

    Private Sub btnOpenHostsFile_Click(sender As Object, e As EventArgs) Handles btnOpenHostsFile.Click
        Dim hostsFilePath As String = Environment.SystemDirectory & "\drivers\etc\hosts"
        Process.Start(hostsFilePath)
    End Sub

    Private Sub btnVLCPath_Click(sender As Object, e As EventArgs) Handles btnVLCPath.Click
        OpenFileDialog.Filter = "VLC|vlc.exe|All files (*.*)|*.*"
        OpenFileDialog.Multiselect = False

        If OpenFileDialog.ShowDialog() = DialogResult.OK Then

            If String.IsNullOrEmpty(OpenFileDialog.FileName) = False And txtVLCPath.Text <> OpenFileDialog.FileName Then
                ApplicationSettings.SetValue(ApplicationSettings.Settings.VlcPath, OpenFileDialog.FileName)
                txtVLCPath.Text = OpenFileDialog.FileName
            End If

        End If
    End Sub

    Private Sub btnMPCPath_Click(sender As Object, e As EventArgs) Handles btnMPCPath.Click
        OpenFileDialog.Filter = "MPC|mpc-hc64.exe;mpc-hc.exe|All files (*.*)|*.*"
        OpenFileDialog.Multiselect = False

        If OpenFileDialog.ShowDialog() = DialogResult.OK Then

            If String.IsNullOrEmpty(OpenFileDialog.FileName) = False And txtMPCPath.Text <> OpenFileDialog.FileName Then
                ApplicationSettings.SetValue(ApplicationSettings.Settings.MpcPath, OpenFileDialog.FileName)
                txtMPCPath.Text = OpenFileDialog.FileName
            End If

        End If
    End Sub

    Private Sub btnMpvPath_Click(sender As Object, e As EventArgs) Handles btnMpvPath.Click
        OpenFileDialog.Filter = "MPC|mpv.exe|All files (*.*)|*.*"
        OpenFileDialog.Multiselect = False

        If OpenFileDialog.ShowDialog() = DialogResult.OK Then

            If String.IsNullOrEmpty(OpenFileDialog.FileName) = False And txtMpvPath.Text <> OpenFileDialog.FileName Then
                ApplicationSettings.SetValue(ApplicationSettings.Settings.MpvPath, OpenFileDialog.FileName)
                txtMpvPath.Text = OpenFileDialog.FileName
            End If

        End If
    End Sub

    Private Sub btnstreamlinkPath_Click(sender As Object, e As EventArgs) Handles btnstreamlinkPath.Click
        OpenFileDialog.Filter = "streamlink|streamlink.exe|All files (*.*)|*.*"
        OpenFileDialog.Multiselect = False

        If OpenFileDialog.ShowDialog() = DialogResult.OK Then

            If String.IsNullOrEmpty(OpenFileDialog.FileName) = False And txtStreamlinkPath.Text <> OpenFileDialog.FileName Then
                ApplicationSettings.SetValue(ApplicationSettings.Settings.StreamlinkPath, OpenFileDialog.FileName)
                txtStreamlinkPath.Text = OpenFileDialog.FileName
            End If

        End If
    End Sub

    Private Sub chkShowFinalScores_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowFinalScores.CheckedChanged
        ApplicationSettings.SetValue(ApplicationSettings.Settings.ShowScores, chkShowFinalScores.Checked)
    End Sub

    Private Sub btnClearConsole_Click(sender As Object, e As EventArgs) Handles btnClearConsole.Click
        RichTextBox.Clear()
    End Sub

    Private Sub btnHosts_Click(sender As Object, e As EventArgs) Handles btnHosts.Click
        If HostsFile.TestEntry(DomainName, _serverIp) Then
            MetroMessageBox.Show(Me, "Hosts file looks good!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MetroMessageBox.Show(Me, "Hosts entry doesn't seem to be working :(", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

#Region "Settings Changed Update Settings"
    Private Sub chk60_CheckedChanged(sender As Object, e As EventArgs) Handles chk60.CheckedChanged
        If chk60.Checked Then
            rbQual6.Checked = True
            _writeToConsoleSettingsChanged("Quality", rbQual6.Text & " @ " & chk60.Text)
        ElseIf rbQual6.Checked Then
            _writeToConsoleSettingsChanged("Quality", rbQual6.Text)
        End If
        SetEventArgsFromForm()
    End Sub

    Private Sub _writeToConsoleSettingsChanged(key As String, value As String)
        Console.WriteLine("Status: Setting updated for '{0}' to '{1}'", key, value)
    End Sub

    Private Sub txtVLCPath_TextChanged(sender As Object, e As EventArgs) Handles txtVLCPath.TextChanged
        SetEventArgsFromForm()
    End Sub

    Private Sub txtMPCPath_TextChanged(sender As Object, e As EventArgs) Handles txtMPCPath.TextChanged
        SetEventArgsFromForm()
    End Sub

    Private Sub txtLiveStreamPath_TextChanged(sender As Object, e As EventArgs) Handles txtStreamlinkPath.TextChanged
        SetEventArgsFromForm()
    End Sub

    Private Sub SetFormStatusLabel(msg As String)
        If InvokeRequired Then
            BeginInvoke(New Action(Of String)(AddressOf SetFormStatusLabel), msg)
        Else
            Status.Text = msg
        End If
    End Sub

    Private Sub SetLoading(status As Boolean)
        If InvokeRequired Then
            BeginInvoke(New Action(Of Boolean)(AddressOf SetLoading), status)
        Else
            progress.Visible = status
            _loadingTimer = New Timer(New TimerCallback(Sub() If progress.Visible Then SetLoading(True)), Nothing, 1000, Timeout.Infinite)
        End If
    End Sub

    Private Sub quality_CheckedChanged(sender As Object, e As EventArgs) Handles rbQual6.CheckedChanged, rbQual5.CheckedChanged, rbQual4.CheckedChanged, rbQual3.CheckedChanged, rbQual2.CheckedChanged, rbQual1.CheckedChanged
        SetEventArgsFromForm()
        Dim rb As RadioButton = sender
        If (Not chk60.Checked And rb.Checked) Then _writeToConsoleSettingsChanged("Quality", rb.Text)
    End Sub

    Private Sub player_CheckedChanged(sender As Object, e As EventArgs) Handles rbVLC.CheckedChanged, rbMPC.CheckedChanged, rbMpv.CheckedChanged
        SetEventArgsFromForm()
        Dim rb As RadioButton = sender
        If (rb.Checked) Then _writeToConsoleSettingsChanged("Player", rb.Text)
    End Sub

    Private Sub rbCDN_CheckedChanged(sender As Object, e As EventArgs) Handles rbLevel3.CheckedChanged, rbAkamai.CheckedChanged
        SetEventArgsFromForm()
        Dim rb As RadioButton = sender
        If (rb.Checked) Then _writeToConsoleSettingsChanged("CDN", rb.Text)
    End Sub

    Private Sub txtOutputPath_TextChanged(sender As Object, e As EventArgs) Handles txtOutputPath.TextChanged
        SetEventArgsFromForm()
        _writeToConsoleSettingsChanged("Output", txtOutputPath.Text)
    End Sub

    Private Sub txtPlayerArgs_TextChanged(sender As Object, e As EventArgs) Handles txtPlayerArgs.TextChanged
        SetEventArgsFromForm()
        _writeToConsoleSettingsChanged("Player args", txtPlayerArgs.Text)
    End Sub

    Private Sub txtStreamerArgs_TextChanged(sender As Object, e As EventArgs) Handles txtStreamerArgs.TextChanged
        SetEventArgsFromForm()
        _writeToConsoleSettingsChanged("Streamer args", txtStreamerArgs.Text)
    End Sub

    Private Sub btnOuput_Click(sender As Object, e As EventArgs) Handles btnOuput.Click
        SaveFileDialog.CheckPathExists = True

        If txtOutputPath.Text.Count > 0 Then
            SaveFileDialog.InitialDirectory = Path.GetDirectoryName(txtOutputPath.Text)
            SaveFileDialog.FileName = Path.GetFileName(txtOutputPath.Text)
        Else
            SaveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos)
            SaveFileDialog.FileName = "(DATE)_(HOME)_vs_(AWAY)_(TYPE)_(QUAL)"
        End If

        SaveFileDialog.Filter = "MP4 Files (*.mp4)|*.MP4"
        SaveFileDialog.DefaultExt = "mp4"
        SaveFileDialog.AddExtension = True

        If SaveFileDialog.ShowDialog() = DialogResult.OK Then
            txtOutputPath.Text = SaveFileDialog.FileName
            SetEventArgsFromForm()
        End If
    End Sub

    Private Sub btnYesterday_Click(sender As Object, e As EventArgs) Handles btnYesterday.Click
        GameDate = GameDate.AddDays(-1)
        lblDate.Text = CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(GameDate.DayOfWeek).Substring(0, 3) & ", " &
            CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(GameDate.Month).Substring(0, 3) & " " &
            GameDate.Day.ToString & ", " & GameDate.Year.ToString
    End Sub

    Private Sub btnTomorrow_Click(sender As Object, e As EventArgs) Handles btnTomorrow.Click
        GameDate = GameDate.AddDays(1)
        lblDate.Text = CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(GameDate.DayOfWeek).Substring(0, 3) & ", " &
            CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(GameDate.Month).Substring(0, 3) & " " &
            GameDate.Day.ToString & ", " & GameDate.Year.ToString
    End Sub


    Private Sub btnClean_Click(sender As Object, e As EventArgs) Handles btnClean.Click
        HostsFile.CleanHosts(DomainName, True)
    End Sub

    Private Sub lnkVLCDownload_Click(sender As Object, e As EventArgs) Handles lnkVLCDownload.Click
        Dim sInfo As ProcessStartInfo = New ProcessStartInfo("http://www.videolan.org/vlc/download-windows.html")
        Process.Start(sInfo)
    End Sub

    Private Sub lnkMPCDownload_Click(sender As Object, e As EventArgs) Handles lnkMPCDownload.Click
        Dim sInfo As ProcessStartInfo = New ProcessStartInfo("https://mpc-hc.org/downloads/")
        Process.Start(sInfo)
    End Sub

    Private Sub btnAddHosts_Click(sender As Object, e As EventArgs) Handles btnAddHosts.Click
        HostsFile.AddEntry(_serverIp, DomainName, True)
    End Sub

    Private Sub btnDate_Click(sender As Object, e As EventArgs) Handles btnDate.Click
        Dim val = Not flpCalender.Visible
        flpCalender.Visible = val
    End Sub

    Private Sub lblDate_TextChanged(sender As Object, e As EventArgs) Handles lblDate.TextChanged
        LoadGamesAsync(GameDate)
        flpGames.Focus()
    End Sub

    Private Sub tmrAnimate_Tick(sender As Object, e As EventArgs) Handles tmrAnimate.Tick
        If StreamStarted Then
            progress.Visible = ProgressVisible
            flpGames.Enabled = False
            flpGames.Focus()
        Else
            flpGames.Enabled = True
        End If

        If ProgressValue < progress.Maximum Then
            progress.Value = ProgressValue
        ElseIf progress.Value < progress.Maximum And ProgressValue <= progress.Maximum Then
            progress.Value = progress.Maximum
        End If

        If progress.Visible Then
            btnDate.Enabled = False
            btnTomorrow.Enabled = False
            btnYesterday.Enabled = False
            NoGames.Visible = False
        Else
            btnDate.Enabled = True
            btnTomorrow.Enabled = True
            btnYesterday.Enabled = True
            If (flpGames.Controls.Count = 0) Then
                NoGames.Visible = True
            Else
                NoGames.Visible = False
            End If
        End If

        If flpGames.Controls.Count <> 0 And (progress.Visible Or NoGames.Visible) Then
            If Not StreamStarted Then progress.Visible = False
            NoGames.Visible = False
        End If

    End Sub

    Private Sub chkShowLiveScores_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowLiveScores.CheckedChanged
        ApplicationSettings.SetValue(ApplicationSettings.Settings.ShowLiveScores, chkShowLiveScores.Checked)
    End Sub

    Private Sub lnkDownload_Click(sender As Object, e As EventArgs) Handles lnkDownload.Click
        Dim sInfo As ProcessStartInfo = New ProcessStartInfo(DownloadLink)
        Process.Start(sInfo)
    End Sub

    Private Sub TabControl_MouseClick(sender As Object, e As MouseEventArgs) Handles TabControl.MouseClick
        ProgressVisible = False
        flpCalender.Visible = False
    End Sub

    Private Sub GamesTab_Click(sender As Object, e As EventArgs) Handles GamesTab.Click
        flpCalender.Visible = False
    End Sub

    Private Sub FlowLayoutPanel_Click(sender As Object, e As EventArgs) Handles flpGames.Click
        flpCalender.Visible = False
    End Sub

    Private Sub txtMpvPath_TextChanged(sender As Object, e As EventArgs) Handles txtMpvPath.TextChanged
        SetEventArgsFromForm()
    End Sub

    Private Sub tgStreamer_CheckedChanged(sender As Object, e As EventArgs) Handles tgStreamer.CheckedChanged
        txtStreamerArgs.Enabled = tgStreamer.Checked
        SetEventArgsFromForm()
        _writeToConsoleSettingsChanged("Streamer args Enable", tgStreamer.Checked)
    End Sub

    Private Sub tgPlayer_CheckedChanged(sender As Object, e As EventArgs) Handles tgPlayer.CheckedChanged
        txtPlayerArgs.Enabled = tgPlayer.Checked
        SetEventArgsFromForm()
        _writeToConsoleSettingsChanged("Player args Enable", tgPlayer.Checked)
    End Sub

    Private Sub tgOutput_CheckedChanged(sender As Object, e As EventArgs) Handles tgOutput.CheckedChanged
        txtOutputPath.Enabled = tgOutput.Checked
        SetEventArgsFromForm()
        _writeToConsoleSettingsChanged("Output Enable", tgOutput.Checked)
    End Sub

    Private Sub chkShowSeriesRecord_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowSeriesRecord.CheckedChanged
        ApplicationSettings.SetValue(ApplicationSettings.Settings.ShowSeriesRecord, chkShowSeriesRecord.Checked)
    End Sub

    Private Sub btnDisplayEntry_Click(sender As Object, e As EventArgs) Handles btnDisplayEntry.Click
        Dim result As DialogResult
        result = MetroMessageBox.Show(Me, String.Format("This line needs to be insert in your hosts file : {0}{1} {2}{0}" &
            "Copy and paste that entry line at the end of your Hosts file.{0}" &
            "You can use 'Open Hosts File' button with Notepad to open the Hosts file quickly.{0}" &
            "Do you want to copy that entry line to your clipboard ?",
            vbCrLf, _serverIp, DomainName), "Do It Yourself steps", MessageBoxButtons.YesNo)
        If result = System.Windows.Forms.DialogResult.Yes Then
            Clipboard.SetText(_serverIp & " " & DomainName)
        End If
    End Sub

    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        Dim sInfo As ProcessStartInfo = New ProcessStartInfo("https://github.com/NHLGames/NHLGames#nhlgames")
        Process.Start(sInfo)
    End Sub

    Private Sub btnMaximize_Click(sender As Object, e As EventArgs) Handles btnMaximize.Click
        Me.WindowState = FormWindowState.Maximized
        btnMaximize.Visible = False
        btnNormal.Visible = True
    End Sub

    Private Sub btnMinimize_Click(sender As Object, e As EventArgs) Handles btnMinimize.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnNormal_Click(sender As Object, e As EventArgs) Handles btnNormal.Click
        Me.WindowState = FormWindowState.Normal
        btnMaximize.Visible = True
        btnNormal.Visible = False
    End Sub

    Private Sub TabControl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl.SelectedIndexChanged
        Dim tc As TabControl = sender
        If tc.SelectedIndex = 0 Then
            'Games tab selected
            flpGames.Focus()
        ElseIf tc.SelectedIndex = 1 Then
            'Settings tab selected
            flpSettings.Focus()
        ElseIf tc.SelectedIndex = 2 Then
            'Console tab selected
            RichTextBox.Focus()
        Else
            'Ad detector tab selected
            flpAdDetector.Focus()
        End If
    End Sub

    Private Sub NHLGamesMetro_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        Me.Refresh()
        flpGames.Focus()
    End Sub

    Private Sub NHLGamesMetro_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove
        'Calculate which direction to resize based on mouse position
        _resizeDirection = -1
        If e.Location.X < ResizeBorderWidth And e.Location.Y < ResizeBorderWidth Then
            Me.Cursor = Cursors.SizeNWSE
            _resizeDirection = HTTOPLEFT
        ElseIf e.Location.X < ResizeBorderWidth And e.Location.Y > MyBase.Height - ResizeBorderWidth Then
            Me.Cursor = Cursors.SizeNESW
            _resizeDirection = HTBOTTOMLEFT
        ElseIf e.Location.X > MyBase.Width - ResizeBorderWidth And e.Location.Y > MyBase.Height - ResizeBorderWidth Then
            Me.Cursor = Cursors.SizeNWSE
            _resizeDirection = HTBOTTOMRIGHT
        ElseIf e.Location.X > MyBase.Width - ResizeBorderWidth And e.Location.Y < ResizeBorderWidth Then
            Me.Cursor = Cursors.SizeNESW
            _resizeDirection = HTTOPRIGHT
        ElseIf e.Location.X < ResizeBorderWidth Then
            Me.Cursor = Cursors.SizeWE
            _resizeDirection = HTLEFT
        ElseIf e.Location.X > MyBase.Width - ResizeBorderWidth Then
            Me.Cursor = Cursors.SizeWE
            _resizeDirection = HTRIGHT
        ElseIf e.Location.Y < ResizeBorderWidth Then
            Me.Cursor = Cursors.SizeNS
            _resizeDirection = HTTOP
        ElseIf e.Location.Y > MyBase.Height - ResizeBorderWidth Then
            Me.Cursor = Cursors.SizeNS
            _resizeDirection = HTBOTTOM
        Else
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub NHLGamesMetro_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left And Me.WindowState <> FormWindowState.Maximized Then
            ResizeForm()
        End If
    End Sub

    Private Sub ResizeForm()
        If _resizeDirection <> -1 Then
            ReleaseCapture()
            SendMessage(Me.Handle, WM_NCLBUTTONDOWN, _resizeDirection, 0)
        End If
    End Sub

    Private Sub NHLGamesMetro_MouseLeave(sender As Object, e As EventArgs) Handles MyBase.MouseLeave
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cbServers_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbServers.SelectedIndexChanged
        flpSettings.Focus()
        ApplicationSettings.SetValue(ApplicationSettings.Settings.SelectedServer, cbServers.SelectedItem.ToString())
    End Sub

#End Region
End Class


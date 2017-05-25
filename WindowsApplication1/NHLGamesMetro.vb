Imports System.IO
Imports System.Security.Permissions
Imports System.Threading
Imports System.Net
Imports System.Resources
Imports System.Runtime.InteropServices
Imports System.Web.UI.WebControls.Expressions
Imports System.Windows.Controls
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
    Public Shared HostName As String
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
    Public Shared LabelDate As System.Windows.Forms.Label
    Public Shared DownloadLink As String = "https://www.reddit.com/r/nhl_games/"
    Public Shared GameDate As Date = DateHelper.GetPacificTime()
    Private _resizeDirection As Integer = -1
    Private Const ResizeBorderWidth As Integer = 3
    Public Shared RmText As Resources.ResourceManager  = My.Resources.English.ResourceManager
    Public Shared RmTextErrorString As String = "error:"

    <DllImport("user32.dll")>
    Public Shared Function ReleaseCapture() As Boolean
    End Function

    <DllImport("user32.dll")>
    Public Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal msg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
    End Function

    ' ReSharper disable once InconsistentNaming
    Private Const WM_NCLBUTTONDOWN As Integer = &HA1
    ' ReSharper disable once InconsistentNaming
    Private Const HTBOTTOM As Integer = 15
    ' ReSharper disable once InconsistentNaming
    Private Const HTBOTTOMLEFT As Integer = 16
    ' ReSharper disable once InconsistentNaming
    Private Const HTBOTTOMRIGHT As Integer = 17
    ' ReSharper disable once InconsistentNaming
    Private Const HTLEFT As Integer = 10
    ' ReSharper disable once InconsistentNaming
    Private Const HTRIGHT As Integer = 11
    ' ReSharper disable once InconsistentNaming
    Private Const HTTOP As Integer = 12
    ' ReSharper disable once InconsistentNaming
    Private Const HTTOPLEFT As Integer = 13
    ' ReSharper disable once InconsistentNaming
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

    Private Sub FatalErrorAndMsgBox(message As String, title As String)
        If MetroMessageBox.Show(Me, message, title, MessageBoxButtons.OK, MessageBoxIcon.Error) = DialogResult.OK Then
            Me.close
        End If
    End Sub

    Private Sub NHLGames_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not File.Exists("NHLGames.exe.config") then
            Console.WriteLine(RmText.GetString("errorConfigFile"))
            FatalErrorAndMsgBox(RmText.GetString("errorConfigFile"),RmText.GetString("msgFailure"))
        End If

        AddHandler GameManager.NewGameFound, AddressOf NewGameFoundHandler

        TabControl.SelectedIndex = 0

        Dim lang = ApplicationSettings.Read(Of String)(ApplicationSettings.Settings.SelectedLanguage, String.Empty)
        If String.IsNullOrEmpty(lang) OrElse lang = RmText.GetString("lblEnglish") Then
            RmText = My.Resources.English.ResourceManager
            RmTextErrorString = My.Resources.English.errorDetection
        ElseIf lang = RmText.GetString("lblFrench") Then
            RmText = My.Resources.French.ResourceManager
            RmTextErrorString = My.Resources.French.errorDetection
        End If

        Try
            _adDetectorViewModel = New AdDetectorViewModel()
            AdDetectionSettingsElementHost.Child = _adDetectorViewModel.SettingsControl
        catch ex As Exception
            Console.WriteLine(RmText.GetString("errorSetAdModule"),ex.Message)
            FatalErrorAndMsgBox(RmText.GetString("errorSetAdModule"),RmText.GetString("msgFailure"))
        end Try

        FlpCalendar = flpCalender
        flpCalender.Controls.Add(New CalenderControl())

        setLanguageOnFrom()
        IntitializeApplicationSettings()
        VersionCheck()

    End Sub

    Private Sub IntitializeApplicationSettings()

        SettingsToolTip.SetToolTip(rbQual1, "300" & RmText.GetString("unitMbHour"))
        SettingsToolTip.SetToolTip(rbQual2, "500" & RmText.GetString("unitMbHour"))
        SettingsToolTip.SetToolTip(rbQual3, "700" & RmText.GetString("unitMbHour"))
        SettingsToolTip.SetToolTip(rbQual4, "950" & RmText.GetString("unitMbHour"))
        SettingsToolTip.SetToolTip(rbQual5, "1.3" & RmText.GetString("unitGbHour"))
        SettingsToolTip.SetToolTip(rbQual6, "1.8" & RmText.GetString("unitGbHour"))
        SettingsToolTip.SetToolTip(chk60, "+700" & RmText.GetString("unitMbHour") &" (+40%)")

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
                Console.WriteLine(RmText.GetString("errorMpvExe"))
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
                Console.WriteLine(RmText.GetString("errorStreamlinkExe"))
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

        Dim languageListFromConfig As String = ApplicationSettings.Read(Of String)(ApplicationSettings.Settings.LanguageList, String.Empty)
        Dim languageList As String() = languageListFromConfig.Split(";")
        For Each lang In languageList
            cbLanguage.Items.Add(lang)
        Next
        cbLanguage.SelectedItem = ApplicationSettings.Read(Of String)(ApplicationSettings.Settings.SelectedLanguage, String.Empty)
        If cbLanguage.SelectedItem Is Nothing Then
            cbLanguage.SelectedItem = cbLanguage.Items(0)
        End If

        Dim serverListFromConfig As String = ApplicationSettings.Read(Of String)(ApplicationSettings.Settings.ServerList, String.Empty)
        Dim serverList As String() = serverListFromConfig.Split(";")
        For Each server In serverList
            cbServers.Items.Add(server)
        Next
        cbServers.SelectedItem = ApplicationSettings.Read(Of String)(ApplicationSettings.Settings.SelectedServer, String.Empty)
        If cbServers.SelectedItem Is Nothing Then
            cbServers.SelectedItem = cbServers.Items(0)
        End If
        _serverIp = Dns.GetHostEntry(cbServers.SelectedItem.ToString()).AddressList.First.ToString()
        HostName = cbServers.SelectedItem.ToString()

        BindWatchArgsToForm(watchArgs)

        If (HostsFile.TestEntry(DomainName, _serverIp) = False) Then
            If MetroMessageBox.Show(Me, RmText.GetString("errorHostnameSet"), RmText.GetString("msgAddHost"), MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                HostsFile.AddEntry(_serverIp, DomainName, True)
            Else
                TabControl.SelectedIndex = 1
            End If
        End If

        progress.Location = New Point((flpGames.Width - progress.Width) / 2, flpGames.Location.Y + 150)
        NoGames.Location = New Point((flpGames.Width - NoGames.Width) / 2, flpGames.Location.Y + 148)

        lblDate.Text = DateHelper.GetFormattedDate(GameDate)

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
            watchArgs.PlayerOutputPath = txtOutputArgs.Text
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

            txtOutputArgs.Text = watchArgs.PlayerOutputPath
            txtOutputArgs.Enabled = watchArgs.UseOutputArgs
            tgOutput.Checked = watchArgs.UseOutputArgs

        End If
    End Sub

    ' Handle the UI exceptions by showing a dialog box, and asking the user whether
    ' or not they wish to abort execution.
    Private Shared Sub Form1_UIThreadException(ByVal sender As Object, ByVal t As ThreadExceptionEventArgs)
        Console.WriteLine(RmText.GetString("errorGeneral"), t.Exception.ToString())
    End Sub

    Private Shared Sub CurrentDomain_UnhandledException(ByVal sender As Object, ByVal e As UnhandledExceptionEventArgs)
        Console.WriteLine(e.ExceptionObject.ToString())
    End Sub

    Public Sub HandleException(e As Exception)
        Console.WriteLine(e.ToString())
    End Sub
    Private Sub VersionCheck()
        Dim strLatest = Downloader.DownloadApplicationVersion()
        Console.WriteLine(RmText.GetString("msgCurrentVersion"), strLatest)
        Dim versionFromSettings = ApplicationSettings.Read(Of String)(ApplicationSettings.Settings.Version, "")

        If strLatest > versionFromSettings Then
            lnkDownload.Text = String.Format(RmText.GetString("msgNewVersionText"), strLatest)
            'DownloadLink &= "wiki/downloads"
             lnkDownload.Width = 500
            Dim strChangeLog = Downloader.DownloadChangelog()
            MetroMessageBox.Show(Me, String.Format(RmText.GetString("msgChangeLog"), strLatest, vbCrLf, vbCrLf, strChangeLog), RmText.GetString("msgNewVersionAvailable"), MessageBoxButtons.OK, MessageBoxIcon.Information)
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
        Dim availableGames As HashSet(Of String)
        Try
            ProgressValue = 0
            SetLoading(True)
            SetFormStatusLabel(RmText.GetString("msgLoadingGames"))

            GameManager.ClearGames()
            ClearGamePanel()

            Dim jsonSchedule As JObject = Downloader.DownloadJsonSchedule(dateTime, refreshing)
            availableGames = Downloader.DownloadAvailableGames()
            GameManager.RefreshGames(dateTime, jsonSchedule, availableGames)

            SetFormStatusLabel(String.Format(RmText.GetString("msgGamesFound"),GameManager.GamesList.Count.ToString()))
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
        OpenFileDialog.Filter = $"VLC|vlc.exe|All files (*.*)|*.*"
        OpenFileDialog.Multiselect = False

        If OpenFileDialog.ShowDialog() = DialogResult.OK Then

            If String.IsNullOrEmpty(OpenFileDialog.FileName) = False And txtVLCPath.Text <> OpenFileDialog.FileName Then
                ApplicationSettings.SetValue(ApplicationSettings.Settings.VlcPath, OpenFileDialog.FileName)
                txtVLCPath.Text = OpenFileDialog.FileName
            End If

        End If
    End Sub

    Private Sub btnMPCPath_Click(sender As Object, e As EventArgs) Handles btnMPCPath.Click
        OpenFileDialog.Filter = $"MPC|mpc-hc64.exe;mpc-hc.exe|All files (*.*)|*.*"
        OpenFileDialog.Multiselect = False

        If OpenFileDialog.ShowDialog() = DialogResult.OK Then

            If String.IsNullOrEmpty(OpenFileDialog.FileName) = False And txtMPCPath.Text <> OpenFileDialog.FileName Then
                ApplicationSettings.SetValue(ApplicationSettings.Settings.MpcPath, OpenFileDialog.FileName)
                txtMPCPath.Text = OpenFileDialog.FileName
            End If

        End If
    End Sub

    Private Sub btnMpvPath_Click(sender As Object, e As EventArgs) Handles btnMpvPath.Click
        OpenFileDialog.Filter = $"MPC|mpv.exe|All files (*.*)|*.*"
        OpenFileDialog.Multiselect = False

        If OpenFileDialog.ShowDialog() = DialogResult.OK Then

            If String.IsNullOrEmpty(OpenFileDialog.FileName) = False And txtMpvPath.Text <> OpenFileDialog.FileName Then
                ApplicationSettings.SetValue(ApplicationSettings.Settings.MpvPath, OpenFileDialog.FileName)
                txtMpvPath.Text = OpenFileDialog.FileName
            End If

        End If
    End Sub

    Private Sub btnstreamlinkPath_Click(sender As Object, e As EventArgs) Handles btnstreamlinkPath.Click
        OpenFileDialog.Filter = $"streamlink|streamlink.exe|All files (*.*)|*.*"
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

    Private Sub btnHosts_Click(sender As Object, e As EventArgs) Handles btnTestHosts.Click
        If HostsFile.TestEntry(DomainName, _serverIp) Then
            MetroMessageBox.Show(Me, RmText.GetString("msgHostsSuccess"), RmText.GetString("msgSuccess"), MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MetroMessageBox.Show(Me, RmText.GetString("msgHostsFailure"), RmText.GetString("msgFailure"), MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

#Region "Settings Changed Update Settings"
    Private Sub chk60_CheckedChanged(sender As Object, e As EventArgs) Handles chk60.CheckedChanged
        If chk60.Checked Then
            rbQual6.Checked = True
            _writeToConsoleSettingsChanged(lblQuality.Text, rbQual6.Text & " @ " & chk60.Text)
        ElseIf rbQual6.Checked Then
            _writeToConsoleSettingsChanged(lblQuality.Text, rbQual6.Text)
        End If
        SetEventArgsFromForm()
    End Sub

    Private Sub _writeToConsoleSettingsChanged(key As String, value As String)
        Console.WriteLine(String.Format(RmText.GetString("msgSettingUpdated"), key, value))
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

' ReSharper disable once ParameterHidesMember
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
        Dim rb As System.Windows.Forms.RadioButton = sender
        If (Not chk60.Checked And rb.Checked) Then _writeToConsoleSettingsChanged(lblQuality.Text, rb.Text)
    End Sub

    Private Sub player_CheckedChanged(sender As Object, e As EventArgs) Handles rbVLC.CheckedChanged, rbMPC.CheckedChanged, rbMpv.CheckedChanged
        SetEventArgsFromForm()
        Dim rb As System.Windows.Forms.RadioButton = sender
        If (rb.Checked) Then _writeToConsoleSettingsChanged(lblPlayer.Text, rb.Text)
    End Sub

    Private Sub rbCDN_CheckedChanged(sender As Object, e As EventArgs) Handles rbLevel3.CheckedChanged, rbAkamai.CheckedChanged
        SetEventArgsFromForm()
        Dim rb As System.Windows.Forms.RadioButton = sender
        If (rb.Checked) Then _writeToConsoleSettingsChanged(lblCdn.Text, rb.Text)
    End Sub

    Private Sub txtOutputPath_TextChanged(sender As Object, e As EventArgs) Handles txtOutputArgs.TextChanged
        SetEventArgsFromForm()
        _writeToConsoleSettingsChanged(lblOutput.Text, txtOutputArgs.Text)
    End Sub

    Private Sub txtPlayerArgs_TextChanged(sender As Object, e As EventArgs) Handles txtPlayerArgs.TextChanged
        SetEventArgsFromForm()
        _writeToConsoleSettingsChanged(lblPlayerArgs.Text, txtPlayerArgs.Text)
    End Sub

    Private Sub txtStreamerArgs_TextChanged(sender As Object, e As EventArgs) Handles txtStreamerArgs.TextChanged
        SetEventArgsFromForm()
        _writeToConsoleSettingsChanged(lblStreamerArgs.Text, txtStreamerArgs.Text)
    End Sub

    Private Sub btnOuput_Click(sender As Object, e As EventArgs) Handles btnOuput.Click
        SaveFileDialog.CheckPathExists = True

        If txtOutputArgs.Text.Count > 0 Then
            SaveFileDialog.InitialDirectory = Path.GetDirectoryName(txtOutputArgs.Text)
            SaveFileDialog.FileName = Path.GetFileName(txtOutputArgs.Text)
        Else
            SaveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos)
            SaveFileDialog.FileName = "(DATE)_(HOME)_vs_(AWAY)_(TYPE)_(QUAL)"
        End If

        SaveFileDialog.Filter = $"MP4 Files (*.mp4)|*.MP4"
        SaveFileDialog.DefaultExt = "mp4"
        SaveFileDialog.AddExtension = True

        If SaveFileDialog.ShowDialog() = DialogResult.OK Then
            txtOutputArgs.Text = SaveFileDialog.FileName
            SetEventArgsFromForm()
        End If
    End Sub

    Private Sub btnYesterday_Click(sender As Object, e As EventArgs) Handles btnYesterday.Click
        GameDate = GameDate.AddDays(-1)
        lblDate.Text = DateHelper.GetFormattedDate(GameDate)
    End Sub

    Private Sub btnTomorrow_Click(sender As Object, e As EventArgs) Handles btnTomorrow.Click
        GameDate = GameDate.AddDays(1)
        lblDate.Text = DateHelper.GetFormattedDate(GameDate)
    End Sub


    Private Sub btnClean_Click(sender As Object, e As EventArgs) Handles btnCleanHosts.Click
        HostsFile.CleanHosts(DomainName, True)
    End Sub

    Private Sub lnkVLCDownload_Click(sender As Object, e As EventArgs) Handles lblGetVlc.Click
        Dim sInfo As ProcessStartInfo = New ProcessStartInfo("http://www.videolan.org/vlc/download-windows.html")
        Process.Start(sInfo)
    End Sub

    Private Sub lnkMPCDownload_Click(sender As Object, e As EventArgs) Handles lblGetMpc.Click
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
        _writeToConsoleSettingsChanged(String.Format(RmText.GetString("msgThisEnable"), lblStreamerArgs.Text), 
                                       if(tgStreamer.Checked, RmText.GetString("msgOn"), RmText.GetString("msgOff")))
    End Sub

    Private Sub tgPlayer_CheckedChanged(sender As Object, e As EventArgs) Handles tgPlayer.CheckedChanged
        txtPlayerArgs.Enabled = tgPlayer.Checked
        SetEventArgsFromForm()
        _writeToConsoleSettingsChanged(String.Format(RmText.GetString("msgThisEnable"),lblPlayerArgs.Text), 
                                       if(tgPlayer.Checked, RmText.GetString("msgOn"), RmText.GetString("msgOff")))
    End Sub

    Private Sub tgOutput_CheckedChanged(sender As Object, e As EventArgs) Handles tgOutput.CheckedChanged
        txtOutputArgs.Enabled = tgOutput.Checked
        SetEventArgsFromForm()
        _writeToConsoleSettingsChanged(String.Format(RmText.GetString("msgThisEnable"),lblOutput.Text),
                                       if(tgOutput.Checked, RmText.GetString("msgOn"), RmText.GetString("msgOff")))
    End Sub

    Private Sub chkShowSeriesRecord_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowSeriesRecord.CheckedChanged
        ApplicationSettings.SetValue(ApplicationSettings.Settings.ShowSeriesRecord, chkShowSeriesRecord.Checked)
    End Sub

    Private Shared Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        Dim sInfo As ProcessStartInfo = New ProcessStartInfo("https://github.com/NHLGames/NHLGames#nhlgames")
        Process.Start(sInfo)
    End Sub

    Private Sub btnMaximize_Click(sender As Object, e As EventArgs) Handles btnMaximize.Click
        WindowState = FormWindowState.Maximized
        btnMaximize.Visible = False
        btnNormal.Visible = True
    End Sub

    Private Sub btnMinimize_Click(sender As Object, e As EventArgs) Handles btnMinimize.Click
        WindowState = FormWindowState.Minimized
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub

    Private Sub btnNormal_Click(sender As Object, e As EventArgs) Handles btnNormal.Click
        WindowState = FormWindowState.Normal
        btnMaximize.Visible = True
        btnNormal.Visible = False
    End Sub

    Private Sub TabControl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl.SelectedIndexChanged
        Dim tc As System.Windows.Forms.TabControl = sender
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
        Refresh()
        flpGames.Focus()
    End Sub

    Private Sub NHLGamesMetro_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove
        'Calculate which direction to resize based on mouse position
        _resizeDirection = -1
        If e.Location.X < ResizeBorderWidth And e.Location.Y < ResizeBorderWidth Then
            Cursor = Cursors.SizeNWSE
            _resizeDirection = HTTOPLEFT
        ElseIf e.Location.X < ResizeBorderWidth And e.Location.Y > Height - ResizeBorderWidth Then
            Cursor = Cursors.SizeNESW
            _resizeDirection = HTBOTTOMLEFT
        ElseIf e.Location.X > Width - ResizeBorderWidth And e.Location.Y > Height - ResizeBorderWidth Then
            Cursor = Cursors.SizeNWSE
            _resizeDirection = HTBOTTOMRIGHT
        ElseIf e.Location.X > Width - ResizeBorderWidth And e.Location.Y < ResizeBorderWidth Then
            Cursor = Cursors.SizeNESW
            _resizeDirection = HTTOPRIGHT
        ElseIf e.Location.X < ResizeBorderWidth Then
            Cursor = Cursors.SizeWE
            _resizeDirection = HTLEFT
        ElseIf e.Location.X > Width - ResizeBorderWidth Then
            Cursor = Cursors.SizeWE
            _resizeDirection = HTRIGHT
        ElseIf e.Location.Y < ResizeBorderWidth Then
            Cursor = Cursors.SizeNS
            _resizeDirection = HTTOP
        ElseIf e.Location.Y > Height - ResizeBorderWidth Then
            Cursor = Cursors.SizeNS
            _resizeDirection = HTBOTTOM
        Else
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub NHLGamesMetro_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown
        If e.Button = MouseButtons.Left And WindowState <> FormWindowState.Maximized Then
            ResizeForm()
        End If
    End Sub

    Private Sub ResizeForm()
        If _resizeDirection <> -1 Then
            ReleaseCapture()
            SendMessage(Handle, WM_NCLBUTTONDOWN, _resizeDirection, 0)
        End If
    End Sub

    Private Sub NHLGamesMetro_MouseLeave(sender As Object, e As EventArgs) Handles MyBase.MouseLeave
        Cursor = Cursors.Default
    End Sub

    Private Sub cbServers_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbServers.SelectedIndexChanged
        flpSettings.Focus()
        ApplicationSettings.SetValue(ApplicationSettings.Settings.SelectedServer, cbServers.SelectedItem.ToString())
    End Sub

    Private Sub btnCopyConsole_Click(sender As Object, e As EventArgs) Handles btnCopyConsole.Click
        dim player As String = if (rbMpv.Checked,"MPV",If(rbMPC.Checked,"MPC",If(rbVLC.Checked,"VLC","none")))
        Dim x64 As String = if(Environment.Is64BitOperatingSystem,"64 Bits","32 Bits")
        Clipboard.SetText(String.Format(RmText.GetString("textCopyConsole"),
                                        vbCrLf,lblVersion.Text,
                                        My.Computer.Info.OSFullName.ToString(), x64.ToString(), 
                                        (Not String.IsNullOrEmpty(lblDate.Text)).ToString(),
                                        HostsFile.TestEntry(DomainName,_serverIp).ToString(),
                                        My.Computer.Network.Ping(_serverIp).ToString(),
                                        cbServers.SelectedItem.ToString(),
                                        player.ToString(),
                                        ApplicationSettings.Read(Of String)(ApplicationSettings.Settings.StreamlinkPath, String.Empty).ToString(),
                                        (ApplicationSettings.Read(Of String)(ApplicationSettings.Settings.StreamlinkPath, String.Empty)=txtStreamlinkPath.Text).ToString(),
                                        ApplicationSettings.Read(Of String)(ApplicationSettings.Settings.VlcPath, String.Empty).ToString(),
                                        (ApplicationSettings.Read(Of String)(ApplicationSettings.Settings.VlcPath, String.Empty)=txtVLCPath.Text).ToString(),
                                        ApplicationSettings.Read(Of String)(ApplicationSettings.Settings.MpcPath, String.Empty).ToString(),
                                        (ApplicationSettings.Read(Of String)(ApplicationSettings.Settings.MpcPath, String.Empty)=txtMPCPath.Text).ToString(),
                                        ApplicationSettings.Read(Of String)(ApplicationSettings.Settings.MpvPath, String.Empty).ToString(),
                                        (ApplicationSettings.Read(Of String)(ApplicationSettings.Settings.MpvPath, String.Empty)=txtMpvPath.Text).ToString(),
                                        RichTextBox.Text))
    End Sub


#End Region

    Private Sub SetLanguageOnFrom()
        'Main
        TabControl.TabPages.Item(0).Text = RmText.GetString("tabGames")
        TabControl.TabPages.Item(1).Text = RmText.GetString("tabSettings")
        TabControl.TabPages.Item(2).Text = RmText.GetString("tabConsole")
        TabControl.TabPages.Item(3).Text = RmText.GetString("tabModules")

        NoGames.Text = RmText.GetString("lblNoGames")
       
        'Games

        'Settings
        lblShowScores.Text = RmText.GetString("lblShowScores")
        lblPlayer.Text = RmText.GetString("lblPlayer")
        lblQuality.Text = RmText.GetString("lblQuality")
        lblCdn.Text = RmText.GetString("lblCdn")
        lblHostname.Text = RmText.GetString("lblHostname")
        lblHosts.Text = RmText.GetString("lblHosts")
        lblVlcPath.Text = RmText.GetString("lblVlcPath")
        lblMpcPath.Text = RmText.GetString("lblMpcPath")
        lblMpvPath.Text = RmText.GetString("lblMpvPath")
        lblSlPath.Text = RmText.GetString("lblSlPath")
        lblOutput.Text = RmText.GetString("lblOutput")
        lblPlayerArgs.Text = RmText.GetString("lblPlayerArgs")
        lblStreamerArgs.Text = RmText.GetString("lblStreamerArgs")
        lblLanguage.Text = RmText.GetString("lblLanguage")

        lblGetVlc.Text = RmText.GetString("lblGetVlc")
        lblGetMpc.Text = RmText.GetString("lblGetMpc")
        lblNoteCdn.Text = RmText.GetString("lblNoteCdn")

        chkShowFinalScores.Text = RmText.GetString("chkShowFinalScores")
        chkShowLiveScores.Text = RmText.GetString("chkShowLiveScores")
        chkShowSeriesRecord.Text = RmText.GetString("chkShowSeriesRecord")

        btnTestHosts.Text = RmText.GetString("btnTestHosts")
        btnOpenHostsFile.Text = RmText.GetString("btnOpenHostsFile")
        btnAddHosts.Text = RmText.GetString("btnAddHosts")
        btnCleanHosts.Text = RmText.GetString("btnCleanHosts")

        lnkDiySteps.Text = RmText.GetString("msgDiySteps")

        SettingsToolTip.SetToolTip(btnTestHosts, RmText.GetString("msgTestHosts"))
        SettingsToolTip.SetToolTip(btnOpenHostsFile, RmText.GetString("msgViewHosts"))
        SettingsToolTip.SetToolTip(btnAddHosts, RmText.GetString("msgAddHost"))
        SettingsToolTip.SetToolTip(btnCleanHosts, RmText.GetString("msgRemoveHost"))
        
        'Console
        btnCopyConsole.Text = RmText.GetString("btnCopyConsole")
        btnClearConsole.Text = RmText.GetString("btnClearConsole")
        
    End Sub

    Private Sub cbLanguage_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbLanguage.SelectedIndexChanged
        flpSettings.Focus()
        ApplicationSettings.SetValue(ApplicationSettings.Settings.SelectedLanguage, cbLanguage.SelectedItem.ToString())
    End Sub

    Private Sub lnkDiySteps_Click(sender As Object, e As EventArgs) Handles lnkDiySteps.Click
        Dim result As DialogResult
        result = MetroMessageBox.Show(Me, String.Format(RmText.GetString("msgDiyStepsText"),
            vbCrLf, _serverIp, DomainName), RmText.GetString("msgDiySteps"), MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        If result = DialogResult.Yes Then
            Clipboard.SetText(_serverIp & " " & DomainName)
        End If
    End Sub
End Class


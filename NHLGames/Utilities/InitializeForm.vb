Imports System.IO
Imports System.Net
Imports System.Text.RegularExpressions
Imports NHLGames.Objects
Imports NHLGames.Objects.Modules

Namespace Utilities
    Public Class InitializeForm
        Private ReadOnly Shared Form As NHLGamesMetro = NHLGamesMetro.FormInstance

        Public Shared Sub VersionCheck()
            Dim latestVersion = Downloader.DownloadApplicationVersion()
            
            If latestVersion > My.Application.Info.Version Then
                Form.lnkDownload.Text = String.Format(
                    NHLGamesMetro.RmText.GetString("msgNewVersionText"), 
                    latestVersion.ToString())
                Form.lnkDownload.Width = 700
                Dim strChangeLog = Downloader.DownloadChangelog()
                InvokeElement.MsgBoxBlue(String.Format(NHLGamesMetro.RmText.GetString("msgChangeLog"), latestVersion.ToString(), vbCrLf, vbCrLf, strChangeLog),
                                         NHLGamesMetro.RmText.GetString("msgNewVersionAvailable"),
                                         MessageBoxButtons.OK)
            End If
            Form.lblVersion.Text = String.Format("v {0}.{1}.{2}", My.Application.Info.Version.Major,
                                                 My.Application.Info.Version.Minor,
                                                 My.Application.Info.Version.Build)
        End Sub
        
        Public Shared Sub SetLanguage()
            Dim lstHostsFileActions = New String() {
                NHLGamesMetro.RmText.GetString("cbHostsTest"),
                NHLGamesMetro.RmText.GetString("cbHostsAdd"),
                NHLGamesMetro.RmText.GetString("cbHostsRemove"),
                NHLGamesMetro.RmText.GetString("cbHostsView"),
                NHLGamesMetro.RmText.GetString("cbHostsEntry"),
                NHLGamesMetro.RmText.GetString("cbHostsLocation")
            }

            Dim lstStreamQualities = New String() {
                NHLGamesMetro.RmText.GetString("cbQualitySuperb60fps"),
                NHLGamesMetro.RmText.GetString("cbQualitySuperb"),
                NHLGamesMetro.RmText.GetString("cbQualityGreat"),
                NHLGamesMetro.RmText.GetString("cbQualityGood"),
                NHLGamesMetro.RmText.GetString("cbQualityNormal"),
                NHLGamesMetro.RmText.GetString("cbQualityLow"),
                NHLGamesMetro.RmText.GetString("cbQualityMobile")
            }

            'Main
            Form.tabMenu.TabPages.Item(0).Text = NHLGamesMetro.RmText.GetString("tabGames")
            Form.tabMenu.TabPages.Item(1).Text = NHLGamesMetro.RmText.GetString("tabSettings")
            Form.tabMenu.TabPages.Item(2).Text = NHLGamesMetro.RmText.GetString("tabConsole")

            Form.lblNoGames.Text = NHLGamesMetro.RmText.GetString("lblNoGames")
            Form.lblStatus.Text = String.Format(NHLGamesMetro.RmText.GetString("msgGamesFound"), NHLGamesMetro.FormInstance.flpGames.Controls.Count())

            'Settings
            Form.lblGamePanel.Text = NHLGamesMetro.RmText.GetString("lblShowScores")
            Form.lblPlayer.Text = NHLGamesMetro.RmText.GetString("lblPlayer")
            Form.lblQuality.Text = NHLGamesMetro.RmText.GetString("lblQuality")
            Form.lblCdn.Text = NHLGamesMetro.RmText.GetString("lblCdn")
            Form.lblHostname.Text = NHLGamesMetro.RmText.GetString("lblHostname")
            Form.lblHosts.Text = NHLGamesMetro.RmText.GetString("lblHosts")
            Form.lblVlcPath.Text = NHLGamesMetro.RmText.GetString("lblVlcPath")
            Form.lblMpcPath.Text = NHLGamesMetro.RmText.GetString("lblMpcPath")
            Form.lblMpvPath.Text = NHLGamesMetro.RmText.GetString("lblMpvPath")
            Form.lblSlPath.Text = NHLGamesMetro.RmText.GetString("lblSlPath")
            Form.lblOutput.Text = NHLGamesMetro.RmText.GetString("lblOutput")
            Form.lblPlayerArgs.Text = NHLGamesMetro.RmText.GetString("lblPlayerArgs")
            Form.lblStreamerArgs.Text = NHLGamesMetro.RmText.GetString("lblStreamerArgs")
            Form.lblLanguage.Text = NHLGamesMetro.RmText.GetString("lblLanguage")
            Form.lblUseAlternateCdn.Text = NHLGamesMetro.RmText.GetString("lblAlternateCdn")

            Form.lblGamePanel.Text = NHLGamesMetro.RmText.GetString("lblGamePanel")
            Form.lblShowFinalScores.Text = NHLGamesMetro.RmText.GetString("lblShowFinalScores")
            Form.lblShowLiveScores.Text = NHLGamesMetro.RmText.GetString("lblShowLiveScores")
            Form.lblShowSeriesRecord.Text = NHLGamesMetro.RmText.GetString("lblShowSeriesRecord")
            Form.lblShowTeamCityAbr.Text = NHLGamesMetro.RmText.GetString("lblShowTeamCityAbr")

            Form.cbStreamQuality.Items.Clear()
            Form.cbStreamQuality.Items.AddRange(lstStreamQualities)
            Form.cbStreamQuality.SelectedIndex = 0

            Form.cbHostsFileActions.Items.Clear()
            Form.cbHostsFileActions.Items.AddRange(lstHostsFileActions)
            Form.cbHostsFileActions.SelectedIndex = 0

            Form.SettingsToolTip.SetToolTip(Form.lnkGetVlc, NHLGamesMetro.RmText.GetString("tipGetVlc"))
            Form.SettingsToolTip.SetToolTip(Form.lnkGetMpc, NHLGamesMetro.RmText.GetString("tipGetMpc"))
            Form.SettingsToolTip.SetToolTip(Form.btnHostsFileActions, NHLGamesMetro.RmText.GetString("tipHostsExecuteAction"))
            Form.SettingsToolTip.SetToolTip(Form.btnMPCPath, NHLGamesMetro.RmText.GetString("tipBrowse"))
            Form.SettingsToolTip.SetToolTip(Form.btnMpvPath, NHLGamesMetro.RmText.GetString("tipBrowse"))
            Form.SettingsToolTip.SetToolTip(Form.btnMPCPath, NHLGamesMetro.RmText.GetString("tipBrowse"))
            Form.SettingsToolTip.SetToolTip(Form.btnstreamerPath, NHLGamesMetro.RmText.GetString("tipBrowse"))
            Form.SettingsToolTip.SetToolTip(Form.btnOuput, NHLGamesMetro.RmText.GetString("tipBrowse"))

            Form.lblModules.Text = NHLGamesMetro.RmText.GetString("lblModules")
            Form.lblModulesDesc.Text = NHLGamesMetro.RmText.GetString("lblModulesDesc")
            Form.lblSpotify.Text = NHLGamesMetro.RmText.GetString("lblSpotify")
            Form.lblSpotifyDesc.Text = NHLGamesMetro.RmText.GetString("lblSpotifyDesc")
            Form.lblOBS.Text = NHLGamesMetro.RmText.GetString("lblObs")
            Form.lblOBSDesc.Text = NHLGamesMetro.RmText.GetString("lblObsDesc")
            Form.lblObsAdEndingHotkey.Text = NHLGamesMetro.RmText.GetString("lblObsAdEndingHotkey")
            Form.lblObsAdStartingHotkey.Text = NHLGamesMetro.RmText.GetString("lblObsAdStartingHotkey")
            Form.chkSpotifyForceToStart.Text = NHLGamesMetro.RmText.GetString("chkSpotifyForceToStart")
            Form.chkSpotifyPlayNextSong.Text = NHLGamesMetro.RmText.GetString("chkSpotifyPlayNextSong")
            Form.chkSpotifyAnyMediaPlayer.Text = NHLGamesMetro.RmText.GetString("chkSpotifyAnyMediaPlayer")
        
            'Console
            Form.btnCopyConsole.Text = NHLGamesMetro.RmText.GetString("btnCopyConsole")
            Form.btnClearConsole.Text = NHLGamesMetro.RmText.GetString("btnClearConsole")

            'Calendar
            Form.flpCalender.Controls.Clear()
            Form.flpCalender.Controls.Add(New Controls.CalenderControl)
        End Sub

        Public Shared Sub SetSettings()
            Form.txtMPCPath.Text = GetApplication(SettingsEnum.MpcPath, PathFinder.GetPathOfMpc())
            Form.txtVLCPath.Text = GetApplication(SettingsEnum.VlcPath, PathFinder.GetPathOfVlc())
            Form.txtMpvPath.Text = GetApplication(SettingsEnum.MpvPath, Path.Combine(Application.StartupPath, "mpv\mpv.exe"))
            Form.txtStreamerPath.Text = GetApplication(SettingsEnum.StreamerPath, Path.Combine(Application.StartupPath, "livestreamer\livestreamer.exe"))

            Form.tgShowFinalScores.Checked = ApplicationSettings.Read(Of Boolean)(SettingsEnum.ShowScores, True)
            Form.tgShowLiveScores.Checked = ApplicationSettings.Read(Of Boolean)(SettingsEnum.ShowLiveScores, True)
            Form.tgShowSeriesRecord.Checked = ApplicationSettings.Read(Of Boolean)(SettingsEnum.ShowSeriesRecord, True)
            Form.tgShowTeamCityAbr.Checked = ApplicationSettings.Read(Of Boolean)(SettingsEnum.ShowTeamCityAbr, True)

            PopulateComboBox(Form.cbLanguage, SettingsEnum.SelectedLanguage, SettingsEnum.LanguageList)

            Dim playersPath As String() = New String() {Form.txtMpvPath.Text, Form.txtMPCPath.Text, Form.txtVLCPath.Text}
            Dim watchArgs As GameWatchArguments = ApplicationSettings.Read(Of GameWatchArguments)(SettingsEnum.DefaultWatchArgs)

            If ValidWatchArgs(watchArgs, playersPath, Form.txtStreamerPath.Text) Then
                Player.RenewArgs(True)
                watchArgs = ApplicationSettings.Read(Of GameWatchArguments)(SettingsEnum.DefaultWatchArgs)
            End If

            PopulateComboBox(Form.cbServers, SettingsEnum.SelectedServer, settingsenum.ServerList)

            NHLGamesMetro.ServerIp = Dns.GetHostEntry(Form.cbServers.SelectedItem.ToString()).AddressList.First.ToString()
            NHLGamesMetro.HostName = Form.cbServers.SelectedItem.ToString()

            BindWatchArgsToForm(watchArgs)

            If (HostsFile.TestEntry( NHLGamesMetro.DomainName, NHLGamesMetro.ServerIp) = False) Then
                If InvokeElement.MsgBoxBlue(NHLGamesMetro.RmText.GetString("msgHostnameSet"), 
                                            NHLGamesMetro.RmText.GetString("msgAddHost"), 
                                            MessageBoxButtons.YesNo) = DialogResult.Yes Then
                    HostsFile.AddEntry(NHLGamesMetro.ServerIp,  NHLGamesMetro.DomainName, False)
                Else
                    Form.tabMenu.SelectedIndex = 1
                End If
            End If

            Dim adDetectionConfigs As AdDetectionConfigs = ApplicationSettings.Read(Of AdDetectionConfigs)(SettingsEnum.AdDetection)

            If adDetectionConfigs Is Nothing Then 
                AdDetection.Renew(True)
                adDetectionConfigs = ApplicationSettings.Read(Of AdDetectionConfigs)(SettingsEnum.AdDetection)
            End If

            BindAdDetectionConfigsToForm(adDetectionConfigs)

            Form.lblNoGames.Location = New Point(((Form.tabGames.Width - Form.lblNoGames.Width) / 2),  Form.tabGames.Height / 2)
            Form.spnLoading.Location = New Point(((Form.tabGames.Width - Form.lblNoGames.Width) / 2) + 40, (Form.tabGames.Height / 2) - 20)

            Form.spnLoading.Value = NHLGamesMetro.SpnLoadingValue
            Form.spnLoading.Maximum = NHLGamesMetro.spnLoadingMaxValue
            Form.spnStreaming.Value = NHLGamesMetro.SpnStreamingValue
            Form.spnStreaming.Maximum = NHLGamesMetro.spnStreamingMaxValue
            Form.lblDate.Text = DateHelper.GetFormattedDate(NHLGamesMetro.GameDate)
            
            NHLGamesMetro.LabelDate = Form.lblDate
            NHLGamesMetro.GamesDownloadedTime = Now
        End Sub

        Private Shared Function GetApplication(varPath As SettingsEnum, currentPath As String)
            Dim savedPathFromConfig As String = ApplicationSettings.Read(Of String)(varPath, String.Empty)
            Dim currentPathIfFound As String = currentPath

            If savedPathFromConfig.Equals(String.Empty) And Not currentPathIfFound.Equals(String.Empty) Then
                ApplicationSettings.SetValue(varPath, currentPathIfFound)
                savedPathFromConfig = currentPathIfFound
            ElseIf savedPathFromConfig <> currentPathIfFound And Not currentPathIfFound.Equals(String.Empty) Then
                ApplicationSettings.SetValue(varPath, currentPathIfFound)
                savedPathFromConfig = currentPathIfFound
            End If

            If Not File.Exists(savedPathFromConfig) Then
                savedPathFromConfig = String.Empty
                ApplicationSettings.SetValue(varPath, savedPathFromConfig)
            End If
            return savedPathFromConfig
        End Function

        Private Shared Sub PopulateComboBox(cb As MetroFramework.Controls.MetroComboBox, selectedItem As SettingsEnum, items As SettingsEnum)
            Dim cbItemsFromConfig As String = ApplicationSettings.Read(Of String)(items, String.Empty)

            cb.Items.AddRange(cbItemsFromConfig.Split(";"))

            cb.SelectedItem = ApplicationSettings.Read(Of String)(selectedItem, String.Empty)
            If cb.SelectedItem Is Nothing Then
                cb.SelectedItem = cb.Items(0)
            End If
        End Sub

        Private Shared Function ValidWatchArgs(watchArgs As GameWatchArguments, playersPath As String(), streamerPath As String) As Boolean
            If watchArgs Is Nothing Then Return True

            Dim hasPlayerSet As Boolean = playersPath.Any(Function(x) x = watchArgs.PlayerPath)
            If Not watchArgs.streamerPath.Equals(streamerPath) Then Return True
            If Not hasPlayerSet Then
                watchArgs.PlayerType = PlayerTypeEnum.None
                watchArgs.PlayerPath = String.Empty
                Form.rbMPC.Enabled = False
                Form.rbVLC.Enabled = False
                Form.rbMpv.Enabled = False
                Return True
            End If

            Return False
        End Function

        Private Shared Sub BindWatchArgsToForm(watchArgs As GameWatchArguments)
            If watchArgs IsNot Nothing Then
                Form.cbStreamQuality.SelectedIndex = CType(watchArgs.Quality, Integer)

                Form.tgAlternateCdn.Checked = watchArgs.Cdn = CdnType.L3C

                Form.rbVLC.Checked = watchArgs.PlayerType = PlayerTypeEnum.Vlc
                Form.rbMPC.Checked = watchArgs.PlayerType = PlayerTypeEnum.Mpc
                Form.rbMpv.Checked = watchArgs.PlayerType = PlayerTypeEnum.Mpv

                If Form.rbVLC.Checked AndAlso watchArgs.PlayerPath <> Form.txtVLCPath.Text Then
                    Player.RenewArgs()
                ElseIf Form.rbMPC.Checked AndAlso watchArgs.PlayerPath <> Form.txtMPCPath.Text Then
                    Player.RenewArgs()
                ElseIf Form.rbMpv.Checked AndAlso watchArgs.PlayerPath <> Form.txtMpvPath.Text Then
                    Player.RenewArgs()
                End If

                Form.tgPlayer.Checked = watchArgs.UsePlayerArgs
                Form.txtPlayerArgs.Enabled = watchArgs.UsePlayerArgs
                Form.txtPlayerArgs.Text = watchArgs.PlayerArgs

                Form.tgStreamer.Checked = watchArgs.UsestreamerArgs
                Form.txtStreamerArgs.Enabled = watchArgs.UsestreamerArgs
                Form.txtStreamerArgs.Text = watchArgs.streamerArgs

                Form.txtOutputArgs.Text = watchArgs.PlayerOutputPath
                Form.txtOutputArgs.Enabled = watchArgs.UseOutputArgs
                Form.tgOutput.Checked = watchArgs.UseOutputArgs
            End If
        End Sub

        Private Shared Sub BindAdDetectionConfigsToForm(configs As AdDetectionConfigs)
            If configs IsNot Nothing Then
                
                form.tgModules.Checked = configs.IsEnabled

                form.chkSpotifyForceToStart.Checked = configs.EnabledSpotifyForceToOpen
                form.chkSpotifyPlayNextSong.Checked = configs.EnabledSpotifyPlayNextSong
                Form.chkSpotifyAnyMediaPlayer.Checked = configs.EnabledSpotifyAndAnyMediaPlayer

                form.txtAdKey.Text = configs.EnabledObsAdSceneHotKey.Key
                form.chkAdCtrl.Checked = configs.EnabledObsAdSceneHotKey.Ctrl
                form.chkAdAlt.Checked = configs.EnabledObsAdSceneHotKey.Alt
                form.chkAdShift.Checked = configs.EnabledObsAdSceneHotKey.Shift

                form.txtGameKey.Text = configs.EnabledObsGameSceneHotKey.Key
                form.chkGameCtrl.Checked = configs.EnabledObsGameSceneHotKey.Ctrl
                form.chkGameAlt.Checked = configs.EnabledObsGameSceneHotKey.Alt
                form.chkGameShift.Checked = configs.EnabledObsGameSceneHotKey.Shift

                form.tgSpotify.Checked = configs.EnabledSpotifyModule
                form.tgOBS.Checked = configs.EnabledObsModule
                
            End If
        End Sub

    End Class
End Namespace

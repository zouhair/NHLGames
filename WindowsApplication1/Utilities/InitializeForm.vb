Imports System.IO
Imports System.Net
Imports NHLGames.Objects

Namespace Utilities
    Public Class InitializeForm
        Private ReadOnly Shared Form As NHLGamesMetro = NHLGamesMetro.FormInstance

        Public Shared Sub VersionCheck()
            Dim strLatest = Downloader.DownloadApplicationVersion()
            Dim versionFromSettings = ApplicationSettings.Read(Of String)(SettingsEnum.Version, "")

            If strLatest > versionFromSettings Then
                Form.lnkDownload.Text = String.Format(
                    NHLGamesMetro.RmText.GetString("msgNewVersionText"), 
                    strLatest)
                Form.lnkDownload.Width = 700
                Dim strChangeLog = Downloader.DownloadChangelog()
                InvokeElement.MsgBoxBlue(String.Format(NHLGamesMetro.RmText.GetString("msgChangeLog"), strLatest, vbCrLf, vbCrLf, strChangeLog),
                                         NHLGamesMetro.RmText.GetString("msgNewVersionAvailable"),
                                         MessageBoxButtons.OK)
            End If
            Form.lblVersion.Text = String.Format("v{0}.{1}.{2}.{3}", 
                                                 My.Application.Info.Version.Major, 
                                                 My.Application.Info.Version.Minor, 
                                                 My.Application.Info.Version.Build, 
                                                 My.Application.Info.Version.Revision)
                'String.Format("v{0}", ApplicationSettings.Read(Of String)(SettingsEnum.Version))
        End Sub

        Public Shared Sub SetLanguage()
            Dim lstHostsFileAction = New String() {
                NHLGamesMetro.RmText.GetString("cbHostsTest"),
                NHLGamesMetro.RmText.GetString("cbHostsAdd"),
                NHLGamesMetro.RmText.GetString("cbHostsRemove"),
                NHLGamesMetro.RmText.GetString("cbHostsView"),
                NHLGamesMetro.RmText.GetString("cbHostsEntry"),
                NHLGamesMetro.RmText.GetString("cbHostsLocation")
            }

            'Main
            Form.tabMenu.TabPages.Item(0).Text = NHLGamesMetro.RmText.GetString("tabGames")
            Form.tabMenu.TabPages.Item(1).Text = NHLGamesMetro.RmText.GetString("tabSettings")
            Form.tabMenu.TabPages.Item(2).Text = NHLGamesMetro.RmText.GetString("tabConsole")
            Form.tabMenu.TabPages.Item(3).Text = NHLGamesMetro.RmText.GetString("tabModules")


            Form.lblNoGames.Text = NHLGamesMetro.RmText.GetString("lblNoGames")

            'Settings
            Form.lblShowScores.Text = NHLGamesMetro.RmText.GetString("lblShowScores")
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
            Form.lblNoteCdn.Text = NHLGamesMetro.RmText.GetString("lblNoteCdn")

            Form.chkShowFinalScores.Text = NHLGamesMetro.RmText.GetString("chkShowFinalScores")
            Form.chkShowLiveScores.Text = NHLGamesMetro.RmText.GetString("chkShowLiveScores")
            Form.chkShowSeriesRecord.Text = NHLGamesMetro.RmText.GetString("chkShowSeriesRecord")

            Form.rbQual1.Text = NHLGamesMetro.RmText.GetString("rbQualityMobile")
            Form.rbQual2.Text = NHLGamesMetro.RmText.GetString("rbQualityLow")
            Form.rbQual3.Text = NHLGamesMetro.RmText.GetString("rbQualityNormal")
            Form.rbQual4.Text = NHLGamesMetro.RmText.GetString("rbQualityGood")
            Form.rbQual5.Text = NHLGamesMetro.RmText.GetString("rbQualityGreat")
            Form.rbQual6.Text = NHLGamesMetro.RmText.GetString("rbQualitySuperb")
            Form.chk60.Text = NHLGamesMetro.RmText.GetString("rbQuality60fps")

            Form.cbHostsFileActions.Items.Clear()
            Form.cbHostsFileActions.Items.AddRange(lstHostsFileAction)
            Form.cbHostsFileActions.SelectedIndex = 0

            Form.SettingsToolTip.SetToolTip(Form.lnkGetVlc, NHLGamesMetro.RmText.GetString("tipGetVlc"))
            Form.SettingsToolTip.SetToolTip(Form.lnkGetMpc, NHLGamesMetro.RmText.GetString("tipGetMpc"))
            Form.SettingsToolTip.SetToolTip(Form.btnHostsFileActions, NHLGamesMetro.RmText.GetString("tipHostsExecuteAction"))
            Form.SettingsToolTip.SetToolTip(Form.btnMPCPath, NHLGamesMetro.RmText.GetString("tipBrowse"))
            Form.SettingsToolTip.SetToolTip(Form.btnMpvPath, NHLGamesMetro.RmText.GetString("tipBrowse"))
            Form.SettingsToolTip.SetToolTip(Form.btnMPCPath, NHLGamesMetro.RmText.GetString("tipBrowse"))
            Form.SettingsToolTip.SetToolTip(Form.btnstreamlinkPath, NHLGamesMetro.RmText.GetString("tipBrowse"))
            Form.SettingsToolTip.SetToolTip(Form.btnOuput, NHLGamesMetro.RmText.GetString("tipBrowse"))
            Form.SettingsToolTip.SetToolTip(Form.rbQual1, "300" & NHLGamesMetro.RmText.GetString("tipFormatMbHour"))
            Form.SettingsToolTip.SetToolTip(Form.rbQual2, "500" & NHLGamesMetro.RmText.GetString("tipFormatMbHour"))
            Form.SettingsToolTip.SetToolTip(Form.rbQual3, "700" & NHLGamesMetro.RmText.GetString("tipFormatMbHour"))
            Form.SettingsToolTip.SetToolTip(Form.rbQual4, "950" & NHLGamesMetro.RmText.GetString("tipFormatMbHour"))
            Form.SettingsToolTip.SetToolTip(Form.rbQual5, "1.3" & NHLGamesMetro.RmText.GetString("tipFormatGbHour"))
            Form.SettingsToolTip.SetToolTip(Form.rbQual6, "1.8" & NHLGamesMetro.RmText.GetString("tipFormatGbHour"))
            Form.SettingsToolTip.SetToolTip(Form.chk60, "+700" & NHLGamesMetro.RmText.GetString("tipFormatMbHour") &" (+40%)")
        
            'Console
            Form.btnCopyConsole.Text = NHLGamesMetro.RmText.GetString("btnCopyConsole")
            Form.btnClearConsole.Text = NHLGamesMetro.RmText.GetString("btnClearConsole")

            'Modules
            Form.lblModules.Text = NHLGamesMetro.RmText.GetString("lblModules")
            Form.lblDetectionType.Text = NHLGamesMetro.RmText.GetString("lblDetectionType")
            Form.lblSpotify.Text = NHLGamesMetro.RmText.GetString("lblSpotify")
            Form.lblSpotifyDesc.Text = NHLGamesMetro.RmText.GetString("lblSpotifyDesc")
            Form.lblOBS.Text = NHLGamesMetro.RmText.GetString("lblObs")
            Form.lblObsDesc.Text = NHLGamesMetro.RmText.GetString("lblObsDesc")
            Form.lblObsAdEndingHotkey.Text = NHLGamesMetro.RmText.GetString("lblObsAdEndingHotkey")
            Form.lblObsAdStartingHotkey.Text = NHLGamesMetro.RmText.GetString("lblObsAdStartingHotkey")
            Form.rbVolumeDetection.Text = NHLGamesMetro.RmText.GetString("rbVolumeDetection")
            Form.rbFullscreenDetection.Text = NHLGamesMetro.RmText.GetString("rbFullscreenDetection")

            'Calendar
            Form.flpCalender.Controls.Clear()
            Form.flpCalender.Controls.Add(New Controls.CalenderControl)
        End Sub

        Public Shared Sub SetSettings()
            Form.txtMPCPath.Text = GetApplication(SettingsEnum.MpcPath, PathFinder.GetPathOfMpc())
            Form.txtVLCPath.Text = GetApplication(SettingsEnum.VlcPath, PathFinder.GetPathOfVlc())
            Form.txtMpvPath.Text = GetApplication(SettingsEnum.MpvPath, Path.Combine(Application.StartupPath, "mpv\mpv.exe"))
            Form.txtStreamlinkPath.Text = GetApplication(SettingsEnum.StreamlinkPath, Path.Combine(Application.StartupPath, "streamlink-0.6.0\streamlink.exe"))

            Form.chkShowFinalScores.Checked = ApplicationSettings.Read(Of Boolean)(SettingsEnum.ShowScores, True)
            Form.chkShowLiveScores.Checked = ApplicationSettings.Read(Of Boolean)(SettingsEnum.ShowLiveScores, True)
            Form.chkShowSeriesRecord.Checked = ApplicationSettings.Read(Of Boolean)(SettingsEnum.ShowSeriesRecord, True)

            Dim playersPath As String() = New String() {Form.txtMpvPath.Text, Form.txtMPCPath.Text, Form.txtVLCPath.Text}
            Dim watchArgs As GameWatchArguments = ApplicationSettings.Read(Of GameWatchArguments)(SettingsEnum.DefaultWatchArgs)

            If ValidWatchArgs(watchArgs, playersPath, Form.txtStreamlinkPath.Text) Then
                Player.RenewArgs(True)
                watchArgs = ApplicationSettings.Read(Of GameWatchArguments)(SettingsEnum.DefaultWatchArgs)
            End If

            PopulateComboBox(Form.cbLanguage, SettingsEnum.SelectedLanguage, SettingsEnum.LanguageList)
            PopulateComboBox(Form.cbServers, SettingsEnum.SelectedServer, settingsenum.ServerList)

            NHLGamesMetro.ServerIp = Dns.GetHostEntry(Form.cbServers.SelectedItem.ToString()).AddressList.First.ToString()
            NHLGamesMetro.HostName = Form.cbServers.SelectedItem.ToString()

            BindWatchArgsToForm(watchArgs)

            If (HostsFile.TestEntry( NHLGamesMetro.DomainName, NHLGamesMetro.ServerIp) = False) Then
                If InvokeElement.MsgBoxBlue(NHLGamesMetro.RmText.GetString("msgHostnameSet"), 
                                            NHLGamesMetro.RmText.GetString("msgAddHost"), 
                                            MessageBoxButtons.YesNo) = DialogResult.Yes Then
                    HostsFile.AddEntry(NHLGamesMetro.ServerIp,  NHLGamesMetro.DomainName)
                Else
                    Form.tabMenu.SelectedIndex = 1
                End If
            End If

            Form.lblNoGames.Location = New Point(((Form.flpGames.Width - Form.lblNoGames.Width) / 2),  Form.flpGames.Location.Y + 175)
            Form.spnLoading.Location = New Point(((Form.flpGames.Width - Form.lblNoGames.Width) / 2) + 42, Form.flpGames.Location.Y + 150)

            Form.spnLoading.Value = NHLGamesMetro.ProgressValue
            Form.spnLoading.Maximum = NHLGamesMetro.ProgressMaxValue
            Form.spnStreaming.Value = NHLGamesMetro.ProgressValue
            Form.spnStreaming.Maximum = NHLGamesMetro.ProgressMaxValue
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

        Private Shared Function ValidWatchArgs(watchArgs As GameWatchArguments, playersPath As String(), streamLinkPath As String) As Boolean
            If watchArgs Is Nothing Then Return True

            Dim hasPlayerSet As Boolean = playersPath.Any(Function(x) x = watchArgs.PlayerPath)
            If Not watchArgs.StreamlinkPath.Equals(streamlinkPath) Then Return True
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
                Form.chk60.Checked = watchArgs.Is60Fps

                Form.rbQual6.Checked = watchArgs.Quality = StreamQuality.Superb
                Form.rbQual5.Checked = watchArgs.Quality = StreamQuality.Great
                Form.rbQual4.Checked = watchArgs.Quality = StreamQuality.Good
                Form.rbQual3.Checked = watchArgs.Quality = StreamQuality.Normal
                Form.rbQual2.Checked = watchArgs.Quality = StreamQuality.Low
                Form.rbQual1.Checked = watchArgs.Quality = StreamQuality.Mobile

                Form.rbAkamai.Checked = watchArgs.Cdn = CdnType.Akc
                Form.rbLevel3.Checked = watchArgs.Cdn = CdnType.L3C

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

                Form.tgStreamer.Checked = watchArgs.UsestreamlinkArgs
                Form.txtStreamerArgs.Enabled = watchArgs.UsestreamlinkArgs
                Form.txtStreamerArgs.Text = watchArgs.StreamlinkArgs

                Form.txtOutputArgs.Text = watchArgs.PlayerOutputPath
                Form.txtOutputArgs.Enabled = watchArgs.UseOutputArgs
                Form.tgOutput.Checked = watchArgs.UseOutputArgs
            End If
        End Sub

    End Class
End Namespace

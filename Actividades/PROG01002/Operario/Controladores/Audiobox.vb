Imports NAudio.Wave

Module Audiobox
    Private zipFile As System.IO.Compression.ZipArchive = Nothing
    Private waveoutevent As WaveOutEvent = Nothing
    Private mp3reader As Mp3FileReader = Nothing
    Public Sub PlayAudio(filename As String)
        If zipFile Is Nothing Then
            Dim memstream As New IO.MemoryStream(My.Resources.audio)
            zipFile = New IO.Compression.ZipArchive(memstream, IO.Compression.ZipArchiveMode.Read)
        End If
        If waveoutevent IsNot Nothing Then
            If waveoutevent.PlaybackState = PlaybackState.Playing Then
                waveoutevent.Stop()
            End If
        End If
        If Not zipFile.Entries.Where(Function(x) x.Name = filename + ".mp3").Count > 0 Then
            Return
        End If
        Dim zipEntry = zipFile.GetEntry(filename + ".mp3").Open
        Dim mems As New IO.MemoryStream()
        zipEntry.CopyTo(mems)
        zipEntry.Close()
        mems.Seek(0, IO.SeekOrigin.Begin)
        mp3reader = New Mp3FileReader(mems)
        waveoutevent = New WaveOutEvent()
        AddHandler waveoutevent.PlaybackStopped, Sub(x, y)
                                                     waveoutevent = Nothing
                                                     mp3reader.Close()
                                                 End Sub
        waveoutevent.Init(mp3reader)
        waveoutevent.Play()
    End Sub
End Module

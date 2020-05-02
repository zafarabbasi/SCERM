Imports System.Xml
Imports System.IO

Public Class Form1

    Dim descrStr As String


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Set the caption bar text of the form.   
        Me.Text = "tutorialspoint.com"

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        OpenFileDialog1.Title = "Please Select a File"
        OpenFileDialog1.InitialDirectory = "C:temp"
        OpenFileDialog1.ShowDialog()

        TextBox1.Text = OpenFileDialog1.FileName.ToString()




    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click



        Dim dicArray(6, 10) As String

        ' Algo
        ' Varients
        ' TTPs
        dicArray(0, 0) = "Spearphishing"
        dicArray(0, 1) = "Phishing"
        dicArray(0, 2) = "Whaling"    '   Big Guy
        dicArray(0, 3) = "Vishing"    '   Adopt some one else
        dicArray(0, 4) = "Spear-phishing"
        dicArray(0, 5) = "Spear phishing"


        dicArray(1, 0) = "Remote Access Trojan"
        dicArray(1, 1) = "RAT"
        dicArray(1, 2) = "Trojan"
        dicArray(1, 3) = "Remote Access"
        dicArray(1, 4) = "Remote Access Executable"
        dicArray(1, 5) = "Remote Control"


        dicArray(2, 0) = "KeyLogging"
        dicArray(2, 1) = "KeyLogging 1"
        dicArray(2, 2) = "KeyLogging 2"
        dicArray(2, 3) = ""
        dicArray(2, 4) = ""
        dicArray(2, 5) = ""

        dicArray(3, 0) = "Malware"
        dicArray(3, 1) = "virus"
        dicArray(3, 2) = "heuristic"
        dicArray(3, 3) = "spyware"
        dicArray(3, 4) = ""
        dicArray(3, 5) = ""


        'Observables
        dicArray(4, 0) = "FTP"
        dicArray(4, 1) = "HTTP"
        dicArray(4, 2) = "SMTP"
        dicArray(4, 3) = "Port 48"
        dicArray(4, 4) = "Port 30"
        dicArray(4, 5) = "Port 90"


        'descrStr = ListBox9.Items(0).ToString.ToUpper

        '************ Change List Box In Two places 
        ' Reading list Box item
        ' Enter Your desired listbox here
        Dim SelListBox As ListBox
        SelListBox = ListBox2

        ' Rading and Saving List box data into string
        descrStr = ""
        For l_index As Integer = 0 To SelListBox.Items.Count - 1
            '*********** Enter ListBox which we want to read Data to search CTI data
            descrStr += SelListBox.Items(l_index).ToString.ToUpper
            descrStr += " "
        Next
        'MsgBox(descrStr)


        'SelListBox
        'ListBox2().Items.Clear()
        'ListBox4().Items.Clear()

        For compRun As Int16 = 0 To 3
            For compLabel As Int16 = 0 To 5
                If (dicArray(compRun, compLabel) = "") Then
                    Continue For
                End If
                If (descrStr.Contains(dicArray(compRun, compLabel).ToUpper)) Then
                    ' ***********  Write ListBox Name here to write the Data *****************
                    If (compRun = 0 Or compRun = 1 Or compRun = 2 Or compRun = 3) Then   ' TTP Found
                        ListBox2.Items.Add(dicArray(compRun, 0))
                    End If
                    If (compRun = 4) Then   ' Observable Found
                        ListBox4.Items.Add(dicArray(compRun, compLabel))
                    End If
                    MsgBox("Found : " + dicArray(compRun, compLabel))
                End If
            Next
        Next

        MsgBox("Process Completed . . .")

    End Sub


    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ListBox10.Items.Clear()
        Dim xd As XmlDocument = New XmlDocument()
        xd.Load("authors.xml")
        Dim newAuthor As XmlElement = xd.CreateElement("author")
        newAuthor.SetAttribute("code", "6")
        Dim fn As XmlElement = xd.CreateElement("fname")
        fn.InnerText = "Bikram"
        newAuthor.AppendChild(fn)
        Dim ln As XmlElement = xd.CreateElement("lname")
        ln.InnerText = "Seth"
        newAuthor.AppendChild(ln)
        xd.DocumentElement.AppendChild(newAuthor)
        Dim tr As XmlTextWriter = New XmlTextWriter("authors.xml", Nothing)
        tr.Formatting = Formatting.Indented
        xd.WriteContentTo(tr)
        tr.Close()
        Dim nl As XmlNodeList = xd.GetElementsByTagName("fname")
        For Each node As XmlNode In nl
            ListBox10.Items.Add(node.InnerText)
        Next node
    End Sub
    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub ListBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox4.SelectedIndexChanged

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim xws As XmlWriterSettings = New XmlWriterSettings()
        xws.Indent = True
        xws.NewLineOnAttributes = True
        Dim xw As XmlWriter = XmlWriter.Create("authors.xml", xws)
        xw.WriteStartDocument()
        xw.WriteStartElement("Authors")
        xw.WriteStartElement("author")
        xw.WriteAttributeString("code", "1")
        xw.WriteElementString("fname", "Zara")
        xw.WriteElementString("lname", "Ali")
        xw.WriteEndElement()
        xw.WriteStartElement("author")
        xw.WriteAttributeString("code", "2")
        xw.WriteElementString("fname", "Priya")
        xw.WriteElementString("lname", "Sharma")
        xw.WriteEndElement()
        xw.WriteStartElement("author")
        xw.WriteAttributeString("code", "3")
        xw.WriteElementString("fname", "Anshuman")
        xw.WriteElementString("lname", "Mohan")
        xw.WriteEndElement()
        xw.WriteStartElement("author")
        xw.WriteAttributeString("code", "4")
        xw.WriteElementString("fname", "Bibhuti")
        xw.WriteElementString("lname", "Banerjee")
        xw.WriteEndElement()
        xw.WriteStartElement("author")
        xw.WriteAttributeString("code", "5")
        xw.WriteElementString("fname", "Riyan")
        xw.WriteElementString("lname", "Sengupta")
        xw.WriteEndElement()
        xw.WriteEndElement()
        xw.WriteEndDocument()
        xw.Flush()
        xw.Close()
        WebBrowser1.Url = New Uri(AppDomain.CurrentDomain.BaseDirectory + "authors.xml")
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

        '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

        'Dim campInt, ttpInt, indInt, obserInt, incInt, etInt, taInt, coaInt As Integer

        'campInt = ttpInt = indInt = obserInt = incInt = etInt = taInt = coaInt = 0


        Dim strResults As String = String.Empty
        Dim strTmpNmes As String = String.Empty
        Dim campCounter, ttpCounter, IncCounter, IndCounter, taCounter, coaCounter, apCounter, etCounter, obsaCounter As Integer
        Dim SelListBox As ListBox
        Dim fileCout As Integer
        Dim strFileName As String
        Dim writeDetailInfo As Boolean

        writeDetailInfo = True

        fileCout = 0
        '*** Output File Creation ************************************************************
        Dim fileOut As System.IO.StreamWriter


        '*** Getting Folder Path *************************************************************
        Dim strFolderName As String
        strFolderName = getFolderPath(TextBox1.Text)

        'Reading Files from the folder
        Dim di As New IO.DirectoryInfo(strFolderName)
        Dim aryFi As IO.FileInfo() = di.GetFiles("*.xml")
        Dim fi As IO.FileInfo


        'Dim count As Int16
        'count = 0
        'For Each fi In aryFi
        '    'Reading data from file
        '    'fileReader = My.Computer.FileSystem.ReadAllText(fi.FullName)
        '    MsgBox(fi.Directory)
        '    MsgBox(fi.DirectoryName)
        '    MsgBox(fi.FullName())
        '    MsgBox(fi.Name)

        '    count += 1
        '    If count = 1 Then
        '        Exit Sub
        '    End If
        'Next



        Dim nameTTPFlg, nameCyboxFlg, nameIncidentFlg, nameExploitFlg, nameTAFlg As Boolean

        fileOut = My.Computer.FileSystem.OpenTextFileWriter(strFolderName + "\\Ranker_Results.txt", True)

        Dim tmpStringh, tmpString1, tmpString As String

        tmpStringh = "FileName,"
        tmpStringh = tmpStringh.PadRight(50, " ")

        tmpString1 = "Campaign,"
        tmpStringh += tmpString1.PadRight(17, " ")

        tmpString1 = "TTP,"
        tmpStringh += tmpString1.PadRight(17, " ")

        tmpString1 = "Incident,"
        tmpStringh += tmpString1.PadRight(17, " ")

        tmpString1 = "ThreatActor,"
        tmpStringh += tmpString1.PadRight(17, " ")

        tmpString1 = "Attack_Pattern,"
        tmpStringh += tmpString1.PadRight(17, " ")

        tmpString1 = "Exploit,"
        tmpStringh += tmpString1.PadRight(17, " ")

        tmpString1 = "Indicator,"
        tmpStringh += tmpString1.PadRight(17, " ")

        tmpString1 = "Observable,"
        tmpStringh += tmpString1.PadRight(17, " ")

        tmpString1 = "COA,"
        tmpStringh += tmpString1.PadRight(17, " ")


        'writing heading of output file
        fileOut.WriteLine(tmpStringh)



        Dim tmpStrCamp(500), tmpStrTtp(500), tmpStrInd(500), tmpStrObs(500), tmpStrInc(500), tmpStrTa(500), tmpStrcoa(500), tmpStrExp(500), tmpStr1 As String
        Dim tmpStrCounter As Int16

        tmpStrCounter = 0


        For Each fi In aryFi
            'Reading data from file
            'fileReader = My.Computer.FileSystem.ReadAllText(fi.FullName)

            Dim xr As XmlReader = XmlReader.Create(fi.FullName())

            '*** Getting file name *************************************************************
            strFileName = fi.Name

            'fileCout += 1
            'If fileCout > 3 Then
            '    Exit For
            'End If

            ListBox1().Items.Clear()
            ListBox2().Items.Clear()
            ListBox3().Items.Clear()
            ListBox4().Items.Clear()
            ListBox5().Items.Clear()
            ListBox6().Items.Clear()
            ListBox7().Items.Clear()
            ListBox8().Items.Clear()
            ListBox9().Items.Clear()
            tmpStrCounter = 0



            campCounter = 0
            ttpCounter = 0
            IncCounter = 0
            IndCounter = 0
            taCounter = 0
            coaCounter = 0
            apCounter = 0
            etCounter = 0
            obsaCounter = 0

            nameTTPFlg = False
            nameCyboxFlg = False
            nameIncidentFlg = False
            nameExploitFlg = False
            nameTAFlg = False
            Dim strFound As Boolean

            strFound = False


            Do While xr.Read()
                ' Read Campaign ---------------------------------------------------
                If xr.NodeType = XmlNodeType.Element AndAlso xr.Name = "campaign:Title" Then
                    'ListBox1.Items.Add(xr.ReadElementString)
                    'campCounter += 1
                    tmpStr1 = xr.ReadElementString
                    For kRun As Integer = 0 To campCounter - 1
                        If tmpStrTtp(kRun) = tmpStr1 Then
                            strFound = True
                            Continue For
                        End If
                    Next
                    If strFound = False Then
                        ListBox1.Items.Add(tmpStr1)
                        tmpStrTtp(campCounter) = tmpStr1
                        campCounter += 1
                    End If
                End If
                ' Read TTP ---------------------------------------------------
                strFound = False
                If xr.NodeType = XmlNodeType.Element AndAlso xr.Name = "ttp:Title" Then
                    tmpStr1 = xr.ReadElementString
                    For kRun As Integer = 0 To ttpCounter - 1
                        If tmpStrTtp(kRun) = tmpStr1 Then
                            strFound = True
                            Continue For
                        End If
                    Next
                    If strFound = False Then
                        ListBox2.Items.Add(tmpStr1)
                        tmpStrTtp(ttpCounter) = tmpStr1
                        ttpCounter += 1
                    End If
                End If
                ' Read Indicator ---------------------------------------------------
                If xr.NodeType = XmlNodeType.Element AndAlso xr.Name = "indicator:Title" Then
                    'ListBox3.Items.Add(xr.ReadElementString)
                    'IndCounter += 1
                    tmpStr1 = xr.ReadElementString
                    For kRun As Integer = 0 To IndCounter - 1
                        If tmpStrInd(kRun) = tmpStr1 Then
                            strFound = True
                            Continue For
                        End If
                    Next
                    If strFound = False Then
                        ListBox3.Items.Add(tmpStr1)
                        tmpStrInd(IndCounter) = tmpStr1
                        IndCounter += 1
                    End If
                End If
                ' Read Observable --------------------------------------------------- cybox:Title
                'If xr.NodeType = XmlNodeType.Element AndAlso xr.Name = "observable:Title" Then
                If xr.NodeType = XmlNodeType.Element AndAlso xr.Name = "cybox:Title" Then
                    'ListBox4.Items.Add(xr.ReadElementString)
                    'obsaCounter += 1
                    tmpStr1 = xr.ReadElementString
                    For kRun As Integer = 0 To obsaCounter - 1
                        If tmpStrObs(kRun) = tmpStr1 Then
                            strFound = True
                            Continue For
                        End If
                    Next
                    If strFound = False Then
                        ListBox4.Items.Add(tmpStr1)
                        tmpStrObs(obsaCounter) = tmpStr1
                        obsaCounter += 1
                    End If
                End If
                ' Read incident ---------------------------------------------------
                If xr.NodeType = XmlNodeType.Element AndAlso xr.Name = "incident:Title" Then
                    'ListBox5.Items.Add(xr.ReadElementString)
                    'IncCounter += 1
                    tmpStr1 = xr.ReadElementString
                    For kRun As Integer = 0 To IncCounter - 1
                        If tmpStrInc(kRun) = tmpStr1 Then
                            strFound = True
                            Continue For
                        End If
                    Next
                    If strFound = False Then
                        ListBox5.Items.Add(tmpStr1)
                        tmpStrInc(IncCounter) = tmpStr1
                        IncCounter += 1
                    End If
                End If
                ' Read Exploits ---------------------------------------------------
                If xr.NodeType = XmlNodeType.Element AndAlso xr.Name = "et:Title" Then
                    'ListBox6.Items.Add(xr.ReadElementString)
                    'etCounter += 1
                    tmpStr1 = xr.ReadElementString
                    For kRun As Integer = 0 To etCounter - 1
                        If tmpStrExp(kRun) = tmpStr1 Then
                            strFound = True
                            Continue For
                        End If
                    Next
                    If strFound = False Then
                        ListBox6.Items.Add(tmpStr1)
                        tmpStrExp(etCounter) = tmpStr1
                        etCounter += 1
                    End If
                End If
                ' Read coa ---------------------------------------------------
                If xr.NodeType = XmlNodeType.Element AndAlso xr.Name = "COA:Description" Then  ' IBM STIXS
                    'If xr.NodeType = XmlNodeType.Element AndAlso xr.Name = "coa:Title" Then
                    'ListBox7.Items.Add(xr.ReadElementString)
                    'coaCounter += 1
                    tmpStr1 = xr.ReadElementString
                    For kRun As Integer = 0 To coaCounter - 1
                        If tmpStrcoa(kRun) = tmpStr1 Then
                            strFound = True
                            Continue For
                        End If
                    Next
                    If strFound = False Then
                        ListBox7.Items.Add(tmpStr1)
                        tmpStrcoa(coaCounter) = tmpStr1
                        coaCounter += 1
                    End If
                End If
                '' Read TA ---------------------------------------------------
                If xr.NodeType = XmlNodeType.Element AndAlso xr.Name = "ta:Title" Then
                    'ListBox8.Items.Add(xr.ReadElementString)
                    'taCounter += 1
                    tmpStr1 = xr.ReadElementString
                    For kRun As Integer = 0 To taCounter - 1
                        If tmpStrTa(kRun) = tmpStr1 Then
                            strFound = True
                            Continue For
                        End If
                    Next
                    If strFound = False Then
                        ListBox8.Items.Add(tmpStr1)
                        tmpStrTa(taCounter) = tmpStr1
                        taCounter += 1
                    End If
                End If
                ' Read STIX Description ---------------------------------------------------
                'If xr.NodeType = XmlNodeType.Element AndAlso xr.Name = "stix:Description" Then
                '    ListBox9.Items.Add(xr.ReadElementString)
                'End If

            Loop

            If writeDetailInfo = True Then
                'writing heading of output file
                fileOut.WriteLine(tmpStringh)
            End If


            tmpString = ""

            strResults = strFileName
            strResults += ","
            strResults = strResults.PadRight(50, " ")

            tmpString = campCounter.ToString()
            tmpString += ","
            tmpString = tmpString.PadRight(5, " ")
            strResults += tmpString + "            "

            tmpString = ttpCounter.ToString()
            tmpString += ","
            tmpString = tmpString.PadRight(5, " ")
            strResults += tmpString + "            "

            tmpString = IncCounter.ToString()
            tmpString += ","
            tmpString = tmpString.PadRight(5, " ")
            strResults += tmpString + "            "

            tmpString = taCounter.ToString()
            tmpString += ","
            tmpString = tmpString.PadRight(5, " ")
            strResults += tmpString + "            "

            tmpString = apCounter.ToString()
            tmpString += ","
            tmpString = tmpString.PadRight(5, " ")
            strResults += tmpString + "            "

            tmpString = etCounter.ToString()
            tmpString += ","
            tmpString = tmpString.PadRight(5, " ")
            strResults += tmpString + "            "

            tmpString = IndCounter.ToString()
            tmpString += ","
            tmpString = tmpString.PadRight(5, " ")
            strResults += tmpString + "            "

            tmpString = obsaCounter.ToString()
            tmpString += ","
            tmpString = tmpString.PadRight(5, " ")
            strResults += tmpString + "            "

            tmpString = coaCounter.ToString()
            tmpString += ","
            tmpString = tmpString.PadRight(5, " ")
            strResults += tmpString + "            "

            'Writing info to file **************************
            fileOut.WriteLine(strResults)


            If writeDetailInfo = True Then
                '%%%% Writing Component Info into File %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

                ''Writing Campaign info into a file **************************
                fileOut.WriteLine("")
                SelListBox = ListBox1
                For l_index As Integer = 0 To SelListBox.Items.Count - 1
                    fileOut.WriteLine("Cam          " + SelListBox.Items(l_index).ToString)
                Next
                ''Writing TTP info info into a file **************************
                fileOut.WriteLine("")
                SelListBox = ListBox2
                For l_index As Integer = 0 To SelListBox.Items.Count - 1
                    fileOut.WriteLine("TTP          " + SelListBox.Items(l_index).ToString)
                Next
                'Writing incident info info to a file **************************
                fileOut.WriteLine("")
                SelListBox = ListBox5
                For l_index As Integer = 0 To SelListBox.Items.Count - 1
                    fileOut.WriteLine("Inc         " + SelListBox.Items(l_index).ToString)
                Next
                'Writing ThreatActor info info to a file **************************
                fileOut.WriteLine("")
                SelListBox = ListBox8
                For l_index As Integer = 0 To SelListBox.Items.Count - 1
                    fileOut.WriteLine("ThA          " + SelListBox.Items(l_index).ToString)
                Next
                'Writing Exploits info info to a file **************************
                fileOut.WriteLine("")
                SelListBox = ListBox6
                For l_index As Integer = 0 To SelListBox.Items.Count - 1
                    fileOut.WriteLine("Exp          " + SelListBox.Items(l_index).ToString)
                Next
                'Writing Indicators info info to a file **************************
                fileOut.WriteLine("")
                SelListBox = ListBox3
                For l_index As Integer = 0 To SelListBox.Items.Count - 1
                    fileOut.WriteLine("Ind          " + SelListBox.Items(l_index).ToString)
                Next
                'Writing Observables info info to a file **************************
                fileOut.WriteLine("")
                SelListBox = ListBox4
                For l_index As Integer = 0 To SelListBox.Items.Count - 1
                    fileOut.WriteLine("Obs          " + SelListBox.Items(l_index).ToString)
                Next
                'Writing COAS info info to a file **************************
                fileOut.WriteLine("")
                SelListBox = ListBox7
                For l_index As Integer = 0 To SelListBox.Items.Count - 1
                    fileOut.WriteLine("COA          " + SelListBox.Items(l_index).ToString)
                Next
                'MsgBox(descrStr)
            End If


            '%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
            ListBox11.Items.Add("Summary")
            ListBox11.Items.Add("Campaigns : " + campCounter.ToString)
                ListBox11.Items.Add("TTPs      : " + ttpCounter.ToString)
                ListBox11.Items.Add("Indicators: " + IndCounter.ToString)
                ListBox11.Items.Add("Observables: " + obsaCounter.ToString)
                ListBox11.Items.Add("COAS      : " + coaCounter.ToString)
                ListBox11.Items.Add("Exploits  : " + etCounter.ToString)
                ListBox11.Items.Add("TA        : " + taCounter.ToString)
                ListBox11.Items.Add("Incident  : " + IncCounter.ToString)


            Next
            fileOut.Close()

        MsgBox("AlhamduLillah,Completed . . .")


        '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&




    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click


        Dim str(5), dicArray(5, 5) As String

        str(0) = "PAKISTAN"
        str(1) = "PUNJAB"
        str(2) = "SINDH"
        str(3) = "BALUCHISTAN"

        dicArray(0, 0) = "PUNJAB"
        For iRun As Integer = 0 To 2
            If str.Contains(dicArray(0, 0).ToUpper) <> True Then
                MsgBox("Found")
            End If
        Next







        'Reading a file and add lines in list box
        'Dim lines() As String = IO.File.ReadAllLines("C:\dir\file.txt")
        'ListBox1.Items.AddRange(lines)

        'Reading lines from list box
        'Dim l_text As String
        'For l_index As Integer = 0 To ListBox2.Items.Count - 1
        '    l_text += ListBox2.Items(l_index).ToString
        '    l_text += " "
        'Next
        'MsgBox(l_text)

    End Sub
    Function getFolderPath(ByVal strTemp As String) As String

        Dim len As Integer

        'strTemp = tempStr
        Dim iRun, jRun As Integer
        Dim ch As Char

        '*******************************************************
        ' Getting Folder Path of the selected file
        iRun = jRun = 0
        iRun = strTemp.Length() - 1

        While (iRun > 0)
            ch = strTemp.ElementAt(iRun)
            iRun = iRun - 1
            If (ch = "\") Then
                iRun = iRun - 1
                len = iRun
                iRun = 0
            End If
        End While
        iRun = 0

        'Return Folder Name ********************
        Return (Mid(strTemp, 1, len + 2))

    End Function

    Function getFileName(ByVal strTemp As String) As String

        Dim len As Integer

        'strTemp = tempStr
        Dim iRun, jRun As Integer
        Dim ch As Char

        '*******************************************************
        ' Getting Folder Path of the selected file
        iRun = jRun = 0
        iRun = strTemp.Length() - 1

        While (iRun > 0)
            ch = strTemp.ElementAt(iRun)
            iRun = iRun - 1
            If (ch = "\") Then
                len = iRun + 1
                iRun = 0
            End If
        End While
        ' iRun = 0

        'Return File lder Name ********************
        Return (Mid(strTemp, len + 2, strTemp.Length()))

    End Function

    Private Sub ListBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox2.SelectedIndexChanged

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Me.Close()
    End Sub
End Class

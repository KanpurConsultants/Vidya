﻿Public Class FrmSms
    Inherits SMS.FrmSms

    Sub New(ByVal StrUPVar As String, ByVal DTUP As DataTable, ByVal AgLibVar As AgLibrary.ClsMain)
        MyBase.New(StrUPVar, DTUP, AgLibVar)
    End Sub
End Class

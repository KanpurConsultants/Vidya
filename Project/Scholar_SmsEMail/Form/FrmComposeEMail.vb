Public Class FrmComposeEMail
    Inherits EMail.FrmComposeEMail

    Sub New(ByVal StrUPVar As String, ByVal DTUP As DataTable, ByVal AgLibVar As AgLibrary.ClsMain)
        MyBase.New(StrUPVar, DTUP, AgLibVar)
    End Sub
End Class

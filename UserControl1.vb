Public Class UserControl1

    ' Константы для сообщений Windows
    Public Const WM_CHAR As Integer = &H102
    Public Const WM_RBUTTONDOWN As Integer = &H204
    Public Const WM_PASTE As Integer = &H302
    Public Const WM_COPY As Integer = &H301
    Public Const WM_CUT As Integer = &H300

    Protected Overrides Sub WndProc(ByRef m As Message)
        Select Case m.Msg
            Case WM_CHAR
                ' Разрешаем только цифры (48-57) и BackSpace (8)
                If (m.WParam.ToInt32() > 57 Or m.WParam.ToInt32() < 48) And m.WParam.ToInt32() <> 8 Then
                    Return
                End If

            Case WM_RBUTTONDOWN
                ' Запрещаем правую кнопку мыши
                Return

            Case WM_PASTE, WM_COPY, WM_CUT
                ' Запрещаем вставку, копирование и вырезание
                Return

            Case Else
                ' Для всех остальных сообщений - стандартная обработка
        End Select

        ' Передаем сообщение базовому классу
        MyBase.WndProc(m)
    End Sub

    ' Переопределяем свойство Text для запрета изменения из кода
    Public Overrides Property Text() As String
        Get
            Return MyBase.Text
        End Get
        Set(ByVal value As String)
            ' Оставляем пустым, чтобы запретить установку значения из кода
        End Set
    End Property

    '' Разрешаем изменение текста только через специальный метод
    'Public Sub SetNumericText(ByVal value As String)
    '    ' Проверяем, что вводимая строка содержит только цифры
    '    For Each c As Char In value
    '        If Not Char.IsDigit(c) Then
    '            Return
    '        End If
    '    Next
    '    MyBase.Text = value
    'End Sub

    '' Запрещаем контекстное меню
    'Protected Overrides Sub OnKeyDown(e As KeyEventArgs)
    '    ' Запрещаем Ctrl+C, Ctrl+V, Ctrl+X
    '    If e.Control AndAlso (e.KeyCode = Keys.C OrElse e.KeyCode = Keys.V OrElse e.KeyCode = Keys.X) Then
    '        e.SuppressKeyPress = True
    '        Return
    '    End If
    '    MyBase.OnKeyDown(e)
    'End Sub

    '' Запрещаем вставку через Drag&Drop
    'Protected Overrides Sub OnDragEnter(e As DragEventArgs)
    '    e.Effect = DragDropEffects.None
    'End Sub
End Class

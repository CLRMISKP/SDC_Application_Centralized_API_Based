Public Class LanguageConverter
       Public Function UrduChar(ByVal Value As Char) As Char
        UrduChar = ChrW(AscW(AsciiToUnicode(AscW(Value))))
    End Function
    private Function AsciiToUnicode(ByVal Number As Integer) As String

        Select Case Number
            Case 63 : AsciiToUnicode = ChrW(&H61F)
            Case 65 : AsciiToUnicode = ChrW(&H622)
            Case 66 : AsciiToUnicode = ChrW(&H698)
            Case 67 : AsciiToUnicode = ChrW(&H62B)
            Case 68 : AsciiToUnicode = ChrW(&H688)
            Case 71 : AsciiToUnicode = ChrW(&H63A)
            Case 72 : AsciiToUnicode = ChrW(&H62D)
            Case 73 : AsciiToUnicode = ChrW(&H651)
            Case 74 : AsciiToUnicode = ChrW(&H636)
            Case 75 : AsciiToUnicode = ChrW(&H62E)
            Case 78 : AsciiToUnicode = ChrW(&H6BA)
            Case 79 : AsciiToUnicode = ChrW(&H629)
            Case 80 : AsciiToUnicode = ChrW(&H6C1)
            Case 82 : AsciiToUnicode = ChrW(&H691)
            Case 83 : AsciiToUnicode = ChrW(&H635)
            Case 84 : AsciiToUnicode = ChrW(&H679)
            Case 85 : AsciiToUnicode = ChrW(&H626)
            Case 86 : AsciiToUnicode = ChrW(&H638)
            Case 87 : AsciiToUnicode = ChrW(&H676)
            Case 88 : AsciiToUnicode = ChrW(&H670)
            Case 89 : AsciiToUnicode = ChrW(&H6D3)
            Case 90 : AsciiToUnicode = ChrW(&H630)
            Case 97 : AsciiToUnicode = ChrW(&H627)
            Case 98 : AsciiToUnicode = ChrW(&H628)
            Case 99 : AsciiToUnicode = ChrW(&H686)
            Case 100 : AsciiToUnicode = ChrW(&H62F)
            Case 101 : AsciiToUnicode = ChrW(&H639)
            Case 102 : AsciiToUnicode = ChrW(&H641)
            Case 103 : AsciiToUnicode = ChrW(&H6AF)
            Case 104 : AsciiToUnicode = ChrW(&H6BE)
            Case 105 : AsciiToUnicode = ChrW(&H6CC)
            Case 106 : AsciiToUnicode = ChrW(&H62C)
            Case 107 : AsciiToUnicode = ChrW(&H6A9)
            Case 108 : AsciiToUnicode = ChrW(&H644)
            Case 109 : AsciiToUnicode = ChrW(&H645)
            Case 110 : AsciiToUnicode = ChrW(&H646)
            Case 111 : AsciiToUnicode = ChrW(&H647)
            Case 112 : AsciiToUnicode = ChrW(&H67E)
            Case 113 : AsciiToUnicode = ChrW(&H642)
            Case 114 : AsciiToUnicode = ChrW(&H631)
            Case 115 : AsciiToUnicode = ChrW(&H633)
            Case 116 : AsciiToUnicode = ChrW(&H62A)
            Case 117 : AsciiToUnicode = ChrW(&H621)
            Case 118 : AsciiToUnicode = ChrW(&H637)
            Case 119 : AsciiToUnicode = ChrW(&H648)
            Case 120 : AsciiToUnicode = ChrW(&H634)
            Case 121 : AsciiToUnicode = ChrW(&H6D2)
            Case 122 : AsciiToUnicode = ChrW(&H632)
            Case 63 : AsciiToUnicode = ChrW(&H61F)
            Case 59 : AsciiToUnicode = ChrW(&H61B)
                ' VB 6 Numeric Characters
            'Case 48 : AsciiToUnicode = ChrW(&H60) + ChrW(&H6)
            'Case 49 : AsciiToUnicode = ChrW(&H61) + ChrW(&H6)
            'Case 50 : AsciiToUnicode = ChrW(&H62) + ChrW(&H6)
            'Case 51 : AsciiToUnicode = ChrW(&H63) + ChrW(&H6)
            'Case 52 : AsciiToUnicode = ChrW(&HF4) + ChrW(&H6)
            'Case 53 : AsciiToUnicode = ChrW(&HF5) + ChrW(&H6)
            'Case 54 : AsciiToUnicode = ChrW(&H66) + ChrW(&H6)
            'Case 55 : AsciiToUnicode = ChrW(&H67) + ChrW(&H6)
            'Case 56 : AsciiToUnicode = ChrW(&H68) + ChrW(&H6)
            'Case 57 : AsciiToUnicode = ChrW(&H69) + ChrW(&H6)
                ' Numeric Characters
                Case 48 : AsciiToUnicode = 0
                Case 49 : AsciiToUnicode = 1
                Case 50 : AsciiToUnicode = 2
                Case 51 : AsciiToUnicode = 3
                Case 52 : AsciiToUnicode = 4
                Case 53 : AsciiToUnicode = 5
                Case 54 : AsciiToUnicode = 6
                Case 55 : AsciiToUnicode = 7
                Case 56 : AsciiToUnicode = 8
                Case 57 : AsciiToUnicode = 9


            Case 44 : AsciiToUnicode = ChrW(&H60C)
            Case 37 : AsciiToUnicode = ChrW(&H66A)
            Case 69 : AsciiToUnicode = ChrW(&H674)
            Case 46 : AsciiToUnicode = ChrW(&H6D4)
            Case 77 : AsciiToUnicode = ChrW(&H64E)
            Case 76 : AsciiToUnicode = ChrW(&H650)
            Case 81 : AsciiToUnicode = ChrW(&H64F)
            Case 58 : AsciiToUnicode = ChrW(&H3A)
            Case 34 : AsciiToUnicode = ChrW(&H22)
            Case 58 : AsciiToUnicode = ChrW(&H3A)
            Case 39 : AsciiToUnicode = ChrW(&H27)
            Case 47 : AsciiToUnicode = ChrW(&H2F)
            Case 60 : AsciiToUnicode = ChrW(&H3C)
            Case 62 : AsciiToUnicode = ChrW(&H3E)
            Case 92 : AsciiToUnicode = ChrW(&H5C)
            Case 91 : AsciiToUnicode = ChrW(&H5B)
            Case 93 : AsciiToUnicode = ChrW(&H5D)
            Case 123 : AsciiToUnicode = ChrW(&H7B)
            Case 125 : AsciiToUnicode = ChrW(&H7D)
            Case 166 : AsciiToUnicode = ChrW(&HA6)
            Case 33 : AsciiToUnicode = ChrW(&H21)
            Case 64 : AsciiToUnicode = ChrW(&H40)
            Case 35 : AsciiToUnicode = ChrW(&H23)
            Case 36 : AsciiToUnicode = ChrW(&H24)
            Case 94 : AsciiToUnicode = ChrW(&H5E)
            Case 38 : AsciiToUnicode = ChrW(&H26)
            Case 42 : AsciiToUnicode = ChrW(&H2A)
            Case 40 : AsciiToUnicode = ChrW(&H28)
            Case 41 : AsciiToUnicode = ChrW(&H29)
            Case 45 : AsciiToUnicode = ChrW(&H2D)
            Case 43 : AsciiToUnicode = ChrW(&H2B)
            Case 61 : AsciiToUnicode = ChrW(&H3D)
            Case 32 : AsciiToUnicode = ChrW(&H20)
            Case Else
                AsciiToUnicode = Chr(&H0) + Chr(&H0)
        End Select
    End Function
End Class

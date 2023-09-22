Public Class Form1

    Private invoiceNumber As Integer = 1 ' Initialize invoice number to 1

    ' Initialize your form by loading car types into the ComboBox
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.Items.Add("Subaru")
        ComboBox1.Items.Add("Fuso")
        ComboBox1.Items.Add("Noah")
        ComboBox1.Items.Add("Corolla")
        ComboBox1.SelectedIndex = 0 ' Default selected item
        UpdatePriceTextbox()
    End Sub

    ' Function to get car rental rate
    Private Function GetRentalRate(carType As String) As Integer
        Select Case carType
            Case "Subaru"
                Return 100000
            Case "Fuso"
                Return 150000
            Case "Noah"
                Return 75000
            Case "Corolla"
                Return 50000
            Case Else
                Return 0
        End Select
    End Function

    Private Sub UpdatePriceTextbox()
        Dim rate As Integer = GetRentalRate(ComboBox1.SelectedItem.ToString())
        TextBox3.Text = rate.ToString("N0")
    End Sub

    ' Update the Price textbox when a new car type is selected
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        UpdatePriceTextbox()
    End Sub

    ' When the "Rent" button is clicked
    Private Sub btnInvoice_Click(sender As Object, e As EventArgs) Handles btnInvoice.Click
        ' Validate ID
        If String.IsNullOrWhiteSpace(TextBox2.Text) Then
            MessageBox.Show("Please enter a valid ID.")
            Return
        End If

        Dim daysOfRental As Integer

        Dim startDate As Date = DateTimePicker1.Value
        Dim endDate As Date = DateTimePicker2.Value

        daysOfRental = (endDate - startDate).Days + 1

        ' Ensure end date is not before start date
        If daysOfRental <= 0 Then
            MessageBox.Show("End date can't be earlier than start date.")
            Return
        End If

        Dim rate As Integer = GetRentalRate(ComboBox1.SelectedItem.ToString())
        Dim totalPrice As Integer = daysOfRental * rate

        Dim currentInvoiceNumber As Integer = invoiceNumber
        invoiceNumber += 1

        ' Display invoice with the unique invoice number
        Dim invoice As String = $"Invoice #{currentInvoiceNumber}:{vbNewLine}" &
                                $"Name: {TextBox1.Text}{vbNewLine}" &
                                $"ID: {TextBox2.Text}{vbNewLine}" &
                                $"Car Type: {ComboBox1.SelectedItem}{vbNewLine}" &
                                $"Start Date: {startDate.ToShortDateString()}{vbNewLine}" &
                                $"End Date: {endDate.ToShortDateString()}{vbNewLine}" &
                                $"Total Amount: {totalPrice.ToString("N0")} UGX"

        ' Show the invoice
        MessageBox.Show(invoice)

        ' After displaying the invoice, prompt the user to print it
        Dim printDialog As New PrintDialog()
        If printDialog.ShowDialog() = DialogResult.OK Then
            Dim printDocument As New Printing.PrintDocument()
            AddHandler printDocument.PrintPage, AddressOf PrintDocument_PrintPage
            printDocument.Print()
        End If
    End Sub

    ' Handler for printing the invoice
    Private Sub PrintDocument_PrintPage(sender As Object, e As Printing.PrintPageEventArgs)
        Dim invoice As String = GetInvoiceText()
        Dim font As New Font("Arial", 12)
        Dim brush As New SolidBrush(Color.Black)
        Dim pageBounds As RectangleF = e.MarginBounds
        Dim textSize As SizeF = e.Graphics.MeasureString(invoice, font, pageBounds.Width)
        Dim x As Single = (pageBounds.Width - textSize.Width) / 2
        Dim y As Single = pageBounds.Top
        e.Graphics.DrawString(invoice, font, brush, New PointF(x, y))
    End Sub

    ' Function to get the formatted invoice text
    Private Function GetInvoiceText() As String
        Dim startDate As Date = DateTimePicker1.Value
        Dim endDate As Date = DateTimePicker2.Value
        Dim daysOfRental As Integer = (endDate - startDate).Days + 1
        Dim rate As Integer = GetRentalRate(ComboBox1.SelectedItem.ToString())
        Dim totalPrice As Integer = daysOfRental * rate
        Dim invoice As String = $"Invoice #{invoiceNumber}:{vbNewLine}" &
                                $"Name: {TextBox1.Text}{vbNewLine}" &
                                $"ID: {TextBox2.Text}{vbNewLine}" &
                                $"Car Type: {ComboBox1.SelectedItem}{vbNewLine}" &
                                $"Start Date: {startDate.ToShortDateString()}{vbNewLine}" &
                                $"End Date: {endDate.ToShortDateString()}{vbNewLine}" &
                                $"Total Amount: {totalPrice.ToString("N0")} UGX"
        Return invoice
    End Function

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        ' Prompt the user to print the invoice
        Dim printDialog As New PrintDialog()
        If printDialog.ShowDialog() = DialogResult.OK Then
            Dim printDocument As New Printing.PrintDocument()
            AddHandler printDocument.PrintPage, AddressOf PrintDocument_PrintPage
            printDocument.Print()
        End If
    End Sub
End Class

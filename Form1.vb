Public Class Form1

    Dim total As Double = 0 'Total bill amount
    Dim grandTotal As Double = 0 'Grand total bill amount
    Dim ItemPrice As Double 'Price of the selected item
    Dim itemName As String 'Name of the selected item
    Dim quantity As Integer 'Quantity of the selected item
    Dim itemTotal As Double 'Total cost of the selected item
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Initialize the list of items
        cboItems.Items.Add("Burger(Rs150.00)")
        cboItems.Items.Add("Pizza(Rs300.00)")
        cboItems.Items.Add("Fries(Rs70.00)")
        cboItems.Items.Add("Coke(Rs30.00)")
        cboItems.Items.Add("Tea(Rs12.00)")
        cboItems.Items.Add("Coffee(Rs20.00)")
        cboItems.Items.Add("SandWhich(Rs35.00)")
        cboItems.Items.Add("Vadapav(Rs14.00)")
        cboItems.Items.Add("Fried Rice(Rs45.00)")
        cboItems.Items.Add("Momos(Rs25.00)")
        cboItems.SelectedIndex = 0 'Set the default item to the first one in the list

        'Set the currency symbol to Indian rupee
        txtTotal.Text = "₹0.00"
        txtGrandTotal.Text = "₹0.00"
    End Sub
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        'Calculate the total cost of the selected item
        ItemPrice = getItemPrice(cboItems.SelectedIndex)
        quantity = CInt(txtQuantity.Text)
        itemTotal = itemPrice * quantity

        ' Validate quantity
        If Not Integer.TryParse(txtQuantity.Text, quantity) Or quantity <= 0 Then
            MessageBox.Show("Please enter a valid positive quantity.", "Canteen Management System", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        'Add the item to the list box and update the total bill amount
        lstItems.Items.Add(txtQuantity.Text & " x " & cboItems.SelectedItem & " - ₹" & itemTotal.ToString("0.00"))
        total += itemTotal
        txtTotal.Text = "₹" & total.ToString("0.00")

        'Clear the quantity textbox
        txtQuantity.Text = ""
    End Sub

    Private Function getItemPrice(index As Integer) As Double
        'Return the price of the selected item in INR
        Select Case index
            Case 0 'Burger
                Return 150.0
            Case 1 'Pizza
                Return 300.0
            Case 2 'Fries
                Return 70.0
            Case 3 'Coke
                Return 30.0
            Case 4 'Tea
                Return 12.0
            Case 5 'Coffee
                Return 20.0
            Case 6 'SandWhich
                Return 35.0
            Case 7 'Vadapav
                Return 14.0
            Case 8 'Fried Rice
                Return 45.0
            Case 9 'Momos
                Return 25.0
            Case Else 'Invalid index
                Return 0
        End Select
    End Function

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        'Clear the list box and reset the total bill amount
        lstItems.Items.Clear()
        total = 0
        txtTotal.Text = "₹0.00"
        txtGrandTotal.Text = "₹0.00"
    End Sub

    Private Sub btnPrintBill_Click(sender As Object, e As EventArgs) Handles btnPrintBill.Click
        ' Check if cart is empty
        If lstItems.Items.Count = 0 Then
            MessageBox.Show("Please add some items to the cart before generating a bill.", "Canteen Management System", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        ' Display bill
        Dim bill As String = ""
        For Each item As Object In lstItems.Items
            bill += item.ToString() & vbCrLf
        Next
        bill += "----------------------------------------------" & vbCrLf
        bill += "Total: " & total.ToString("C") & vbCrLf
        bill += "VAT: " & (total * 0.14).ToString("C") & vbCrLf
        bill += "Grand Total: " & (total * 1.14).ToString("C")
        MessageBox.Show(bill, "Canteen Management System - Bill", MessageBoxButtons.OK, MessageBoxIcon.Information)

        ' Clear cart
        lstItems.Items.Clear()
        total = 0
        txtTotal.Text = "₹0.00"

    End Sub
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        ' Close the form
        Me.Close()
    End Sub

End Class

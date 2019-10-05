Imports System
Imports System.Linq
Imports Fractions
Public Namespace Bit.RD
Public Structure Matrix
    Public Values(,) as Fraction
    Public ReadOnly Property Rows as Integer
    	   Get
		Return Values.GetLength(0)
	   End Get
    End Property

    Public ReadOnly Property Columns as Integer
    	   Get
		Return Values.GetLength(1)
	   End Get
    End Property
    
    Public Sub New(mat as IEnumerable(Of IEnumerable(Of Fraction)))
    	   ReDim Values(mat.Count-1, mat(0).Count-1)
	   For i = 0 to mat.Count-1
	       For j = 0 to mat(0).Count-1
	       	   Values(i,j) = mat(i)(j)
	       Next
	   Next
    End Sub

    Public Shared Operator *(ByVal m1 as Matrix, ByVal m2 as Matrix) as Matrix
    	   If m1.Columns <> m2.Rows Then
	      Throw New Exception("m1.Columns must be = m2.Rows")
	   End If
	   Dim values as New List(Of List(Of Fraction))
	   For i = 0 to m1.Rows-1
	       Dim row = new List(Of Fraction)
	       values.Add(row)
	       For j = 0 to m2.Columns-1
	       	   Dim val as Fraction = 0
		   For k = 0 to m2.Rows-1
		       val += (m1.Values(i,k) * m2.Values(k,j))
		   Next
		   row.Add(val)
	       Next
	   Next
	   Return New Matrix(values)
    End Operator
End Structure
End Namespace
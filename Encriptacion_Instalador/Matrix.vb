Imports System
Imports System.Linq
Imports Fractions

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

    Public Overrides Function ToString() As String
    	   Dim str = ""
	   For y = 0 to Columns-1
	       For x = 0 to Rows-1
	       	   str += Values(y,x).ToString()
		   str += vbTab
	       Next
	       str += vbNewLine
	   Next
	   Return str
    End Function

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

Module Program
   Sub Encode()
       Dim input = Console.ReadLine
       Dim values_a = input.Split(";").Select(Function(x) x.Split(",").Select(Function(i) i.Split("/"))).ToList()
       input = Console.ReadLine
       Dim values_b = input.Split(";").Select(Function(x) x.Split(",").Select(Function(i) i.Split("/"))).ToList()
       input = Console.ReadLine
       Dim values_c = input.Split(";").Select(Function(x) x.Split(",").Select(Function(i) i.Split("/"))).ToList()
       input = Console.ReadLine
       Dim values_d = input.Split(";").Select(Function(x) x.Split(",").Select(Function(i) i.Split("/"))).ToList()
       Dim bytevals(103) as Byte
       For x = 0 to 2
       	   For y = 0 to 2
	   Try
	       Dim num_d() as Byte = BitConverter.GetBytes(CType(Integer.Parse(values_a(y)(x)(0)), Int16))
	       bytevals((y*3*4)+(x*4)) = num_d(0)
	       bytevals((y*3*4)+(x*4)+1) = num_d(1)
	       Dim div_d() as Byte = BitConverter.GetBytes(CType(Integer.Parse(values_a(y)(x)(1)), Int16))
	       bytevals((y*3*4)+(x*4)+2) = div_d(0)
	       bytevals((y*3*4)+(x*4)+3) = div_d(1)
	   Catch e as Exception
	       Console.WriteLine(e)
	       Console.WriteLine(x)
	       Console.WriteLine(y)
	   End Try
	   Next
       Next
       For x = 0 to 2
       	   For y = 0 to 2
	       Dim num_d() as Byte = BitConverter.GetBytes(CType(Integer.Parse(values_b(y)(x)(0)), Int16))
	       bytevals((y*4*3)+(x*4)+36) = num_d(0)
	       bytevals((y*4*3)+(x*4)+37) = num_d(1)
	       Dim div_d() as Byte = BitConverter.GetBytes(CType(Integer.Parse(values_b(y)(x)(1)), Int16))
	       bytevals((y*4*3)+(x*4)+38) = div_d(0)
	       bytevals((y*4*3)+(x*4)+39) = div_d(1)
	   Next
       Next
       For x = 0 to 1
       	   For y = 0 to 1
	       Dim num_d() as Byte = BitConverter.GetBytes(CType(Integer.Parse(values_c(y)(x)(0)), Int16))
	       bytevals((y*4*2)+(x*4)+72) = num_d(0)
	       bytevals((y*4*2)+(x*4)+73) = num_d(1)
	       Dim div_d() as Byte = BitConverter.GetBytes(CType(Integer.Parse(values_c(y)(x)(1)), Int16))
	       bytevals((y*4*2)+(x*4)+74) = div_d(0)
	       bytevals((y*4*2)+(x*4)+75) = div_d(1)
	   Next
       Next
       For x = 0 to 1
       	   For y = 0 to 1
	       Dim num_d() as Byte = BitConverter.GetBytes(CType(Integer.Parse(values_d(y)(x)(0)), Int16))
	       bytevals((y*4*2)+(x*4)+88) = num_d(0)
	       bytevals((y*4*2)+(x*4)+89) = num_d(1)
	       Dim div_d() as Byte = BitConverter.GetBytes(CType(Integer.Parse(values_d(y)(x)(1)), Int16))
	       bytevals((y*4*2)+(x*4)+90) = div_d(0)
	       bytevals((y*4*2)+(x*4)+91) = div_d(1)
	   Next
       Next
       Console.WriteLine(System.Convert.ToBase64String(bytevals))
   End Sub
   
   Sub Main(args() as String)
       Dim input = Console.ReadLine
       If input = "ENC" Then
       	  Encode()
	  Return
       End If
       Dim bytes = System.Convert.FromBase64String(input)
       Dim A(2)() as Fraction
       Dim B(2)() as Fraction
       For y = 0 to 2
       	   A(y) = new Fraction(){Nothing, Nothing, Nothing}
           For x = 0 to 2
	       Dim num_a as Int16 = BitConverter.ToInt16(bytes,x*4+y*3*4)
	       Dim den_a as Int16 = BitConverter.ToInt16(bytes,x*4+y*3*4+2)
	       Dim frac = new Fraction(num_a, den_a)
	       A(y)(x) = frac
	   Next
       Next
       For y = 0 to 2
       	   B(y) = new Fraction(){Nothing, Nothing, Nothing}
           For x = 0 to 2
	       Dim num_b as Int16 = BitConverter.ToInt16(bytes,x*4+y*3*4+36)
	       Dim den_b as Int16 = BitConverter.ToInt16(bytes,x*4+y*3*4+38)
	       Dim frac = new Fraction(num_b, den_b)
	       B(y)(x) = frac
	   Next
       Next
       Dim C(1)() as Fraction
       Dim D(1)() as Fraction
       For y = 0 to 1
       	   C(y) = new Fraction(){Nothing, Nothing, Nothing}
           For x = 0 to 1
	       Dim num_a as Int16 = BitConverter.ToInt16(bytes,x*4+y*2*4+72)
	       Dim den_a as Int16 = BitConverter.ToInt16(bytes,x*4+y*2*4+72+2)
	       Dim frac = new Fraction(num_a, den_a)
	       C(y)(x) = frac
	   Next
       Next
       For y = 0 to 1
       	   D(y) = new Fraction(){Nothing, Nothing, Nothing}
           For x = 0 to 1
	       Dim num_b as Int16 = BitConverter.ToInt16(bytes,x*4+y*2*4+88)
	       Dim den_b as Int16 = BitConverter.ToInt16(bytes,x*4+y*2*4+88+2)
	       Dim frac = new Fraction(num_b, den_b)
	       D(y)(x) = frac
	   Next
       Next
       Dim MList as new List(Of List(Of Fraction))
       For y = 0 to 2
       	   Dim nList as New List(Of Fraction)
	   MList.Add(nList)
       	   For x = 0 to 2
	       nList.Add(A(y)(x))
	   Next
       Next
       Dim AMatrix = New Matrix(MList)
       MList = new List(Of List(Of Fraction))
       For y = 0 to 2
       	   Dim nList as New List(Of Fraction)
	   MList.Add(nList)
       	   For x = 0 to 2
	       nList.Add(B(y)(x))
	   Next
       Next
       Dim BMatrix = New Matrix(MList)
       Console.WriteLine("Matrix A:")
       Console.WriteLine(AMatrix)
       Console.WriteLine("Matrix B:")
       Console.WriteLine(BMatrix)
       Dim M1Matrix = AMatrix * BMatrix
       Console.WriteLine("Matrix M1:")
       Console.WriteLine(M1Matrix)
       MList = new List(Of List(Of Fraction))
       For y = 0 to 1
       	   Dim nList as New List(Of Fraction)
	   MList.Add(nList)
       	   For x = 0 to 1
	       nList.Add(C(y)(x))
	   Next
       Next
       Dim CMatrix = New Matrix(MList)
       MList = new List(Of List(Of Fraction))
       For y = 0 to 1
       	   Dim nList as New List(Of Fraction)
	   MList.Add(nList)
       	   For x = 0 to 1
	       nList.Add(D(y)(x))
	   Next
       Next
       Dim DMatrix = New Matrix(MList)
       Dim M2Matrix = CMatrix*DMatrix
       Console.WriteLine("Matrix C:")
       Console.WriteLine(CMatrix)
       Console.WriteLine("Matrix D:")
       Console.WriteLine(DMatrix)
       Console.WriteLine("Matrix M2:")
       Console.WriteLine(M2Matrix)
   End Sub
End Module
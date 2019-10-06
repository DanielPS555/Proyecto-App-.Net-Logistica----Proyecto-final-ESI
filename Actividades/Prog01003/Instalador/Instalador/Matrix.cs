using System;
using System.Collections.Generic;
using System.Linq;
using Fractions;

namespace BitMath
{
    public struct Matrix
    {
        public Fraction[,] Values;
        public int Rows
        {
            get
            {
                return Values.GetLength(0);
            }
        }

        public int Columns
        {
            get
            {

                return Values.GetLength(1);
            }
        }

        public static bool operator !=(Matrix a, Matrix b)
        {
            return !(a == b);
        }

        public static bool operator ==(Matrix a, Matrix b)
        {
            if (a.Rows != b.Rows || a.Columns != b.Columns) return false;
            for(int i = 0; i < a.Rows; i++)
            {
                for(int j = 0; j < a.Columns; j++)
                {
                    if (a.Values[i,j] != b.Values[i,j]) return false;
                }
            }
            return true;
        }

        public Matrix(IEnumerable<IEnumerable<Fraction>> mat)
        {
            var list = mat.Select(x => x.ToList()).ToList();
            this.Values = new Fraction[list.Count(), list[0].Count()];
            for (int i = 0; i < Values.GetLength(0); i++)
                for (int j = 0; j < Values.GetLength(1); j++)
                    Values[i, j] = list[i][j];
        }

        public override string ToString()
        {
            var str = "";
            for (int x = 0; x < Rows; x++)
            {
                for (int y = 0; y < Columns; y++)
                {
                    str += Values[x, y].ToString();
                    str += '\t';
                }
                str += '\n';
            }

            return str;
        }
        public static Matrix operator *(Matrix m1, Matrix m2)
        {
            if (m1.Columns != m2.Rows)
            {
                throw new Exception("m1.Columns must be = m2.Rows");
            }
            var values = new List<List<Fraction>>();

            for (int i = 0; i < m1.Rows; i++)
            {
                var row = new List<Fraction>();
                values.Add(row);

                for (int j = 0; j < m2.Columns; j++)
                {
                    Fraction val = 0;
                    for (int k = 0; k < m2.Rows; k++)
                    {
                        val += (m1.Values[i, k] * m2.Values[k, j]);
                    }
                    row.Add(val);
                }
            }

            return new Matrix(values);
        }

        //   Sub Main(args() as String)
        //       Dim input = Console.ReadLine
        //       If input = "ENC" Then
        //       	  Encode()
        //	  Return
        //       End If
        //       Dim bytes = System.Convert.FromBase64String(input)
        //       Dim A(2)() as Fraction
        //       Dim B(2)() as Fraction
        //       For y = 0 to 2
        //       	   A(y) = new Fraction(){Nothing, Nothing, Nothing}
        //           For x = 0 to 2
        //	       Dim num_a as Int16 = BitConverter.ToInt16(bytes,x*4+y*3*4)
        //	       Dim den_a as Int16 = BitConverter.ToInt16(bytes,x*4+y*3*4+2)
        //	       Dim frac = new Fraction(num_a, den_a)
        //	       A(y)(x) = frac
        //	   Next
        //       Next
        //       For y = 0 to 2
        //       	   B(y) = new Fraction(){Nothing, Nothing, Nothing}
        //           For x = 0 to 2
        //	       Dim num_b as Int16 = BitConverter.ToInt16(bytes,x*4+y*3*4+36)
        //	       Dim den_b as Int16 = BitConverter.ToInt16(bytes,x*4+y*3*4+38)
        //	       Dim frac = new Fraction(num_b, den_b)
        //	       B(y)(x) = frac
        //	   Next
        //       Next
        //       Dim C(1)() as Fraction
        //       Dim D(1)() as Fraction
        //       For y = 0 to 1
        //       	   C(y) = new Fraction(){Nothing, Nothing, Nothing}
        //           For x = 0 to 1
        //	       Dim num_a as Int16 = BitConverter.ToInt16(bytes,x*4+y*2*4+72)
        //	       Dim den_a as Int16 = BitConverter.ToInt16(bytes,x*4+y*2*4+72+2)
        //	       Dim frac = new Fraction(num_a, den_a)
        //	       C(y)(x) = frac
        //	   Next
        //       Next
        //       For y = 0 to 1
        //       	   D(y) = new Fraction(){Nothing, Nothing, Nothing}
        //           For x = 0 to 1
        //	       Dim num_b as Int16 = BitConverter.ToInt16(bytes,x*4+y*2*4+88)
        //	       Dim den_b as Int16 = BitConverter.ToInt16(bytes,x*4+y*2*4+88+2)
        //	       Dim frac = new Fraction(num_b, den_b)
        //	       D(y)(x) = frac
        //	   Next
        //       Next
        //       Dim MList as new List(Of List(Of Fraction))
        //       For y = 0 to 2
        //       	   Dim nList as New List(Of Fraction)
        //	   MList.Add(nList)
        //       	   For x = 0 to 2
        //	       nList.Add(A(y)(x))
        //	   Next
        //       Next
        //       Dim AMatrix = New Matrix(MList)
        //       MList = new List(Of List(Of Fraction))
        //       For y = 0 to 2
        //       	   Dim nList as New List(Of Fraction)
        //	   MList.Add(nList)
        //       	   For x = 0 to 2
        //	       nList.Add(B(y)(x))
        //	   Next
        //       Next
        //       Dim BMatrix = New Matrix(MList)
        //       Console.WriteLine("Matrix A:")
        //       Console.WriteLine(AMatrix)
        //       Console.WriteLine("Matrix B:")
        //       Console.WriteLine(BMatrix)
        //       Dim M1Matrix = AMatrix * BMatrix
        //       Console.WriteLine("Matrix M1:")
        //       Console.WriteLine(M1Matrix)
        //       MList = new List(Of List(Of Fraction))
        //       For y = 0 to 1
        //       	   Dim nList as New List(Of Fraction)
        //	   MList.Add(nList)
        //       	   For x = 0 to 1
        //	       nList.Add(C(y)(x))
        //	   Next
        //       Next
        //       Dim CMatrix = New Matrix(MList)
        //       MList = new List(Of List(Of Fraction))
        //       For y = 0 to 1
        //       	   Dim nList as New List(Of Fraction)
        //	   MList.Add(nList)
        //       	   For x = 0 to 1
        //	       nList.Add(D(y)(x))
        //	   Next
        //       Next
        //       Dim DMatrix = New Matrix(MList)
        //       Dim M2Matrix = CMatrix*DMatrix
        //       Console.WriteLine("Matrix C:")
        //       Console.WriteLine(CMatrix)
        //       Console.WriteLine("Matrix D:")
        //       Console.WriteLine(DMatrix)
        //       Console.WriteLine("Matrix M2:")
        //       Console.WriteLine(M2Matrix)
        //   End Sub
        //End Module
        public static Matrix[] FromBase64(string base64_block)
        {
            var bytes = System.Convert.FromBase64String(base64_block);
            Fraction[][] A = new Fraction[3][];
            for (int y = 0; y < 3; y++)
            {
                A[y] = new Fraction[3];
                for (int x = 0; x < 3; x++)
                {
                    Int16 num_a = BitConverter.ToInt16(bytes, y * 3 * 4 + x * 4);
                    Int16 den_a = BitConverter.ToInt16(bytes, y * 3 * 4 + x * 4 + 2);
                    var fract = new Fraction(num_a, den_a);
                    A[y][x] = fract;
                }
            }
            Fraction[][] B = new Fraction[3][];
            for (int y = 0; y < 3; y++)
            {
                B[y] = new Fraction[3];
                for (int x = 0; x < 3; x++)
                {
                    Int16 num_b = BitConverter.ToInt16(bytes, y * 3 * 4 + x * 4 + 36);
                    Int16 den_b = BitConverter.ToInt16(bytes, y * 3 * 4 + x * 4 + 36 + 2);
                    var fract = new Fraction(num_b, den_b);
                    B[y][x] = fract;
                }
            }
            Fraction[][] C = new Fraction[2][];
            for (int y = 0; y < 2; y++)
            {
                C[y] = new Fraction[2];
                for (int x = 0; x < 2; x++)
                {
                    Int16 num_c = BitConverter.ToInt16(bytes, y * 2 * 4 + x * 4 + 72);
                    Int16 den_c = BitConverter.ToInt16(bytes, y * 2 * 4 + x * 4 + 72 + 2);
                    var fract = new Fraction(num_c, den_c);
                    C[y][x] = fract;
                }
            }
            Fraction[][] D = new Fraction[2][];
            for (int y = 0; y < 2; y++)
            {
                D[y] = new Fraction[2];
                for (int x = 0; x < 2; x++)
                {
                    Int16 num_d = BitConverter.ToInt16(bytes, y * 2 * 4 + x * 4 + 88);
                    Int16 den_d = BitConverter.ToInt16(bytes, y * 2 * 4 + x * 4 + 88 + 2);
                    var fract = new Fraction(num_d, den_d);
                    D[y][x] = fract;

                }
            }
            Matrix AMat = new Matrix(A.Select(x => x.Cast<Fraction>()));
            Matrix BMat = new Matrix(B.Select(x => x.Cast<Fraction>()));
            Matrix CMat = new Matrix(C.Select(x => x.Cast<Fraction>()));
            Matrix DMat = new Matrix(D.Select(x => x.Cast<Fraction>()));
            return new Matrix[] { AMat, BMat, CMat, DMat };
        }

        public override bool Equals(object obj)
        {
            if(obj is Matrix om)
            {
                return this == om;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}

//Module Program
//   Sub Encode()
//       Dim input = Console.ReadLine
//       Dim values_a = input.Split(";").Select(Function(x) x.Split(",").Select(Function(i) i.Split("/"))).ToList()
//       input = Console.ReadLine
//       Dim values_b = input.Split(";").Select(Function(x) x.Split(",").Select(Function(i) i.Split("/"))).ToList()
//       input = Console.ReadLine
//       Dim values_c = input.Split(";").Select(Function(x) x.Split(",").Select(Function(i) i.Split("/"))).ToList()
//       input = Console.ReadLine
//       Dim values_d = input.Split(";").Select(Function(x) x.Split(",").Select(Function(i) i.Split("/"))).ToList()
//       Dim bytevals(103) as Byte
//       For x = 0 to 2
//       	   For y = 0 to 2
//	   Try
//	       Dim num_d() as Byte = BitConverter.GetBytes(CType(Integer.Parse(values_a(y)(x)(0)), Int16))
//	       bytevals((y*3*4)+(x*4)) = num_d(0)
//	       bytevals((y*3*4)+(x*4)+1) = num_d(1)
//	       Dim div_d() as Byte = BitConverter.GetBytes(CType(Integer.Parse(values_a(y)(x)(1)), Int16))
//	       bytevals((y*3*4)+(x*4)+2) = div_d(0)
//	       bytevals((y*3*4)+(x*4)+3) = div_d(1)
//	   Catch e as Exception
//	       Console.WriteLine(e)
//	       Console.WriteLine(x)
//	       Console.WriteLine(y)
//	   End Try
//	   Next
//       Next
//       For x = 0 to 2
//       	   For y = 0 to 2
//	       Dim num_d() as Byte = BitConverter.GetBytes(CType(Integer.Parse(values_b(y)(x)(0)), Int16))
//	       bytevals((y*4*3)+(x*4)+36) = num_d(0)
//	       bytevals((y*4*3)+(x*4)+37) = num_d(1)
//	       Dim div_d() as Byte = BitConverter.GetBytes(CType(Integer.Parse(values_b(y)(x)(1)), Int16))
//	       bytevals((y*4*3)+(x*4)+38) = div_d(0)
//	       bytevals((y*4*3)+(x*4)+39) = div_d(1)
//	   Next
//       Next
//       For x = 0 to 1
//       	   For y = 0 to 1
//	       Dim num_d() as Byte = BitConverter.GetBytes(CType(Integer.Parse(values_c(y)(x)(0)), Int16))
//	       bytevals((y*4*2)+(x*4)+72) = num_d(0)
//	       bytevals((y*4*2)+(x*4)+73) = num_d(1)
//	       Dim div_d() as Byte = BitConverter.GetBytes(CType(Integer.Parse(values_c(y)(x)(1)), Int16))
//	       bytevals((y*4*2)+(x*4)+74) = div_d(0)
//	       bytevals((y*4*2)+(x*4)+75) = div_d(1)
//	   Next
//       Next
//       For x = 0 to 1
//       	   For y = 0 to 1
//	       Dim num_d() as Byte = BitConverter.GetBytes(CType(Integer.Parse(values_d(y)(x)(0)), Int16))
//	       bytevals((y*4*2)+(x*4)+88) = num_d(0)
//	       bytevals((y*4*2)+(x*4)+89) = num_d(1)
//	       Dim div_d() as Byte = BitConverter.GetBytes(CType(Integer.Parse(values_d(y)(x)(1)), Int16))
//	       bytevals((y*4*2)+(x*4)+90) = div_d(0)
//	       bytevals((y*4*2)+(x*4)+91) = div_d(1)
//	   Next
//       Next
//       Console.WriteLine(System.Convert.ToBase64String(bytevals))
//   End Sub

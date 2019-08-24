using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;

namespace PERTTool
{

    [Serializable]
    public class Graph
    {
        public Graph()
        {
        }

        public List<Node> Nodes = new List<Node>();

        public IReadOnlyList<string> Activities
        {
            get
            {
                List<string> Activities = new List<string>();
                foreach (var i in Nodes)
                {
                    foreach (var k in i.GetEdges())
                        if (!Activities.Contains(k.Item2))
                            Activities.Add(k.Item2);
                }
                return Activities;
            }
        }
    }

    public partial class GraphTool : UserControl
    {
        private int UnitScale = 10;
        public float XScroll = 0;
        public float YScroll = 0;
        public Graph graph = new Graph();



        public GraphTool()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        private static void CalculateLateStart(Node tail, Dictionary<Node, List<Node>> parents, bool isTail = true)
        {
            if (isTail)
            {
                tail.Properties["Late Start"] = tail.Properties["Early Start"];
            }
            if (parents.ContainsKey(tail))
            {
                foreach (Node i in parents[tail])
                {
                    var ls = tail.Properties["Late Start"] - i.GetEdges().Where(x => x.Item1 == tail).Single().Item3;
                    if (i.Properties.ContainsKey("Late Start"))
                    {
                        i.Properties["Late Start"] = Math.Min(i.Properties["Late Start"], ls);
                    }
                    else i.Properties["Late Start"] = ls;
                }
                parents[tail].ForEach(x => CalculateLateStart(x, parents, false));
            }
        }

        private void GraphTool_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            var VisibleNodes = graph.Nodes.ToDictionary(x => x, x => x.GetEdges());
            var ParentNode = new Dictionary<Node, List<Node>>();
            HashSet<string> acts = new HashSet<string>();
            Node tail = null;
            string log = "";
            foreach (var x in VisibleNodes)
            {
                x.Key.Properties.Remove("Late Start");
            }
            foreach (var x in VisibleNodes)
            {
                if (x.Key.GetEdges().Count < 1)
                    tail = x.Key;
                if (!x.Key.Properties.ContainsKey("Early Start"))
                {
                    x.Key.Properties["Early Start"] = 0;
                }
                foreach (var z in x.Value)
                {
                    if (!ParentNode.ContainsKey(z.Item1))
                    {
                        ParentNode[z.Item1] = new List<Node>();
                    }
                    ParentNode[z.Item1].Add(x.Key);
                    if (acts.Contains(z.Item2))
                    {
                        log += ($"Duplicate item: {z.Item2}");
                    }
                    else acts.Add(z.Item2);
                    if (!z.Item1.Properties.ContainsKey("Early Start"))
                    {
                        z.Item1.Properties["Early Start"] = 0;
                    }
                    if (z.Item1.Properties["Early Start"] < x.Key.Properties["Early Start"] + z.Item3)
                    {
                        z.Item1.Properties["Early Start"] = x.Key.Properties["Early Start"] + z.Item3;
                    }
                    Pen drawingPen;
                    bool? pen = activitiesPath?.Contains(z.Item2);
                    if (pen.HasValue && pen.Value)
                        drawingPen = Pens.Green;
                    else
                        drawingPen = Pens.Black;
                    e.Graphics.DrawLine(drawingPen, (x.Key.Position < XScroll ^ YScroll) * UnitScale, ((x.Key.Position < XScroll ^ YScroll) + new V2F(0, 1.5f)) * UnitScale);
                    e.Graphics.DrawLine(drawingPen, ((x.Key.Position < XScroll ^ YScroll) + new V2F(0, 1.5f)) * UnitScale, ((x.Key.Position < XScroll ^ YScroll) + new V2F(1.5f, 1.5f)) * UnitScale);
                    e.Graphics.DrawLine(drawingPen, ((x.Key.Position < XScroll ^ YScroll) + new V2F(1.5f, 1.5f)) * UnitScale, (z.Item1.Position < XScroll ^ YScroll) * UnitScale);
                    e.Graphics.DrawString(z.Item2.ToString(), DefaultFont, new SolidBrush(Color.Red), new PointF(((x.Key.Position.X + z.Item1.Position.X) / 2 - XScroll) * UnitScale, ((x.Key.Position.Y + z.Item1.Position.Y) / 2 - YScroll - 1) * UnitScale));
                    e.Graphics.DrawString(z.Item3.ToString(), DefaultFont, new SolidBrush(Color.Red), new PointF(((x.Key.Position.X + z.Item1.Position.X) / 2 - XScroll) * UnitScale, ((x.Key.Position.Y + z.Item1.Position.Y) / 2 - YScroll + 1) * UnitScale));
                }
            }
            if (tail != null)
                CalculateLateStart(tail, ParentNode);
            foreach (var x in VisibleNodes)
            {
                RectangleF elipse = new RectangleF((x.Key.Position.X - XScroll - 1) * UnitScale, (x.Key.Position.Y - YScroll - 1) * UnitScale, UnitScale * 2, UnitScale * 2);
                e.Graphics.FillEllipse(new SolidBrush(SelectedNode == x.Key ? Color.SkyBlue : Color.White), elipse);
                e.Graphics.DrawEllipse(Pens.Black, elipse);
                SizeF StringSize = e.Graphics.MeasureString(x.Key.Name, DefaultFont);
                e.Graphics.DrawString(x.Key.Name, DefaultFont, new SolidBrush(Color.Red), new PointF((x.Key.Position.X - XScroll) * UnitScale - StringSize.Width / 2, (x.Key.Position.Y - YScroll) * UnitScale - StringSize.Height / 2));
                StringSize = e.Graphics.MeasureString(x.Key.Properties["Early Start"].ToString(), DefaultFont);
                e.Graphics.DrawString(x.Key.Properties["Early Start"].ToString(), DefaultFont, new SolidBrush(Color.Red), new PointF((x.Key.Position.X - XScroll) * UnitScale - StringSize.Width / 2, (x.Key.Position.Y - YScroll - 2.2f) * UnitScale));
                if (x.Key.Properties.ContainsKey("Late Start"))
                {
                    StringSize = e.Graphics.MeasureString(x.Key.Properties["Late Start"].ToString(), DefaultFont);
                    e.Graphics.DrawString(x.Key.Properties["Late Start"].ToString(), DefaultFont, new SolidBrush(Color.Red), new PointF((x.Key.Position.X - XScroll) * UnitScale - StringSize.Width / 2, (x.Key.Position.Y - YScroll + 1.2f) * UnitScale));
                }
            }
            e.Graphics.DrawString(log, DefaultFont, new SolidBrush(Color.Red), 0, 0);
        }

        public Node SelectedNode = null;
        private float lastX = -1, lastY = -1;
        private List<Node> RCheckNodes;
        public int Weight = 1;
        public string Activity;
        private string[] activitiesPath = null;
        public string Path
        {
            set
            {
                activitiesPath = value.Split('-').Select(x => x.Trim()).ToArray();
            }
        }
        public int PathTime(string path)
        {
            var activitiesInPath = path.Split('-').Select(x => x.Trim());
            return graph.Nodes.Select(x => x.GetEdges()) // todas las aristas
                .Aggregate((x, y) => x.Union(y).ToList()) // Unir en una sola lista
                .Where(x => activitiesInPath.Contains(x.Item2)) // seleccionar las actividades del camino
                .Select(x => x.Item3).Sum(); // sumar el peso de cada arista (duracion de actividad)
        }
        public List<string> Paths(List<string> list = null, Node node = null, string path = "", bool top_level = true)
        {
            if (node is null) node = graph.Nodes.FirstOrDefault();
            if (node is null) return null;
            if (list is null) list = new List<string>();
            if (node.GetEdges().Count == 0) list.Add(path);
            else
            {
                foreach (var i in node.GetEdges())
                {
                    string _p;
                    if (string.IsNullOrEmpty(path))
                        _p = i.Item2;
                    else
                        _p = path + " - " + i.Item2;
                    Paths(list, i.Item1, _p, false);
                }
            }
            if (!top_level) return null;
            var ls = list.Select(x => new Tuple<string, int>(x, PathTime(x))).ToList();
            ls.Sort(dcmp);
            ls.Reverse();
            return ls.Select(x => x.Item1 + $" ({x.Item2})").ToList();
        }
        private Comparison<Tuple<string, int>> dcmp = (x, y) => x.Item2.CompareTo(x.Item2);
        private Comparison<Tuple<Node, string, int>> tcmp = (x, y) => x.Item3.CompareTo(x.Item3);

        private bool PointError(float x1, float y1, float x2, float y2, float max_error)
        {
            return Math.Sqrt(Math.Pow(Math.Abs(x1 - x2), 2) + Math.Pow(Math.Abs(y1 - y2), 2)) < max_error;
        }

        private Node PointSelect(float x, float y)
        {
            if (PointError(x, y, lastX, lastY, 0.5f))
            {
                Node t = RCheckNodes.FirstOrDefault();
                if (t is null) return null;
                RCheckNodes = RCheckNodes.GetRange(1, RCheckNodes.Count - 1);
                return t;
            }
            else
            {
                RCheckNodes = graph.Nodes.Where(n => n.RangeCheck(x, y)).ToList();
                Node t = RCheckNodes.FirstOrDefault();
                if (t is null) return null;
                RCheckNodes = RCheckNodes.GetRange(1, RCheckNodes.Count - 1);
                lastX = x;
                lastY = y;
                return t;
            }
        }

        private void GraphTool_MouseDown(object sender, MouseEventArgs e)
        {
            float xPos = (float)e.X / UnitScale;
            xPos += XScroll;
            float yPos = (float)e.Y / UnitScale;
            yPos += YScroll;
            if (e.Button == MouseButtons.Right)
            {
                SelectedNode = PointSelect(xPos, yPos);
            }
            else if (e.Button == MouseButtons.Left)
            {
                graph.Nodes.Add(new Node(Activity, xPos, yPos));
            }
            else if (e.Button == MouseButtons.Middle && SelectedNode != null)
            {
                var OtherNode = PointSelect(xPos, yPos);
                if (OtherNode != null)
                {
                    SelectedNode?.ConnectTo(OtherNode, Weight, Activity);
                }
            }
            this.Invalidate();
        }

        private void GraphTool_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            if (e.KeyCode == Keys.W)
            {
                if (SelectedNode is null)
                    YScroll -= 3;
                else
                    SelectedNode.Position.Y -= 1;
            }
            else if (e.KeyCode == Keys.S)
            {
                if (SelectedNode is null)
                    YScroll += 3;
                else
                    SelectedNode.Position.Y += 1;
            }
            else if (e.KeyCode == Keys.A)
            {
                if (SelectedNode is null)
                    XScroll -= 3;
                else
                    SelectedNode.Position.X -= 1;
            }
            else if (e.KeyCode == Keys.D)
            {
                if (SelectedNode is null)
                    XScroll += 3;
                else
                    SelectedNode.Position.X += 1;
            }
            else if (e.KeyCode == Keys.Add)
            {
                UnitScale += 2;
            }
            else if (e.KeyCode == Keys.F && SelectedNode != null)
            {
                graph.Nodes.Remove(SelectedNode);
                graph.Nodes.ForEach(x => x.DisconnectFrom(SelectedNode));
                SelectedNode = null;
            }
            else if (e.KeyCode == Keys.Subtract)
            {
                UnitScale -= 2;
            }
            else
            {
                e.Handled = false;
                return;
            }
            Invalidate();
        }
    }
    [Serializable]
    public class V2F
    {
        public float X;
        public float Y;
        public static V2F operator +(V2F a, V2F b)
        {
            return new V2F(a.X + b.X, a.Y + b.Y);
        }
        public static implicit operator PointF(V2F x)
        {
            return new PointF(x.X, x.Y);
        }
        public static V2F operator +(V2F a, float b)
        {
            return new V2F(a.X + b, a.Y + b);
        }
        public static V2F operator <(V2F a, float b)
        {
            return new V2F(a.X - b, a.Y);
        }
        public static V2F operator >(V2F a, float b)
        {
            return new V2F(a.X + b, a.Y);
        }
        public static V2F operator ^(V2F a, float b)
        {
            return new V2F(a.X, a.Y - b);
        }

        public static V2F operator -(V2F a, float b)
        {
            return new V2F(a.X - b, a.Y - b);
        }
        public static V2F operator *(V2F a, float b)
        {
            return new V2F(a.X * b, a.Y * b);
        }
        public V2F(float x, float y)
        {
            X = x;
            Y = y;
        }
    }
    [Serializable]
    public class Node
    {
        private Dictionary<Node, Tuple<string, int>> Edges = new Dictionary<Node, Tuple<string, int>>();
        public string Name;
        public Dictionary<string, int> Properties = new Dictionary<string, int>();
        public V2F Position;
        public Node()
        {

        }


        public Node(string name, float x, float y)
        {
            Name = name;
            Position = new V2F(x, y);
        }

        public List<Tuple<Node, string, int>> GetEdges()
        {
            return Edges.ToList().Select(x => new Tuple<Node, string, int>(x.Key, x.Value.Item1, x.Value.Item2)).ToList();
        }

        public void ConnectTo(Node n, int weight, string activity)
        {
            Edges[n] = new Tuple<string, int>(activity, weight);
        }
        public void DisconnectFrom(Node n)
        {
            if (Edges.ContainsKey(n))
                Edges.Remove(n);
        }
        public bool VisibilityCheck(float XScroll, float YScroll, float HViewport, float VViewport)
        {
            return (Position.X - XScroll) < HViewport && (Position.Y - YScroll) < VViewport;
        }
        public bool RangeCheck(float xPos, float yPos)
        {
            return Math.Sqrt(Math.Pow(Math.Abs(xPos - Position.X), 2) + Math.Pow(Math.Abs(yPos - Position.Y), 2)) < 1.0f;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using GenTreeCore;
using GenTreeBE;
using System.Windows.Controls;
namespace GenTreeWPF
{
   public class DrawPersonGraph
   {
       public PersonsGraph PersonsGraph;
       public Canvas curCanvas;
       public int X;
       public int Y;
       public int CellWidth;
       public int CellHeight;
       public int FigureWidth;
       public int FigureHeight;
       public int lineThinkness = 5;
       public  DrawPersonGraph(PersonsGraph personsGraph,Canvas canvas,int x=100, int y=100,int cellW=50,int cellH=50,int figureW=30,int figureH=30)
       {
           PersonsGraph = personsGraph;
           curCanvas = canvas;
           X = x;
           Y = y;
           CellHeight = cellH;
           CellWidth = cellW;
           FigureWidth = figureW;
           FigureHeight = figureH;
       }
       public  void ClearCanvas()
       {
           curCanvas.Children.Clear();
       }
       private void DrawElement(int x, int y,int offsetX,int offsetY,int offsetBetweenLayers,Genders gender)
       {
           if (gender == Genders.Male)
           {
               if (offsetBetweenLayers != 0)
               {
                   curCanvas.Children.Add(new Rectangle()
                                              {
                                                  Width = offsetBetweenLayers*CellWidth,
                                                  Height = lineThinkness,
                                                  Fill = new LinearGradientBrush(Colors.Blue, Colors.Red, 30)
                                               });
                   Canvas.SetTop(curCanvas.Children[curCanvas.Children.Count - 1], Y - CellHeight * offsetY+FigureHeight/2);
                   Canvas.SetLeft(curCanvas.Children[curCanvas.Children.Count - 1], X - CellWidth * (offsetX+offsetBetweenLayers)+FigureWidth/2);

               }
               curCanvas.Children.Add(new Rectangle()
               {
                   Width = FigureWidth,
                   Height = FigureHeight,
                   Fill =
                       new LinearGradientBrush(Colors.Blue, Colors.Red, 30)
               });
               
               Canvas.SetTop(curCanvas.Children[curCanvas.Children.Count - 1], Y - CellHeight*offsetY);
               Canvas.SetLeft(curCanvas.Children[curCanvas.Children.Count - 1], X - CellWidth*offsetX);
               
           }
           else
           {
               if (offsetBetweenLayers != 0)
               {
                   curCanvas.Children.Add(new Rectangle()
                                              {
                                                  Width = offsetBetweenLayers*CellWidth,
                                                  Height = lineThinkness,
                                                  Fill = new LinearGradientBrush(Colors.Blue, Colors.Red, 30)
                                               });
                   Canvas.SetTop(curCanvas.Children[curCanvas.Children.Count - 1], Y - CellHeight*offsetY+FigureHeight/2);
                   Canvas.SetLeft(curCanvas.Children[curCanvas.Children.Count - 1], X - CellWidth*offsetX+FigureWidth/2);

                   curCanvas.Children.Add(new Rectangle()
                                              {
                                                  Width = lineThinkness,
                                                  Height = 2*CellHeight-FigureHeight/2,
                                                  Fill = new LinearGradientBrush(Colors.Blue, Colors.Red, 30)
                                               });
                   Canvas.SetTop(curCanvas.Children[curCanvas.Children.Count - 1], Y - CellHeight * offsetY+FigureHeight/2);
                   Canvas.SetLeft(curCanvas.Children[curCanvas.Children.Count - 1], X - CellWidth * (offsetX-offsetBetweenLayers)+FigureWidth/2-lineThinkness/2);

               }
               curCanvas.Children.Add(new Ellipse()
               {
                   Width = FigureWidth,
                   Height = FigureHeight,
                   Fill =
                       new LinearGradientBrush(Colors.Blue, Colors.Red, 30)
               });
               Canvas.SetTop(curCanvas.Children[curCanvas.Children.Count - 1], Y - CellHeight * offsetY);
               Canvas.SetLeft(curCanvas.Children[curCanvas.Children.Count - 1], X - CellWidth * offsetX);
           }
       }

       public void DrawToCanvas()
       {
           ClearCanvas();
           int cLayer = (int)System.Math.Log(PersonsGraph.Count-1, 2);// determine count of logical layers 0..lLayer
           //In the last logical layer all figures will be after one cell - if on the last layer is 1 cell of broad, then on the fist layer is lLayer for n layer
           //formula is lLayer-nlayer+1
           //int beginCellOffset = (int)Math.Pow(2);

           int i = 0;
           int verticalCellOffset = 0;//offset from cell relatively the first cell
           int horizontalCellOffset = 0;//offset the first element in layer
           int offsetBetweenLayers = 0;
           foreach (var graphElement in PersonsGraph)
           {
               if (graphElement != null)
               {
                   int nLayer = (int)System.Math.Log(i, 2);
                   if(nLayer==0)
                   {
                       DrawElement(X,Y,0,0,0,graphElement.Gender);
                   }
                   else
                   {
                       if(Math.Abs(System.Math.Pow(2d,(double)nLayer) - ((double)i)) < 1)//go to on to new layer
                       {
                           offsetBetweenLayers = cLayer - nLayer + 1;
                           horizontalCellOffset += offsetBetweenLayers;
                           verticalCellOffset += 2;
                       }
                       int localOffset =( i - (int)Math.Pow(2d, (double)nLayer))*offsetBetweenLayers*2;//offset in one layer
                       DrawElement(X,Y,horizontalCellOffset-localOffset,verticalCellOffset,offsetBetweenLayers,graphElement.Gender);   
                   }
                   
               }
               i++;
           }
       }
   }
}

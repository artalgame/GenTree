﻿#pragma checksum "..\..\..\EditRelativesWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "30012E9C0B1B24D45EF9AB93EEC28A6F"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.269
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace GenTreeWPF {
    
    
    /// <summary>
    /// EditRelativesWindow
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
    public partial class EditRelativesWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\..\EditRelativesWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TitleTextBlock;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\EditRelativesWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid RelationTableDataGrid;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\EditRelativesWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox RelationComboBox;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\EditRelativesWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SaveRelationButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/GenTreeWPF;component/editrelativeswindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\EditRelativesWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 4 "..\..\..\EditRelativesWindow.xaml"
            ((GenTreeWPF.EditRelativesWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.TitleTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.RelationTableDataGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 18 "..\..\..\EditRelativesWindow.xaml"
            this.RelationTableDataGrid.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.RelationTableDataGrid_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.RelationComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 25 "..\..\..\EditRelativesWindow.xaml"
            this.RelationComboBox.Loaded += new System.Windows.RoutedEventHandler(this.RelationComboBox_Loaded);
            
            #line default
            #line hidden
            return;
            case 5:
            this.SaveRelationButton = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\..\EditRelativesWindow.xaml"
            this.SaveRelationButton.Click += new System.Windows.RoutedEventHandler(this.SaveRelationButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


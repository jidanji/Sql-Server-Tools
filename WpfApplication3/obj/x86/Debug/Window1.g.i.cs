﻿#pragma checksum "..\..\..\Window1.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "DBAD6B00266245EDBE9305FDC03C9DBBECD8AD97"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using DataModel;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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
using WpfApplication3;


namespace WpfApplication3 {
    
    
    /// <summary>
    /// Window1
    /// </summary>
    public partial class Window1 : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 29 "..\..\..\Window1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtName;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\Window1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtFieldName;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\Window1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox cbkbiao;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\Window1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox cbkView;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\Window1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblBIaoCOunt;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\Window1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblShituCount;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\Window1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblSumCount;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\Window1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox listBox2;
        
        #line default
        #line hidden
        
        
        #line 117 "..\..\..\Window1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblCount1;
        
        #line default
        #line hidden
        
        
        #line 121 "..\..\..\Window1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DataGrid1;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WpfApplication3;component/window1.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Window1.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 4 "..\..\..\Window1.xaml"
            ((WpfApplication3.Window1)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txtName = ((System.Windows.Controls.TextBox)(target));
            
            #line 29 "..\..\..\Window1.xaml"
            this.txtName.KeyUp += new System.Windows.Input.KeyEventHandler(this.txtName_KeyUp);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txtFieldName = ((System.Windows.Controls.TextBox)(target));
            
            #line 33 "..\..\..\Window1.xaml"
            this.txtFieldName.KeyUp += new System.Windows.Input.KeyEventHandler(this.txtName_KeyUp);
            
            #line default
            #line hidden
            return;
            case 4:
            this.cbkbiao = ((System.Windows.Controls.CheckBox)(target));
            
            #line 37 "..\..\..\Window1.xaml"
            this.cbkbiao.Click += new System.Windows.RoutedEventHandler(this.cbkbiao_Click);
            
            #line default
            #line hidden
            
            #line 37 "..\..\..\Window1.xaml"
            this.cbkbiao.Checked += new System.Windows.RoutedEventHandler(this.cbkbiao_Checked);
            
            #line default
            #line hidden
            return;
            case 5:
            this.cbkView = ((System.Windows.Controls.CheckBox)(target));
            
            #line 38 "..\..\..\Window1.xaml"
            this.cbkView.Click += new System.Windows.RoutedEventHandler(this.cbkbiao_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.lblBIaoCOunt = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.lblShituCount = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.lblSumCount = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.listBox2 = ((System.Windows.Controls.ListBox)(target));
            
            #line 61 "..\..\..\Window1.xaml"
            this.listBox2.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.listBox2_MouseDoubleClick);
            
            #line default
            #line hidden
            
            #line 61 "..\..\..\Window1.xaml"
            this.listBox2.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.listBox2_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 10:
            this.lblCount1 = ((System.Windows.Controls.Label)(target));
            return;
            case 11:
            this.DataGrid1 = ((System.Windows.Controls.DataGrid)(target));
            
            #line 129 "..\..\..\Window1.xaml"
            this.DataGrid1.LoadingRow += new System.EventHandler<System.Windows.Controls.DataGridRowEventArgs>(this.DataGrid1_LoadingRow);
            
            #line default
            #line hidden
            
            #line 129 "..\..\..\Window1.xaml"
            this.DataGrid1.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.DataGrid1_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


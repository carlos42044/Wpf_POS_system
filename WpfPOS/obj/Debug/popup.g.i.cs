﻿#pragma checksum "..\..\popup.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "7E77A028ECE2E073E37A9AAC08826D03"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
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
using WpfPOS;


namespace WpfPOS {
    
    
    /// <summary>
    /// popup
    /// </summary>
    public partial class popup : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\popup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label totalLabel;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\popup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label requiredLabel;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\popup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tendered;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\popup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button processBtn;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\popup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cancelBtn;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfPOS;component/popup.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\popup.xaml"
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
            this.totalLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.requiredLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.tendered = ((System.Windows.Controls.TextBox)(target));
            
            #line 14 "..\..\popup.xaml"
            this.tendered.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.tendered_TextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.processBtn = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\popup.xaml"
            this.processBtn.Click += new System.Windows.RoutedEventHandler(this.processBtn_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.cancelBtn = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\popup.xaml"
            this.cancelBtn.Click += new System.Windows.RoutedEventHandler(this.cancelBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


﻿#pragma checksum "..\..\..\..\presentation\AddParcel.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "C81F06D807D76E80DC3B9733960EE4640EDC5FC3"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Coursework;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace Coursework {
    
    
    /// <summary>
    /// AddParcel
    /// </summary>
    public partial class AddParcel : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\..\presentation\AddParcel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAdd;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\..\presentation\AddParcel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lstCouriers;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\..\presentation\AddParcel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblCouriers;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\presentation\AddParcel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnConfirm;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\presentation\AddParcel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtDeliveryId;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\presentation\AddParcel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtAddressee;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\presentation\AddParcel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtArea;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.9.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Coursework;V1.0.0.0;component/presentation/addparcel.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\presentation\AddParcel.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.9.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.btnAdd = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\..\..\presentation\AddParcel.xaml"
            this.btnAdd.Click += new System.Windows.RoutedEventHandler(this.btnAdd_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.lstCouriers = ((System.Windows.Controls.ListView)(target));
            
            #line 15 "..\..\..\..\presentation\AddParcel.xaml"
            this.lstCouriers.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.lstCouriers_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.lblCouriers = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.btnConfirm = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\..\..\presentation\AddParcel.xaml"
            this.btnConfirm.Click += new System.Windows.RoutedEventHandler(this.btnConfirm_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.txtDeliveryId = ((System.Windows.Controls.TextBox)(target));
            
            #line 24 "..\..\..\..\presentation\AddParcel.xaml"
            this.txtDeliveryId.LostFocus += new System.Windows.RoutedEventHandler(this.txtPostcode_LostFocus);
            
            #line default
            #line hidden
            return;
            case 6:
            this.txtAddressee = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.txtArea = ((System.Windows.Controls.TextBox)(target));
            
            #line 27 "..\..\..\..\presentation\AddParcel.xaml"
            this.txtArea.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txtPostcode_TextChanged);
            
            #line default
            #line hidden
            
            #line 27 "..\..\..\..\presentation\AddParcel.xaml"
            this.txtArea.LostFocus += new System.Windows.RoutedEventHandler(this.txtPostcode_LostFocus);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


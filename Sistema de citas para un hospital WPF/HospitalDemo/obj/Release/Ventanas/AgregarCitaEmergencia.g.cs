﻿#pragma checksum "..\..\..\Ventanas\AgregarCitaEmergencia.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "30FD343931E0534A3637F2258DDAF91BC4AFFDB1"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using HospitalDemo.Ventanas;
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


namespace HospitalDemo.Ventanas {
    
    
    /// <summary>
    /// AgregarCitaEmergencia
    /// </summary>
    public partial class AgregarCitaEmergencia : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\Ventanas\AgregarCitaEmergencia.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel r_select_stack;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\Ventanas\AgregarCitaEmergencia.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox personalComboBox;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\Ventanas\AgregarCitaEmergencia.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel p_select_stack;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\Ventanas\AgregarCitaEmergencia.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox emergenciaTextBox;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\Ventanas\AgregarCitaEmergencia.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button save_btn;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\Ventanas\AgregarCitaEmergencia.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cancel_btn;
        
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
            System.Uri resourceLocater = new System.Uri("/HospitalDemo;component/ventanas/agregarcitaemergencia.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Ventanas\AgregarCitaEmergencia.xaml"
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
            this.r_select_stack = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 2:
            this.personalComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.p_select_stack = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 4:
            this.emergenciaTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.save_btn = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\..\Ventanas\AgregarCitaEmergencia.xaml"
            this.save_btn.Click += new System.Windows.RoutedEventHandler(this.Save_btn_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.cancel_btn = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\..\Ventanas\AgregarCitaEmergencia.xaml"
            this.cancel_btn.Click += new System.Windows.RoutedEventHandler(this.Cancel_btn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


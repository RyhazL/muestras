﻿#pragma checksum "..\..\..\Ventanas\AgregarCita.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "21094FDAF854D853867BFD1C10B9533BB6C4BF76"
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
    /// AgregarCita
    /// </summary>
    public partial class AgregarCita : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\Ventanas\AgregarCita.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel r_select_stack;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\Ventanas\AgregarCita.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox registroSelectCombo;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\Ventanas\AgregarCita.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel edit_stack;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\Ventanas\AgregarCita.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox pacienteComboBox;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\Ventanas\AgregarCita.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker citaDatePicker;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\Ventanas\AgregarCita.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button save_btn;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\Ventanas\AgregarCita.xaml"
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
            System.Uri resourceLocater = new System.Uri("/HospitalDemo;component/ventanas/agregarcita.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Ventanas\AgregarCita.xaml"
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
            this.registroSelectCombo = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.edit_stack = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 4:
            this.pacienteComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.citaDatePicker = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 6:
            this.save_btn = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\..\Ventanas\AgregarCita.xaml"
            this.save_btn.Click += new System.Windows.RoutedEventHandler(this.Save_btn_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.cancel_btn = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\..\Ventanas\AgregarCita.xaml"
            this.cancel_btn.Click += new System.Windows.RoutedEventHandler(this.Cancel_btn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

